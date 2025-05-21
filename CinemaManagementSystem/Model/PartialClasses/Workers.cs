using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Model
{
    public partial class Workers
    {
        public string FullName { get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            } }
    }
}
