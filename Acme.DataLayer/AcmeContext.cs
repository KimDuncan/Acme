using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataLayer
{
  public class AcmeContext : DbContext
  {
    public AcmeContext() : base()
    {

    }
    public DbSet<Models.Product> Products { get; set; }
    public DbSet<Models.Type> Types { get; set; }
    public DbSet<Models.Participant> Participants { get; set; }
    public DbSet<Models.Draw> Draws { get; set; }



  }
}
