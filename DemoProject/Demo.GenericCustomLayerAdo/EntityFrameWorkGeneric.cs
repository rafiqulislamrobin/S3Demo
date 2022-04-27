using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.GenericCustomLayerAdo
{
    public class EntityFrameWorkGeneric<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        public EntityFrameWorkGeneric(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entityToAdd)
        {
            _dbSet.Add(entityToAdd);
        }

        public void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Deleted)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Remove(TKey id)
        {
            var deleteEntityID = _dbSet.Find(id);
            _dbSet.Remove(deleteEntityID);
        }

    }
}
