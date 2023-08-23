using Dto;
using Infra;
using StudentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentData.Controllers
{
    public class StudentController : Controller
    {
        Studentinfra studentinfra;
        public StudentController()
        {
            studentinfra = new Studentinfra();
        }
        // GET: Student
        public ActionResult Index()
        {
            var StudentList= studentinfra.GetStudents();
            List<StudentViewModel> students = new List<StudentViewModel>();
            foreach(var item in StudentList)
            {
                StudentViewModel studentViewModel = new StudentViewModel();
                studentViewModel.StudentId = item.StudentId;
                studentViewModel.StudentName = item.StudentName;
                studentViewModel.StudentPhoneNumber = item.StudentPhoneNumber;
                studentViewModel.StudentEmail = item.StudentEmail;
                studentViewModel.RollNo = item.RollNo;
                students.Add(studentViewModel);
            }
            return View(students);
        }
        [HttpPost]
        public ActionResult Index(string StudentName)
        {
            var studendto = new StudentDto();
            studendto.StudentName = StudentName;
            var model = studentinfra.SearchStudent(studendto);
            List<StudentViewModel> studentViewModellist = new List<StudentViewModel>();
            foreach (var item in model)
            {
                StudentViewModel studentViewModel = new StudentViewModel();
                studentViewModel.StudentName = item.StudentName;
                studentViewModel.StudentPhoneNumber = item.StudentPhoneNumber;
                studentViewModel.StudentEmail = item.StudentEmail;
                studentViewModel.RollNo = item.RollNo;
                studentViewModellist.Add(studentViewModel);
            }
            return View(studentViewModellist);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentViewModel stuentViewModel)
        {
            var student=new StudentDto();
            {
                student.StudentName = stuentViewModel.StudentName;
                student.StudentPhoneNumber = stuentViewModel.StudentPhoneNumber;
                student.StudentEmail = stuentViewModel.StudentEmail;
                student.RollNo = stuentViewModel.RollNo;
            };
            studentinfra.CreateStudent(student);
            return RedirectToAction("Index", "Student");
        }
        public ActionResult Delete(int Id)
        {
            var student = new StudentDto();
            {
                student.StudentId = Id;
            }
             studentinfra.DeleteStudent(student);
             return RedirectToAction("Index", "Student");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var studentdtoData = studentinfra.FillStudentdata(Id);
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.StudentId=studentdtoData.StudentId;
            studentViewModel.StudentName=studentdtoData.StudentName;
            studentViewModel.StudentPhoneNumber=studentdtoData.StudentPhoneNumber;
            studentViewModel.StudentEmail=studentdtoData.StudentEmail;
            studentViewModel.RollNo = studentdtoData.RollNo;
            return View(studentViewModel);
        }
        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            var studentDto = new StudentDto();
            studentDto.StudentName = student.StudentName;
            studentDto.StudentPhoneNumber = student.StudentPhoneNumber;
            studentDto.StudentId = student.StudentId;
            studentDto.StudentEmail = student.StudentEmail;
            studentDto.RollNo = student.RollNo;
            studentinfra.Updatestudent(studentDto);
            return RedirectToAction("Index", "Student");
        }
        public ActionResult Search(string StudentName) 
        {
            var studendto = new StudentDto();
            studendto.StudentName = StudentName;
            var model =studentinfra.SearchStudent(studendto);
            List<StudentViewModel> studentViewModellist=new List<StudentViewModel>();
            foreach (var item in model)
            {
                StudentViewModel studentViewModel = new StudentViewModel();
                studentViewModel.StudentName = item.StudentName;
                studentViewModel.StudentPhoneNumber = item.StudentPhoneNumber;
                studentViewModel.StudentEmail = item.StudentEmail;
                studentViewModel.RollNo= item.RollNo;
                studentViewModellist.Add(studentViewModel);
            }
            return View(studentViewModellist);
        }
    }
}