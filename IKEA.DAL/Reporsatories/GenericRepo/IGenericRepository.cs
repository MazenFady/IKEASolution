using IKEA.DAL.Models.Employees;
using IKEA.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Reporsatories.GenericRepo
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public IQueryable<TEntity> GetAll(bool WithTracking = false);
        public  TEntity GetById(int id);

        public int Add(TEntity item);

        public int Update(TEntity item);
        public int Delete(TEntity item);
        public IEnumerable<TEntity> GetEnumarble();
        public IQueryable<TEntity> GetQueryable();


    }
}
