using BLL.Load;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    //so since im using LoadResult, you'll use Service - just like in the assignments
    public class UsersServiceImpl : LoadResult
    {
        public UsersServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {

        }
    }
}
