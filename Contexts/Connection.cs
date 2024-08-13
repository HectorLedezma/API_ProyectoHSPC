using Microsoft.EntityFrameworkCore;

namespace EventApi.Context
{
    public class DatabaseSettings
    {
        public string? Server { get; set; }
        public string? Database { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
    }

    /*
    public class ConnectionSQL:DbContext
    {
        public ConnectionSQL(DbContextOptions<ConnectionSQL> options):base(options)
        {
            //
        }
        public DbSet<Ticket> Ticket_Paciente {get;set;}
    }
    */
}