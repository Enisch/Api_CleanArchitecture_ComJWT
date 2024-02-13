using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usuarioaplication.Domain.DomainValidationException
{
    public class ValidationException:Exception
    {
        public ValidationException(string error):base(error)
        {
            
        }

        public static void When(bool HasError, string Error)
        {
            if (HasError)
            {
                throw new ValidationException(Error);
            }
        }

    }
}
