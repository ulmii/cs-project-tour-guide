﻿using Microsoft.EntityFrameworkCore;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Data
{
    public class TourGuideContext : DbContext
    {
        public string DbPath { get; }
        public TourGuideContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "tourguide.db");

            this.Database.Migrate();
            this.EnsureAdminCreated();
        }

        private void EnsureAdminCreated()
        {
            var admin = this.Users
                    .Where(u => u.Username == "admin")
                    .FirstOrDefault();

            if (admin == null)
            {
                var user = new User() { Username = "admin", Password = "admin", Admin = true };
                this.Add(user);
                this.SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(connectionString: $"Data Source={DbPath}");

        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
