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
      //Для постгресс чтобы правильно работало [Зачем я выбрал dbfirst :(] хэширование паролей не смог нормально настоить, хотел пофлексить в итоге пароли просто в стинге хранятся
      //Users
      modelBuilder.Entity<User>().ToTable("users");
      modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email");
      modelBuilder.Entity<User>().Property(u => u.Login).HasColumnName("login");
      modelBuilder.Entity<User>().Property(u => u.FullName).HasColumnName("fullname");
      modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("passwordhash");
      modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnName("userid");
      
      //Requests
      modelBuilder.Entity<Request>().ToTable("requests");
      modelBuilder.Entity<Request>().Property(r => r.RequestId).HasColumnName("requestid");
      modelBuilder.Entity<Request>().Property(r => r.PhoneNumber).HasColumnName("phonenumber");
      modelBuilder.Entity<Request>().Property(r => r.FullName).HasColumnName("fullname");
      modelBuilder.Entity<Request>().Property(r => r.Email).HasColumnName("email");
      modelBuilder.Entity<Request>().Property(r => r.RequestTypeId).HasColumnName("requesttypeid");
      modelBuilder.Entity<Request>().Property(r => r.UserId).HasColumnName("userid");
      modelBuilder.Entity<Request>().Property(r => r.CreatedAt).HasColumnName("createdat");


   }
}