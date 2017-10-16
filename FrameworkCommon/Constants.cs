using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCommon
{
    public static class Constants
    {
        public const string ERROR_UNEXPECTED = "Unexpected error.";
        public const string ERROR_ALL_FIELDS_REQUIRED = "You must fill all fields.";
        public const string ERROR_DOCUMENTNUMBER_REQUIRED = "Document number required.";
        public const string ERROR_NOTEACHERFOUND = "No teacher found to delete.";

        public const string SUCCESS_TEACHERREGISTRATION = "Teacher registered with success.";
        public const string SUCCESS_TEACHER_DELETED = "Teacher deleted with success.";
        public const string SUCCESS_TEACHER_MODIFICATION = "Teacher modification succcess.";

        public const string ERROR_STUDENT_INFO_REQUIRED = "Student information required.";
        public const string ERROR_SUBJECTS_REQUIRED = "At least one subject required.";
        public const string ERROR_VALIDCOORDENATES_REQUIRED = "Valid coordenates are required.";
        public const string SUCCESS_STUDENT_REGISTRATION = "Student registered with success.";
        public const string SUCCESS_STUDENT_MODIFICATION = "Student succesfully modified.";
        public const string ERROR_INVALID_STUDENTNUMBER = "Invalid student number.";
        public const string ERROR_NOSTUDENTFOUND = "Student not found.";
    }
}
