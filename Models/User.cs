using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meditatori.Models
{
    public class User : IdentityUser
    {
        public string ProfilePictureLocation { get; set; }
        public int Rating { get; set; }
        public string UserDisplayName { get; set; }

        [ForeignKey("Calification")]
        public int? CalificationId { get; set; }
        public Calification Calification { get; set; }

    }
}
