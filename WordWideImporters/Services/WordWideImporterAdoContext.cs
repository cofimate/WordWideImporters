using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace WordWideImporters.Services
{
    public class WordWideImporterAdoContext  : DbContext
    {
        public string connectionString;
        public WordWideImporterAdoContext(DbContextOptions<WordWideImporterAdoContext> options) : base(options) 
        {
            connectionString = this.Database.GetDbConnection().ConnectionString;
        }

    }
}
