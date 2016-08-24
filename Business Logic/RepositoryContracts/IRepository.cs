using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.RepositoryContracts
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        List<T> GetWhere(Expression<Func<T, bool>> filter);

        T GetById(int id);

        void Insert(T t);

        void Update(T t);

        void Delete(int id);

    }
}
