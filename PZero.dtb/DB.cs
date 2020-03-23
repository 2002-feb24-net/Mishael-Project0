using Microsoft.EntityFrameworkCore;
using System;

namespace PZero.dtb
{
    public class DB : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Secret.SecretString);
        }
    }
}
