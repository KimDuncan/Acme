using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataLayer.Models
{
  [Table("Draw")]
  public class Draw
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string SerialNumber { get; set; }
  }
}
