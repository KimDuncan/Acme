using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataLayer.Models
{
  public class ProductOnStock
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int Amount { get; set; }
  }
}
