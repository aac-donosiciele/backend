using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services.BasicCrudServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Services
{
    public abstract class CUDService<T> : CreateService<T>, ICUDService<T>
        where T : BaseModel
    {
        
        public CUDService(Donos_Context context) : base(context)
        {
        }

        public T Edit(T entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            this.dbSet.Update(entity);
            this.context.SaveChanges();
            return this.dbSet.Where(e => e.Id == entity.Id).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            var entity = this.dbSet.Find(id);
            if (entity != null)
            {
                this.dbSet.Remove(entity);
                this.context.SaveChanges();
            }
        }
    }
}
