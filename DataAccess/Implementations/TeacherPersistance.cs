using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities.Entities;

namespace DataAccess.Implementations
{
    public class TeacherPersistance : ITeacherPersistance
    {
        public void AddTeacher(Teacher newTeacher)
        {
            using (Context context = new Context())
            {
                context.teachers.Add(newTeacher);
                context.SaveChanges();
            }
        }

        public void DeleteTeacher(Teacher teacherToModify)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetAllTeacher()
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherByDocumentNumber(string documentNumber)
        {
            throw new NotImplementedException();
        }

        public void ModifyTeacher(Teacher teacherToModify)
        {
            throw new NotImplementedException();
        }
    }
}
