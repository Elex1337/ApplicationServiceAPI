using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ApplicationService.Domain.Entities;

namespace ApplicationService.Application.Interfaces;

public interface IDataContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<RequestType> RequestTypes { get; set; }
}   