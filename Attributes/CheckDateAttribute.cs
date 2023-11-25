using System.ComponentModel.DataAnnotations;

namespace LR10.Attributes
{
    public class CheckDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date >= DateTime.Now;
        }
    }
}
