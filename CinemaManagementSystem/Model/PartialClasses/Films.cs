using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Model
{
    public partial class Films
    {
        public List<Genres> GenresList { get; set; }
        public string GenresListFormattedStr { get; set; }
    }
}
