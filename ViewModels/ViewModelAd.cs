namespace BeMyTeacher.ViewModels
{
    public class ViewModelAd
    {
        public string User { get; set; }
        public string Location { get; set; }

        public string Subject { get; set; }

        public string EducationLevel { get; set; }

        public string Calification { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool AvailabilityOnline { get; set; }

        public bool AvailabilityHome { get; set; }

        public bool AvailabilityStudentHome { get; set; }

        public int PricePerSession { get; set; }

        public int SessionLenghtinMinutes { get; set; }

    }
}