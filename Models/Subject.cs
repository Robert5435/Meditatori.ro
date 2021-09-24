using System.Collections.Generic;

namespace Meditatori.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }
}

