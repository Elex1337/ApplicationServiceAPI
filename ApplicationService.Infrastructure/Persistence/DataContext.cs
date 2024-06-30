using Microsoft.EntityFrameworkCore;
using ApplicationService.Application.Interfaces;
using ApplicationService.Domain.Entities;
   

namespace ApplicationService.Infrastructure.Persistence;

public class DataContext : DbContext, IDataContext
{
   public DbSet<User> Users { get; set; }
   public DbSet<Request> Requests { get; set; }
   public DbSet<RequestType> RequestTypes { get; set; }
   
   public DataContext(DbContextOptions<DataContext> options): base(options)
   {

   }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<User>().ToTable("users");
      modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email");
      modelBuilder.Entity<User>().Property(u => u.Login).HasColumnName("login");
      modelBuilder.Entity<User>().Property(u => u.FullName).HasColumnName("fullname");
      modelBuilder.Entity<User>().Property(u => u.PasswordHash).HasColumnName("passwordhash");
      modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnName("userid");
      
   }
}