using Microsoft.AspNetCore.Mvc;
using StudentMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Controllers
{
    //Scaffold-DbContext "Server=.\SQLExpress; Database=StaffDb; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    public class StudentController : Controller
    {
        private readonly StudentDBContext _context;
        public StudentController(StudentDBContext context)
        {
            _context = context;
        }

        List<Student> allStudents = new List<Student>() { 
            new Student()
            {
                Id= 101,
                Name = "Sam",
                Address ="Kochin"
            },
            new Student()
            {
                Id = 102,
                Name = "George",
                Address = "Trissur"
            }
        };

        public IActionResult Index()
        {
            var students = _context.StudentTables.ToList();
            
            //using model 
            Student student = new Student();
            student.Id = 101;
            student.Name = "Sachin";
            student.Address = "Ernakulam, kakkanad";

            ///View bag and view data
            ViewBag.FatherName = "Sukumaran";
            ViewData["MotherName"] = "Lekshmi";

            //list of data
            List<string> courses = new List<string>();
            courses.Add("MBA");
            courses.Add("PGDMA");
            courses.Add("MCA");

            student.Courses = courses;

            return View(student);
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult SaveStudent(Student student)
        {
            allStudents.Add(student);

            //Db save
            StudentTable studentTable = new StudentTable();
            studentTable.Name = student.Name;
            studentTable.Address = student.Address;

            _context.Add(studentTable);
            _context.SaveChanges();

            return Json(student);
        }

        public IActionResult UpdateStudent(Student student)
        {
            var existingData = allStudents.Find(x => x.Id == student.Id);
            existingData = student;
            allStudents.Add(student);

            StudentTable studentTable = new StudentTable();
            _context.Update(studentTable);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(int id)
        {
            var existingData = allStudents.Find(x => x.Id == id);
            allStudents.Remove(existingData);

            StudentTable studentTable = new StudentTable();
            _context.Remove(studentTable);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult GetStudent(int id)
        {
            var existingData = allStudents.Find(x => x.Id == id);
            return null;
        }
    }
}
