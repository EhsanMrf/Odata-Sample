using System.Collections.Generic;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF;

public class OdataDbContext : DbContext
{
    public OdataDbContext(DbContextOptions<OdataDbContext> options) : base(options)
    {

    }


    public DbSet<Area> Areas { get; set; }

}