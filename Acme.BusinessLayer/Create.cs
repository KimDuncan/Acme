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

    public static bool SerialNumberAlreadyRegistred(string serialNumber)
    {
      DataLayer.Draw draw = new DataLayer.Draw();

      return draw.SerialNumberAlreadyRegistred(serialNumber);
    }

    public static bool Draw(string email, string serialNumber)
    {
      DataLayer.Draw draw = new DataLayer.Draw();

      return draw.Create(email,serialNumber);
    }
  }
}
