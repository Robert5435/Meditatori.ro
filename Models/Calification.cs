using System.Collections.Generic;

namespace Meditatori.Models
{
    public class Calification
    {
        public int Id { get; set; }

        public string name { get; set; }

        public ICollection<Ad> Ads { get; set; }

        public ICollection<User> Users { get; set; }


    }
}
