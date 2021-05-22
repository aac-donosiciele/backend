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
        protected readonly DonosContext DbContext;
        protected readonly DbSet<T> DbSet;

        public CreateService(DonosContext context)
        {
            this.DbContext = context;
            this.DbSet = context.Set<T>();
        }
        public T Add(T entity)
        {
            entity.LastModifiedDate = entity.CreatedDate = DateTime.Now;
            this.DbSet.Add(entity);
            this.DbContext.SaveChanges();
            return this.DbSet.FirstOrDefault(e => e.Id == entity.Id);
        }
    }
}
