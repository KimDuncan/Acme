using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BusinessLayer
{
  public class Generate
  {
    public static string SerialNumber(string prefix) 
    {
      Random random = new Random();

      string sn = prefix + random.Next(100, 999).ToString() + RandomString(2,random) + random.Next(100, 999).ToString() + RandomString(2, random);
      return sn;
    }

    public static string RandomString(int size, Random random)
    {
      var builder = new StringBuilder(size);

      char offset = 'A';
      const int lettersOffset = 26;

      for (var i = 0; i < size; i++)
      {
        var @char = (char)random.Next(offset, offset + lettersOffset);
        builder.Append(@char);
      }

      return builder.ToString();
    }

  }
}
