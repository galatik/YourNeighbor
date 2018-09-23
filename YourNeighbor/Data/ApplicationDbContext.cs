using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourNeighbor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace YourNeighbor.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Message> Messages { get; set; }

        public DbSet<UserArea> UserAreas { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<UserInterest> UserInterests { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Dialog> Dialogs { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(200);

                entity.Property(m => m.ProviderKey).HasMaxLength(200);
            });

            builder.Entity<IdentityUserRole<string>>().Property(r => r.RoleId).HasMaxLength(36);

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(e => e.LoginProvider).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            builder.Entity<User>().HasMany(u => u.MyMessages)
                .WithOne(m => m.FromUser)
                .HasForeignKey(m => m.FromUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>().HasMany(u => u.MessagesToMe)
                .WithOne(m => m.ToUser)
                .HasForeignKey(m => m.ToUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>().Property(u => u.Gender).HasConversion(new EnumToStringConverter<Gender>());

            builder.Entity<User>().Property(u => u.SocialStatus).HasConversion(new EnumToStringConverter<SocialStatus>());

            builder.Entity<Area>().HasIndex(a => a.AreaName);

            builder.Entity<City>().HasIndex(c => c.Name);

            builder.Entity<Interest>().HasKey(i => i.Name);

            builder.Entity<Message>().HasIndex(m => m.Text);

            builder.Entity<UserArea>().HasKey(ua => new { ua.UserId, ua.AreaId });

            builder.Entity<UserInterest>().HasOne(typeof(Interest)).WithMany().HasForeignKey("Interest");

            builder.Entity<UserInterest>().HasKey(ui => new { ui.UserId, ui.Interest });

            builder.Query<Dialog>(query =>
            {
                query.ToView("Dialogs");

                query.Property(d => d.LastMessageUserFromId).HasColumnName("Last_Message_User_From_Id");

                query.Property(d => d.LastMessageUserToId).HasColumnName("Last_Message_User_To_Id");

                query.Property(d => d.LastMessageTime).HasColumnName("Last_Message_Time");

                query.Property(d => d.LastMessageText).HasColumnName("Last_Message_Text");
            })
        }
    }
}
