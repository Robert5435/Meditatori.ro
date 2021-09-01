using System.Collections.Generic;

namespace Meditatori.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string name { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }
}
