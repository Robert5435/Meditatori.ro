using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meditatori.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int clientdId { get; set; }

        public int teacherId { get; set; }

        public int userRating { get; set; }
    }
}
