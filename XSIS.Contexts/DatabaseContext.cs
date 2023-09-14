using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XSIS.Models.Entities;

namespace XSIS.Contexts
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }


        public DbSet<Movie> Movies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //string mySqlConnection = "server=localhost; port=3306; database=db_xsis; user=root; password=abcd.1234; Persist Security Info=False; Connect Timeout=300";
            string mySqlConnection = _configuration.GetConnectionString("MySQLConnection");
            options.UseMySQL(mySqlConnection);

        }


    }
}
