using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Model
{
    public partial class Actors
    {
        public string FullName
        {
            get
            {
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    return $"{LastName} {FirstName} {MiddleName}";
                }
                return $"{LastName} {FirstName}";
            }
        }
    }
}
