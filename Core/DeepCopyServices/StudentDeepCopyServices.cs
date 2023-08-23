using Core.CoreModel;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DeepCopyServices
{
    public class StudentDeepCopyServices
    {
        public List<StudentDto> CoreToDto(List<StudentCoreModel>studentCoreModels)
        {
            List<StudentDto> studentDtosList = new List<StudentDto>();
            foreach(var item in studentCoreModels)
            {
                StudentDto studentDto = new StudentDto();
                studentDto.StudentName = item.StudentName;
                studentDto.StudentId = item.StudentId;
                studentDto.StudentEmail = item.StudentEmail;
                studentDto.StudentPhoneNumber = item.StudentPhoneNumber;
                studentDto.RollNo = item.RollNo;
               studentDtosList.Add(studentDto);
            }
            return studentDtosList;
        }
        public StudentCoreModel DTOtoCore(StudentDto student)
        {
            StudentCoreModel studentCoreModel = new StudentCoreModel();
            studentCoreModel.StudentName = student.StudentName;
            studentCoreModel.StudentEmail = student.StudentEmail;
            studentCoreModel.StudentPhoneNumber = student.StudentPhoneNumber;
            studentCoreModel.RollNo = student.RollNo;
            return studentCoreModel;
        }
        public StudentDto EditCoreToDto(StudentCoreModel studentCoreModel)
        {
            StudentDto student= new StudentDto();
            student.StudentId = studentCoreModel.StudentId;
            student.StudentName = studentCoreModel.StudentName;
            student.StudentPhoneNumber = studentCoreModel.StudentPhoneNumber;
            student.StudentEmail = studentCoreModel.StudentEmail;
            student.RollNo = studentCoreModel.RollNo;
            return student;
        }
    }
}
