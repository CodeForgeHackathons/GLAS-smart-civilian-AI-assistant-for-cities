using System;
using Microsoft.EntityFrameworkCore;
using GLAS_Server.Models;

namespace GLAS_Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<NotificationSettings> NotificationSettings => Set<NotificationSettings>();
    }
}
