using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthentication
    {
        Task<ClaimsPrincipal> Authenticate(UserDTO user);
    }
}
