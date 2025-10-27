using IKEA.DAL.Context;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Reporsatories.GenericRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly ApplicationDBContext _context;
        public GenericRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _context.Set<TEntity>().ToList();
            else
                return _context.Set<TEntity>().AsNoTracking().ToList();
        }
        public TEntity GetById(int id)
        {
            var TEntity = _context.Set<TEntity>().Find(id);
            return TEntity;
        }
        public int Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            return _context.SaveChanges();
        }
        public int Update(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
            return _context.SaveChanges();
        }

        public int Delete(TEntity item)
        {
            item.IsDeleted = true;
            _context.Set<TEntity>().Update(item);
            return _context.SaveChanges();
        }

    }
}
