using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeMyTeacher.ViewModels
{
    [Keyless]
    public class AdViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public bool AvailabilityOnline { get; set; }

        public bool AvailabilityHome { get; set; }

        public bool AvailabilityStudentHome { get; set; }

        public int PricePerSession { get; set; }

        public int SessionLenghtinMinutes { get; set; }

        public string Loaction { get; set; }

        public string Subject { get; set; }

        public string Education { get; set; }

        public string Calification { get; set; }

    }
}