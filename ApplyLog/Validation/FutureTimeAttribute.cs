using System.ComponentModel.DataAnnotations;

namespace ApplyLog.Validation
{
    public class FutureTimeAttribute : ValidationAttribute
    {
        public FutureTimeAttribute() 
        {
            ErrorMessage = "Deadline has to be in Future!";
        }
        public override bool IsValid(object? value)
        {
            if(value is DateTime dateValue)
            {
                return dateValue >= DateTime.Today;
            }
            return false;
        }
    }
}
