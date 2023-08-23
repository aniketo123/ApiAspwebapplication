using Core;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class Studentinfra
    {
        CoreStudentServices coreStudentServices;
        public Studentinfra() 
        { 
            coreStudentServices = new CoreStudentServices();
        }
        public List<StudentDto>GetStudents()
        {
            return coreStudentServices.GetStudents();
        }
        public bool CreateStudent(StudentDto student)
        {
            return coreStudentServices.CreateStudent(student);
        }
        public bool DeleteStudent(StudentDto student)
        {
            return coreStudentServices.DeleteStudent(student);
        }
        public StudentDto FillStudentdata(int Id)
        {
            return coreStudentServices.FillStudentdata(Id);
        }
        public bool Updatestudent(StudentDto studentDto)
        {
            return coreStudentServices.Updatestudent(studentDto);
        }
        public List<StudentDto> SearchStudent(StudentDto studentDto)
        {
            return coreStudentServices.SearchStudent(studentDto);
        }
    }
}
