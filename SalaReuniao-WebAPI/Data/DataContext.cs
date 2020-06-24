using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalaReuniao_WebAPI.Models;

namespace SalaReuniao_WebAPI.Data
{
public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sala>()
                .HasData(new List<Sala>(){
                    new Sala(1, "Sala Reuniao 1", 4),
                    new Sala(2, "Sala Reuniao 2", 6),
                    new Sala(3, "Sala Reuniao 3", 8),
                    new Sala(4, "Sala Reuniao 4", 10),
                    new Sala(5, "Sala Reuniao 5", 12),
                });
            
            builder.Entity<Agenda>()
                .HasData(new List<Agenda>{
                    new Agenda(1, "Reuniao Mensal","06/06/2020","07:00","08:00", 1),
                    new Agenda(2, "Feedback","23/06/2020","08:00","09:00", 2),
                    new Agenda(3, "Dailyng","19/06/2020","08:00","10:00", 3),
                    new Agenda(4, "Sprint","16/06/2020","10:30","11:00", 4),
                    new Agenda(5, "Backlog","01/07/2020","11:00","12:00", 5)
                });
        }
    }
}