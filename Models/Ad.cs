﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meditatori.Models
{
    public class Ad
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int LocationId { get; set; }

        public int SubjectId { get; set; }

        public int EducationLevelId { get; set; }

        public int CalificationId { get; set; }

        public  string Title { get; set; }

        public string Content { get; set; }

        public bool Active { get; set; }

        public bool AvailabilityOnline { get; set; }

        public bool AvailabilityHome { get; set; }

        public bool AvailabilityStudentHome { get; set; }

        public int PricePerSession { get; set; }

        public int SessionLenghtinMinutes { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Subject Subject { get; set; }

        public Calification Calification { get; set; }

        public Location Location { get; set; }

        public EducationLevel EducationLevel { get; set; }



















    }
}
