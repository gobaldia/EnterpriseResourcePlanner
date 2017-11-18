using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public interface ITeacherPersistance
    {
        void AddTeacher(Teacher newTeacher);
        void ModifyTeacher(Teacher teacherToModify);
        void DeleteTeacher(Teacher teacherToModify);
        List<Teacher> GetTeachers(bool bringSubjects = false);
        Teacher GetTeacherByDocumentNumber(string documentNumber);
    }
}