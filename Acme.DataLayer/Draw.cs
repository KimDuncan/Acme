using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataLayer
{
  public class Draw
  {
    string _ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kim\source\repos\Acme\Acme.DataLayer\AcmeDB.mdf;Integrated Security=True";
  
    #region Create
    public bool Create(string email, string serialnumber)
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var draw = new Models.Draw
      {
        Email = email,
        SerialNumber = serialnumber,
      };
      context.Draws.Add(draw);
      int status = context.SaveChanges();

      return status > 0 ? true : false ;
    }
    #endregion

    #region Draws
    public List<Models.ParticipantDraw> ParticipantDraws()
    {
      List<Models.ParticipantDraw> ParticipantDraws = new List<Models.ParticipantDraw>();

      var context = new AcmeContext();

      context.Database.Connection.ConnectionString = _ConnectionString;


      var draws = (from p in context.Draws
                      join e in context.Participants
                    on p.Email equals e.Email
                      select new
                      {
                        Email = p.Email,
                        SerialNumber = p.SerialNumber,
                        Firstname = e.Firstname,
                        Lastname = e.Lastname,
                        DateOfBirth = e.DateOfBirth
                      }).ToList();


      foreach (var draw in draws)
      {
        Models.ParticipantDraw participantDraw = new Models.ParticipantDraw();

        participantDraw.Email = draw.Email;
        participantDraw.SerialNumber = draw.SerialNumber;
        participantDraw.Firstname = draw.Firstname;
        participantDraw.Lastname = draw.Lastname;
        participantDraw.DateOfBirth = draw.DateOfBirth;

        ParticipantDraws.Add(participantDraw);
      }

      return ParticipantDraws;
    }
    #endregion

    #region SerialNumberAlreadyRegistred
    public bool SerialNumberAlreadyRegistred( string serialnumber)
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var draws = context.Draws.Where(w => w.SerialNumber == serialnumber).ToList();

      return draws.Count() > 1 ? true : false;
    }
    #endregion
  }
}
