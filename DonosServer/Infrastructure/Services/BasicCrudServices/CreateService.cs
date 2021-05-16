using Core.Entities;
using Core.Interfaces.BasicCrudServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Services.BasicCrudServices
{
    public abstract class CreateService<T> : ICreate<T>
            where T : BaseModel
    {
        protected readonly Donos_Context context;
        private readonly DbSet<T> dbSet;

        public CreateService(Donos_Context context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public virtual T Add(T entity)
        {
            entity.LastModifiedDate = entity.CreatedDate = DateTime.Now;
            this.dbSet.Add(entity);
            this.context.SaveChanges();
            return this.dbSet.Where(e => e.Id == entity.Id).FirstOrDefault();
        }
    }
}
