using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMapper<T, Z>
    {
        public Z MapFrom(T entity);

        public T MapTo();
    }
}
