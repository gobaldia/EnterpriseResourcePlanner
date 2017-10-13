using BusinessLogic.Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class SubjectLogic
    {
        private List<Subject> systemSubjects = SystemData.GetInstance.GetSubjects();

        public List<Subject> GetSubjects()
        {
            return this.systemSubjects;
        }
    }
}
