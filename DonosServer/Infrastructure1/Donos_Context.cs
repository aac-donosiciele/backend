using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class Donos_Context : DbContext
    {
        public Donos_Context(DbContextOptions<Donos_Context> options) : base(options)
        {
        }

        protected Donos_Context()
        {
        }


    }
}
