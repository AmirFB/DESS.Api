using AutoMapper;
using Dess.Entities;
using Dess.Types;
using Microsoft.EntityFrameworkCore;

namespace Dess.DbContexts
{
  public class DessDbContext : DbContext
  {
    private IMapper _mapper;

    public DessDbContext(DbContextOptions<DessDbContext> options, IMapper mapper) : base(options) =>
            _mapper = mapper;

    public DbSet<ElectroFence> ElectroFences { get; set; }
    public DbSet<ElectroFenceStatus> Statuss { get; set; }
    public DbSet<IO> IOs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<ElectroFence>()
          .HasOne(e => e.Status)
          .WithOne(s => s.ElectroFence)
          .HasForeignKey<ElectroFenceStatus>(s => s.ElectroFenceId);


      var ef1 = new ElectroFence { Id = 1, Serial = "ehp-ie-tbz1", HvEnabled = true, LvEnabled = true, HvPower = 70, HvRepeat = 2, HvThreshold = 3000 };
      var ef2 = new ElectroFence { Id = 2, Serial = "ehp-ie-tbz2", HvEnabled = true, LvEnabled = false, HvPower = 70, HvRepeat = 3, HvThreshold = 4000 };
      var ef3 = new ElectroFence { Id = 3, Serial = "ehp-ie-tbz3", HvEnabled = true, LvEnabled = false, HvPower = 80, HvRepeat = 2, HvThreshold = 5000 };

      var status1 = new ElectroFenceStatus { Id = 1, ElectroFenceId = 1 };
      var status2 = new ElectroFenceStatus { Id = 2, ElectroFenceId = 2 };
      var status3 = new ElectroFenceStatus { Id = 3, ElectroFenceId = 3 };

      modelBuilder.Entity<ElectroFence>().HasData(ef1, ef2, ef3);
      modelBuilder.Entity<ElectroFenceStatus>().HasData(status1, status2, status3);

      for (int i = 0; i < 4; i++)
      {
        var io1 = new IO { Id = i * 3 + 1, Enabled = i < 2, Type = i % 2 == 0 ? IOType.NO : IOType.NC, ModuleId = ef1.Id };
        var io2 = new IO { Id = i * 3 + 2, Enabled = i < 3, Type = i % 2 == 1 ? IOType.NO : IOType.NC, ModuleId = ef2.Id };
        var io3 = new IO { Id = i * 3 + 3, Enabled = i < 1, Type = i % 2 == 0 ? IOType.NO : IOType.NC, ModuleId = ef3.Id };

        modelBuilder.Entity<IO>().HasData(io1, io2, io3);
      }
    }
  }
}