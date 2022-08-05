using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveVinsMrTerence.Validators
{
    public class NotAfterTodayAttribute : ValidationAttribute
    {
        public NotAfterTodayAttribute()
        {
            ErrorMessage = "Date ne peut pas être supérieure à la date du jour";
        }

        public override bool IsValid(object? value)
        {
            if (value is null)
            {
                return true;
            }
            DateTime date = (DateTime)value;
            return date < DateTime.Now;
        }
    }
}
