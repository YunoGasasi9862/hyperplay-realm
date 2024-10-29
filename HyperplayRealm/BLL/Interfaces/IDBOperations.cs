using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    //please dont use Task - do it without Task - like the way we did in the Assignment 5
    public interface IDBOperations<T, Z>
    {
        public Task<Result> Create(T type);

        public Task<Service> Update(T type);

        public Task<Service> Delete(int id);

        public IQueryable<Z> Query();
    }
}
