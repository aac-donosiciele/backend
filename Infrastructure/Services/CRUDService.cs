using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services.BasicCrudServices;
using System;
using System.Linq;

namespace Infrastructure.Services
{
    public abstract class CRUDService<T> : CreateService<T>, ICRUDService<T>
        where T : BaseModel
    {
        
        public CRUDService(DonosContext context) : base(context)
        {
        }

        public T Edit(T entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            this.DbSet.Update(entity);
            this.DbContext.SaveChanges();
            return this.DbSet.FirstOrDefault(e => e.Id == entity.Id);
        }

        public T Get(Guid id)
        {
            return this.DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            var entity = this.DbSet.Find(id);
            if (entity != null)
            {
                this.DbSet.Remove(entity);
                this.DbContext.SaveChanges();
            }
        }
    }
}
