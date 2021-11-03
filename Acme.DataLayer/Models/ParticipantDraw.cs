using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataLayer.Models
{
  [Table("ParticipantDraw")]
  public class ParticipantDraw
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string SerialNumber { get; set; }

    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
  }
}
