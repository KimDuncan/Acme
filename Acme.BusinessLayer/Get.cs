using Acme.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer
{
  public class Get
  {
    public static List<ProductOnStock> ProductsOnStock() 
    {

      DataLayer.Product product = new DataLayer.Product();
      return product.ProductsOnStock();
    }

    public static List<Participant> Participants()
    {

      DataLayer.Participant participant = new DataLayer.Participant();
      return participant.Participants();
    }

  }
}
