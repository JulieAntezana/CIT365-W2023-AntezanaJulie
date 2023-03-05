using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MvcMovie.Models
{
    public class UrlAttribute : ValidationAttribute
    {
        public UrlAttribute() { }

        public override bool IsValid(object value)
        {
            //may want more here for https, etc
            Regex regex = new Regex(@"(https?:)?//?[^\'""<>]+?\.(jpg|jpeg|gif|png)");

            if (value == null) return false;

            if (!regex.IsMatch(value.ToString())) return false;

            return true;
        }
    }
}
