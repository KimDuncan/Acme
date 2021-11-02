using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer
{
  public class Create
  {
    public static bool Participant(string firstname, string lastname, string email,DateTime dateOfBirth)
    {
      DataLayer.Participant participant = new DataLayer.Participant();

      return participant.Create(firstname, lastname, email, dateOfBirth);
    }

    public static bool ValidateExistingParticipant(string email, DateTime dateOfBirth)
    {
      DataLayer.Participant participant = new DataLayer.Participant();

      return participant.ValidateExistingParticipant(email, dateOfBirth);
    }
  }
}
