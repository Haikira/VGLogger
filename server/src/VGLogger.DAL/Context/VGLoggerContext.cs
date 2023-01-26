using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;

namespace VGLogger.DAL.Context
{
    public class VGLoggerContext : BaseContext, IVGLoggerDatabase
    {
        public VGLoggerContext(DbContextOptions option) : base(option) { }
        public VGLoggerContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<Platform> Platforms { get; set; }
    }
}
