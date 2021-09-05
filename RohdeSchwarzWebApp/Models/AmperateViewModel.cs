using System.ComponentModel.DataAnnotations;
namespace RohdeSchwarzWebApp.Models
{
    public class AmperageViewModel
    {
        [Display(Name = "Сила тока")]
        [Range(0, double.MaxValue, ErrorMessage = "Сила тока не должна быть меньше нуля")]
        public double Amperage { get; set; }
    }
}
