using System;

namespace Acme.Console
{
  class Program
  {
    static void Main(string[] args)
    {

      Acme.DataLayer.Product product = new DataLayer.Product();

      for (int i = 0; i < 99; i++)
      {

        string productName = "Tornado Kit";
        string productDescription = "";
        int type = 1;

        string prefix = product.ProductPrefix(type);

        string serialnumber = Acme.BusinessLayer.Generate.SerialNumber(prefix);

        while (product.VertificeSerialNumber(serialnumber) == true)
        {
          serialnumber = Acme.BusinessLayer.Generate.SerialNumber(prefix);
        }

        product.Create(productName, productDescription, serialnumber, type);

      }

      for (int i = 0; i < 99; i++)
      {

        string productName = "Hi-Speed Tonic";
        string productDescription = "Make you superfast";
        int type = 2;

        string prefix = product.ProductPrefix(type);

        string serialnumber = Acme.BusinessLayer.Generate.SerialNumber(prefix);

        while (product.VertificeSerialNumber(serialnumber) == true)
        {
          serialnumber = Acme.BusinessLayer.Generate.SerialNumber(prefix);
        }

        product.Create(productName, productDescription, serialnumber, type);

      }

    }
  }
}
