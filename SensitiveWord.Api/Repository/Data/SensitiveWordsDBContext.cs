using Microsoft.EntityFrameworkCore;
using SensitiveWord.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensitiveWord.Api.Repository.Data
{
    public class SensitiveWordsDBContext : DbContext
    {
        public SensitiveWordsDBContext(DbContextOptions<SensitiveWordsDBContext>options):
            base(options) { }

        public DbSet<Word> Words { get; set; }
    }
}
