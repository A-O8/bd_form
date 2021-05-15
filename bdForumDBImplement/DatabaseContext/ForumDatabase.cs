using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using bdForumDBImplement.Models;

namespace bdForumDBImplement.DatabaseContext
{
    public partial class ForumDatabase : DbContext
    {
        public ForumDatabase()
        {
        }

        public ForumDatabase(DbContextOptions<ForumDatabase> options)
            : base(options)
        {
        }

        public virtual DbSet<faculties> Like { get; set; }
        public virtual DbSet<applicants> Message { get; set; }
        public virtual DbSet<diriction> Moderator { get; set; }
       public virtual DbSet<subject> Topic { get; set; }
        public virtual DbSet<university> Visitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=hussin;Username=postgres;Password=738338337");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<faculties>(entity =>
            {
                entity.HasKey(e => new { e.Visitorlogin, e.Messageid })
                    .HasName("faculties__pkey");

                entity.ToTable("faculties_");

                entity.Property(e => e.Visitorlogin)
                    .HasColumnName("visitorlogin")
                    .HasMaxLength(255);

                entity.Property(e => e.Messageid).HasColumnName("messageid");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Like)
                    .HasForeignKey(d => d.Messageid)
                    .HasConstraintName("faculties__messageid_fkey");

                entity.HasOne(d => d.VisitorloginNavigation)
                    .WithMany(p => p.Like)
                    .HasForeignKey(d => d.Visitorlogin)
                    .HasConstraintName("faculties__visitorlogin_fkey");
            });

            modelBuilder.Entity<applicants>(entity =>
            {
                entity.ToTable("applicants_");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(20000);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Topicname)
                    .IsRequired()
                    .HasColumnName("topicname_")
                    .HasMaxLength(255);

                entity.Property(e => e.Visitorlogin)
                    .IsRequired()
                    .HasColumnName("visitorlogin")
                    .HasMaxLength(255);

                entity.HasOne(d => d.TopicnameNavigation)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.Topicname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("applicants__topicname__fkey");

                entity.HasOne(d => d.VisitorloginNavigation)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.Visitorlogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("applicants__visitorlogin_fkey");
            });

            modelBuilder.Entity<diriction>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("diriction_pkey");

                entity.ToTable("diriction");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Amountofhelp).HasColumnName("amountofhelp");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password_")
                    .HasMaxLength(255);

                entity.Property(e => e.TotalTime).HasColumnName("totalTime");
            });

            modelBuilder.Entity<subject>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("subject_pkey");

                entity.ToTable("subject");

                entity.Property(e => e.Name)
                    .HasColumnName("name_")
                    .HasMaxLength(255);

                entity.Property(e => e.Numberofmessages).HasColumnName("numberofmessages");

                entity.Property(e => e.Numberofvisitors).HasColumnName("numberofvisitors");
            });

            modelBuilder.Entity<university>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("university_pkey");

                entity.ToTable("university");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Countmessages).HasColumnName("countmessages");

                entity.Property(e => e.Decency).HasColumnName("decency");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password_")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.TotalTime)
                    .HasColumnName("totalTime")
                    .HasComment("Общее время");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
