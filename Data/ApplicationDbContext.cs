using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Test.Models;




namespace Test.Data;

public class ApplicationDbContext : DbContext


{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<New> News { get; set; }




}
