using BeMyTeacher.Util;
using Meditatori.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeMyTeacher.ViewModels
{
    public class SearchAdViewModel
    {
        public List<SubjectViewModel> Subjects { get; set; }
        public PaginatedList<AdViewModel> Ads { get; set; }
    }
}
