using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataLayer
{
  public class Product
  {
    string _ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kim\source\repos\Acme\Acme.DataLayer\AcmeDB.mdf;Integrated Security=True";
  
    #region Create
    public bool Create(string name, string description, string serialnumber, int type)
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var product = new Models.Product
      {
        Name = name,
        Description = description,
        SerialNumber = serialnumber,
        Type = type
      };
      context.Products.Add(product);
      int status = context.SaveChanges();

      return status > 0 ? true : false ;
    }
    #endregion

    #region CreateTypes
    public bool CreateTypes()
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var weapon = new Models.Type
      {
        Name = "Weapon",
        SerialPrefix = "WEAP"
      };

      var tonic = new Models.Type
      {
        Name = "Tonic",
        SerialPrefix = "TONI"
      };

      context.Types.Add(weapon);
      context.Types.Add(tonic);

      int status = context.SaveChanges();

      return status > 0 ? true : false;
    }
    #endregion

    #region VertificeSerialNumber
    public bool VertificeSerialNumber(string serialnumber)
    {
      var context = new AcmeContext();
      context.Database.Connection.ConnectionString = _ConnectionString;

      var products = context.Products.Where(w => w.SerialNumber == serialnumber);

      return products.Any();
    }
    #endregion

    #region ProductPrefix
    public string ProductPrefix(int type)
    {
      var context = new AcmeContext();

      context.Database.Connection.ConnectionString = _ConnectionString;

      var productType = context.Types.FirstOrDefault(w => w.Id == type);

      return productType.SerialPrefix;
    }
    #endregion

    #region ProductsOnStock
    public List<Models.ProductOnStock> ProductsOnStock()
    {
      List<Models.ProductOnStock> productOnStocks = new List<Models.ProductOnStock>();

      var context = new AcmeContext();

      context.Database.Connection.ConnectionString = _ConnectionString;


      var products = (from p in context.Products
                      join e in context.Types
                    on p.Type equals e.Id
                    select new
                    {
                      Name = p.Name,
                      Description = p.Description,
                      Type = e.Name
                    }).ToList();

      foreach (var product in products.Distinct())
      {
        Models.ProductOnStock productOnStock = new Models.ProductOnStock();

        productOnStock.Name  = product.Name;
        productOnStock.Description = product.Description;
        productOnStock.Type = product.Type;
        productOnStock.Amount = products.Count(c => c.Name == product.Name);

        productOnStocks.Add(productOnStock);
      }

      return productOnStocks;
    }
    #endregion

  }
}
