using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogueCloud.Models
{
    public class EFCourseRepository: ICourseRepository
    {
        private readonly AppDBContext appDBContext;
        public EFCourseRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Course> AllCourses
        {
            get
            {
                return appDBContext.Courses.Include(c => c.Category);
            }
        }

        public IEnumerable<Course> FreeCoursesOfTheWeek => throw new NotImplementedException();

        public Course GetCourseById(int coueseId)
        {
            return appDBContext.Courses.Include(c => c.Category).FirstOrDefault(c => c.CourseId == coueseId);   
        }
    }
}
