using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Model
{
    public class Core
    {
        private static Cinema_DBEntities _context;

        public static Cinema_DBEntities GetContext()
        {
            if (_context == null)
            {
                _context = new Cinema_DBEntities();
            }
            return _context;
        }
    }
}
