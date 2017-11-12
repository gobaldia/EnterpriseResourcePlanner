using CoreEntities.Entities;
using FrameworkCommon.MethodParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Interfaces
{
    public interface ITeacherLogic
    {
        void AddTeacher(Teacher newTeacher);
        Teacher GetTeacherByDocumentNumber(string documentNumber);
        void DeleteTeacher(Teacher teacherToDelete);
        void ModifyTeacher(ModifyTeacherInput input);
        List<Teacher> GetAllTeachers();
    }
}
