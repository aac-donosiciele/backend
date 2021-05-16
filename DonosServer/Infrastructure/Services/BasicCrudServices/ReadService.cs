using Core.Entities;
using Core.Interfaces.BasicCrudServices;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Services.BasicCrudServices
{
    public abstract class ReadService<T> : IRead<T>
            where T : BaseModel
    {
        protected readonly Donos_Context context;
        private readonly DbSet<T> dbSet;

        public ReadService(Donos_Context context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public virtual T Get(Guid id)
        {
            return this.dbSet.Find(id);
        }
    }
}
