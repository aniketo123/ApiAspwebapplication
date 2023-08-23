using Core.CoreModel;
using Core.DeepCopyServices;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CoreStudentServices
    {
        StudentContext context;
        StudentDeepCopyServices studentDeepCopy = new StudentDeepCopyServices();
        public CoreStudentServices()
        {
            context = new StudentContext();
        }
        public List<StudentDto>GetStudents()
        {
            var Studentlist = context.StudentRecord.ToList();
            //StudentDeepCopyServices studentDeepCopy=new StudentDeepCopyServices();
            var studentcoretodto = studentDeepCopy.CoreToDto(Studentlist);
            return studentcoretodto;
        }
        public bool CreateStudent(StudentDto student)
        {
            var CoreStudent = new DeepCopyServices.StudentDeepCopyServices().DTOtoCore(student);
            context.StudentRecord.Add(CoreStudent);
            context.SaveChangesAsync();
            return true;
        }
        public bool DeleteStudent(StudentDto student)
        {
            var deleteStudent= context.StudentRecord.Where(x=>x.StudentId==student.StudentId).FirstOrDefault();
            context.StudentRecord.Remove(deleteStudent);
            context.SaveChangesAsync();
            return true;
        }
        public StudentDto FillStudentdata(int Id)
        {
            var Editstudentcore=context.StudentRecord.Where(x=>x.StudentId==Id).FirstOrDefault();
            var EditStudentDto = studentDeepCopy.EditCoreToDto(Editstudentcore);
            return EditStudentDto;
        }
        public bool Updatestudent(StudentDto student)
        {
            var corestudent=context.StudentRecord.Where(x=>x.StudentId==student.StudentId).FirstOrDefault();
            corestudent.StudentName = student.StudentName;
            corestudent.StudentPhoneNumber = student.StudentPhoneNumber;
            corestudent.StudentEmail = student.StudentEmail;
            context.SaveChangesAsync();
            return true;
        }
        public List<StudentDto> SearchStudent(StudentDto student)
        {
            var corestudent=context.StudentRecord.Where(x=>x.StudentName==student.StudentName).ToList();
            var studentcoretodto = studentDeepCopy.CoreToDto(corestudent);
            return studentcoretodto;
        }
    }
}
