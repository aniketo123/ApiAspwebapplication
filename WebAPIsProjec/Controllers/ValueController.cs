using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto;
using Infra;
using WebAPIsProjec.Models;

namespace WebAPIsProjec.Controllers
{
    public class ValueController : ApiController
    {
        Studentinfra obj = new Studentinfra();

        // GET studentList
        public List<Dto.StudentDto> Get()
        {
            var students = obj.GetStudents();
            // return students;
            return students;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Create>
        public void Post([FromBody] StudentViewModel stuentViewModel)
        {
            var student = new StudentDto();
            {
                student.StudentName = stuentViewModel.StudentName;
                student.StudentPhoneNumber = stuentViewModel.StudentPhoneNumber;
                student.StudentEmail = stuentViewModel.StudentEmail;
                student.RollNo = stuentViewModel.RollNo;
            };

            obj.CreateStudent(student);
           
        }

        // PUT api/<Edit>/5
        public void Put(StudentViewModel studentViewModel)
        {
            var studentDto = new StudentDto();
            {
                studentDto.StudentName = studentViewModel.StudentName;
                studentDto.StudentPhoneNumber = studentViewModel.StudentPhoneNumber;
                studentDto.StudentId = studentViewModel.StudentId;
                studentDto.StudentEmail = studentViewModel.StudentEmail;
                studentDto.RollNo = studentViewModel.RollNo;
            }
           
            obj.Updatestudent(studentDto);
        }

        // DELETE api/<Delete>/5
        public void Delete(StudentDto studentDto)
        {
            obj.DeleteStudent(studentDto);
        }
    }
}