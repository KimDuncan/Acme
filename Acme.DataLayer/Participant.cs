using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataLayer
{
  public class Participant
  {
    string _ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kim\source\repos\Acme\Acme.DataLayer\AcmeDB.mdf;Integrated Security=True";

    #region Create
    public bool Create(string firstname, string lastname, string email, DateTime DateOfBirth)
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var participant = new Models.Participant
      {
        Firstname = firstname,
        Lastname = lastname,
        Email = email,
        DateOfBirth = DateOfBirth
      };

      context.Participants.Add(participant);
      int status = context.SaveChanges();

      return status > 0 ? true : false;
    }
    #endregion

    #region CheckEmail
    public bool CheckEmail(string email)
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var Participants = context.Participants.Where(w => w.Email == email);

      return Participants.Any();
    }
    #endregion

    #region RegisterForDraw
    public bool RegisterForDraw(string email, DateTime DateOfBirth, string serialnumber)
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var validParticipant = ValidateExistingParticipant(email, DateOfBirth);
      if (validParticipant)
      {

        var draw = new Models.Draw
        {
          Email = email,
          SerialNumber = serialnumber
        };

        context.Draws.Add(draw);
        int status = context.SaveChanges();

        return status > 0 ? true : false;
      }
      return false;
    }
    #endregion

    #region ValidateExistingParticipant
    public bool ValidateExistingParticipant(string email, DateTime dateOfBirth)
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var Participants = context.Participants.Where(w => w.Email == email && w.DateOfBirth == dateOfBirth);

      return Participants.Any();
    }
    #endregion

    #region Participants
    public List<Models.Participant> Participants()
    {
      var context = new AcmeContext();

      context.Database.Connection.ConnectionString = _ConnectionString;
      
      return context.Participants.OrderBy(o=>o.Firstname).ToList();
    }
    #endregion
  }
}
