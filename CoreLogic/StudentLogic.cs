using CoreEntities.Entities;
using CoreEntities.Exceptions;
using DataAccess;
using FrameworkCommon.MethodParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic
{
    public class StudentLogic
    {
        private List<Student> systemStudents = SystemData.GetInstance.GetStudents();

        public void AddStudent(AddStudentInput input)
        {
            Student newStudent = new Student(input.Name, input.LastName, input.DocumentNumber);
            if (this.IsStudentInSystem(newStudent))
                throw new CoreException("Student already exists.");

            AddStudentSubjects(newStudent, input.Subjects);

            if(input.Location != null)
            {
                newStudent.SetPickUpService(true);
                newStudent.SetLocation(input.Location);
            }

            this.systemStudents.Add(newStudent);
        }

        public Student GetStudentByDocumentNumber(string documentNumber)
        {
            Student studentFound = this.systemStudents.Find(item => item.GetDocumentNumber().Equals(documentNumber));
            if (studentFound == null)
                throw new CoreException("Student not found.");

            return studentFound;
        }

        public void ModifyStudent(ModifyStudentInput input)
        {
            Student studentToModify = GetStudentByNumber(input.StudentNumber);

            bool nameWasModified = ModifyName(studentToModify, input.NewName);
            bool lastNameWasModified = ModifyLastName(studentToModify, input.NewLastName);
            bool subjectsWereModified = ModifySubjects(studentToModify, input.NewSubjects);

            studentToModify.SetPickUpService(input.HavePickupService);
            bool locationHaveChange = ModifyLocation(studentToModify, input.NewLocation);

            if (!nameWasModified && !lastNameWasModified && !subjectsWereModified && !locationHaveChange)
                throw new CoreException("No modifications have been made.");
        }

        public Student GetStudentByNumber(int studentNumber)
        {
            Student studentFound = this.systemStudents.Find(item => item.GetStudentNumber().Equals(studentNumber));
            if (studentFound == null)
                throw new CoreException("Student not found.");

            return studentFound;
        }

        #region Utility methods
        private bool IsStudentInSystem(Student aStudent)
        {
            return this.systemStudents.Exists(item => item.Equals(aStudent));
        }
        private void AddStudentSubjects(Student aStudent, List<Subject> subjectsToAdd)
        {
            if (subjectsToAdd != null)
            {
                foreach (Subject subject in subjectsToAdd)
                    aStudent.AddSubjectToStudent(subject);
            }
        }
        private bool ModifyName(Student studentToModify, string newName)
        {
            bool wasModifed = false;
            if (!studentToModify.GetName().Equals(newName))
            {
                studentToModify.SetName(newName);
                wasModifed = true;
            }
            return wasModifed;
        }
        private bool ModifyLastName(Student studentToModify, string newLastName)
        {
            bool wasModifed = false;
            if (!studentToModify.GetLastName().Equals(newLastName))
            {
                studentToModify.SetLastName(newLastName);
                wasModifed = true;
            }
            return wasModifed;
        }
        private bool ModifySubjects(Student studentToModify, List<Subject> newSubjects)
        {
            bool wasModified = false;
            List<Subject> studentSubjects = studentToModify.GetSubjects();
            if (CheckIfSubjectsHaveChange(newSubjects, studentSubjects))
            {
                studentToModify.ModifySubjects(newSubjects);
                wasModified = true;
            }
            return wasModified;
        }
        private bool CheckIfSubjectsHaveChange(List<Subject> newSubjects, List<Subject> studentSubjects)
        {
            return newSubjects != null && !newSubjects.SequenceEqual(studentSubjects);
        }
        private bool ModifyLocation(Student studentToModify, Location newLocation)
        {
            bool locationWasModified = false;

            if (LocationsAreDifferent(studentToModify, newLocation))
            {
                studentToModify.SetLocation(newLocation);
                locationWasModified = true;
            }

            return locationWasModified;
        }
        private bool LocationsAreDifferent(Student studentToModify, Location newLocation)
        {
            bool result = false;

            if (newLocation == null && studentToModify.GetLocation() != null)
                result = true;
            else if (newLocation != null && studentToModify.GetLocation() == null)
                result = true;
            else if (BothLocationNotNull(studentToModify, newLocation) &&
                !newLocation.Equals(studentToModify.GetLocation()))
            {
                result = true;
            }   

            return result;
        }        
        private bool BothLocationNotNull(Student studentToModify, Location newLocation)
        {
            return newLocation != null && studentToModify.GetLocation() != null;
        }
        #endregion
    }
}
