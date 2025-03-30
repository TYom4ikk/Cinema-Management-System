using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Model
{
    public class Core
    {
        private static CinemaEntities _context;

        public static CinemaEntities GetContext()
        {
            if (_context == null)
            {
                _context = new CinemaEntities();
            }
            return _context;
        }
    }
}
