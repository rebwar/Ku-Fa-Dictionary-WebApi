using System.Collections.Generic;
using Ku_Fa_Dictionary.Models;
using Microsoft.EntityFrameworkCore;

namespace Ku_Fa_Dictionary.Data
{
    public class DictionaryDbContext:DbContext
    {
        public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options):base(options)
        {
            
        }
        public DbSet<Dictionary> Dictionaries { get; set; }
    }
}