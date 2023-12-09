using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface ICourseRepository
    {
        Task<Course> AddCourse(int userId, Course course);
        Task<List<Course>> GetCourses(int userId);
        Task DeleteCourse(int courseId);
    }
}
