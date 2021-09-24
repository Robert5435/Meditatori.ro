using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeMyTeacher.ViewModels
{
    public class AdCreateViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool AvailabilityOnline { get; set; }

        public bool AvailabilityHome { get; set; }

        public bool AvailabilityStudentHome { get; set; }

        public int PricePerSession { get; set; }

        public int SessionLenghtinMinutes { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }

        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
        public IEnumerable<SelectListItem> Subjects { get; set; }

        [Display(Name = "Education")]
        public int EducationLevelId { get; set; }
        public IEnumerable<SelectListItem> EducationLevels { get; set; }

        [Display(Name = "Calification")]
        public int CalificationId { get; set; }
        public IEnumerable<SelectListItem> Califications { get; set; }
    }
}
