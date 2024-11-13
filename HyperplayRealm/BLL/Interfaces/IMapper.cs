using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    //dont need this, you can implement like hoca to map the Model fields to DTO
    public interface IMapper<T>
    {
        public void MapFrom(T entity);

        public T MapTo();
    }
}
