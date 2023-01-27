using Microsoft.EntityFrameworkCore;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;

namespace VGLogger.DAL.Context
{
    public class VGLoggerContext : BaseContext, IVGLoggerDatabase
    {
        public VGLoggerContext(DbContextOptions option) : base(option) { }
        public VGLoggerContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<DateType> DateTypes { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameDate> GameDates { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGame> UserGames { get; set; }
    }
}
