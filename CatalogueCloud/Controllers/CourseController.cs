using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogueCloud.Models;
using CatalogueCloud.ViewModels;

namespace CatalogueCloud.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly ICategoryRepository categoryRepository;

        public CourseController(ICourseRepository courseRepository,
            ICategoryRepository categoryRepository
            )
        {
            this.courseRepository = courseRepository;
            this.categoryRepository = categoryRepository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public ViewResult List()
        {
            CourseListVM courseListVM = new CourseListVM()
            {
                Courses = courseRepository.AllCourses,
                SelectedCategoryName = categoryRepository.AllCategories.ToList()[0].Name
            };

            return View(courseListVM);
        }


        public ViewResult Details(int id)
        {
            var course = courseRepository.GetCourseById(id);
            return View(course);
        }

    }
}
