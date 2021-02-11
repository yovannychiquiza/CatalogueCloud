using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogueCloud.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }
        public string ImageUrl { get; set; }
        public bool IsWeekendClassAvailable { get; set; }

        public Category Category { get; set; }

        public bool isFreeThisWeek { get; set; }

    }
}
