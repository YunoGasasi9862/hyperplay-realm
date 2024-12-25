using BLL.Interfaces;
using BLL.Load;
using BLL.Models;
using BLL.DTOs;
using System.Threading.Tasks;
using BLL.Enums;
using BLL.Constants;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Impl
{
    public class UsersServiceImpl : LoadResult, IDBOperations<User, UserDTO>
    {
        private IDBOperations<UserRole, UserRoleDTO> _userRoleService;
        public UsersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, IDBOperations<UserRole, UserRoleDTO> userRoleService, IResult result) : base(hyperplayRealmDBContext, result)
        {
            _userRoleService = userRoleService;
        }

        public async Task<LoadResult> Create(User type)
        {
            bool userExists = HyperplayRealmDBContext.Users.Any(u => u.Username == type.Username || u.Email == type.Email);

            Console.WriteLine(type.ToString());

            if (userExists)
            {
                return (LoadResult) await Load(ResultEnum.ERROR, false);
            }

            HyperplayRealmDBContext.Users.Add(type);

            await HyperplayRealmDBContext.SaveChangesAsync();

            //here the best approach is to deal it within userRole service class, and call its service in the controller!!
            //the method should also return the type saved - the load Result should contain the entity, which can be used 
            //by the controller to initiate another insertion. 
            //should adhere to single responsibility!!
            //since the semester is already finished, and my focus is on senior year project,
            //i wont be able to implement this - returning the saved entity via load result to be used by another service
            if(!(await CreateUserRole(type)).Result.IsSuccessfull)
            {
                return (LoadResult)await Load(ResultEnum.ERROR, false);
            }

            return (LoadResult)await Load(ResultEnum.SUCCESS, true);
        }

        public Task<LoadResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDTO> Query()
        {
            return HyperplayRealmDBContext.Users.Include(ur => ur.UserRoles).ThenInclude(role => role.Role).Select(UserDTO.FromEntity);
        }

        public Task<LoadResult> Update(User type)
        {
            throw new NotImplementedException();
        }

        private async Task<LoadResult> CreateUserRole(User user)
        {
            bool userRoleExists = HyperplayRealmDBContext.UserRoles.Select(u => u.UserId == user.Id && u.RoleId == Constants.Constants.DEFAULT_USER_ROLE).Any();

            if (userRoleExists)
            {
                return (LoadResult) await Load(ResultEnum.ERROR, false);
            }

            HyperplayRealmDBContext.UserRoles.Add(new UserRole { RoleId = Constants.Constants.DEFAULT_USER_ROLE, UserId = user.Id });

            await HyperplayRealmDBContext.SaveChangesAsync();

            return (LoadResult)await Load(ResultEnum.SUCCESS, true);
        }
    }
}
