using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Acme.Web.Models
{
  [AllowAnonymous]
  public class DrawViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Firstname")]
    [Required(ErrorMessage = "Firstname is required.")]
    public string Firstname { get; set; }

    [Display(Name = "Lastname")]
    [Required(ErrorMessage = "Lastname is required.")]
    public string Lastname { get; set; }

    [Required(ErrorMessage = "SerialNumber is required.")]
    [RegularExpression("[a-zA-Z]{4}[0-9]{3}[a-zA-Z]{2}[0-9]{3}[a-zA-Z]{2}", ErrorMessage = "Not a valid SerialNumber.")]
    public string SerialNumber { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
    public DateTime DateOfBirth { get; set; }
  }
}
