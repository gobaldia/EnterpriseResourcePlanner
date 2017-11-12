using CoreEntities.Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Utilities
{
    public class Utility
    {
        private static string[] maleNames = new string[5] { "Alfred", "Tony", "Bart", "Peter", "Jhon" };
        private static string[] femaleNames = new string[5] { "Carol", "Jennifer", "Storm", "Leia", "Jessica" };
        private static string[] lastNames = new string[5] { "Richards", "Kovacs", "Wayne", "Johnes", "Stark" };
        private static string[] documents = new string[5] { "1234567-8", "3216549-8", "7418529-6", "9638527-4", "1596324-7" };
        private static string[] subjectNames = new string[5] { "Maths", "Physics", "Chemistry", "Geography", "History" };

        public static bool CompareLists<T>(List<T> real, List<T> toBeCompareWith) 
            where T : class
        {
            bool result = real.Count == toBeCompareWith.Count;
            for (var index = 0; (index < real.Count || !result); index++)
            {
                result = real.ElementAt(index).Equals(toBeCompareWith.ElementAt(index));
            }
            return result;
        }

        public static string GetRandomName()
        {
            Random randomNumber = new Random(DateTime.Now.Second);
            string name = string.Empty;
            if (randomNumber.Next(1, 2) == 1)
                name = maleNames[randomNumber.Next(0, maleNames.Length - 1)];
            else
                name = femaleNames[randomNumber.Next(0, femaleNames.Length - 1)];

            return name;
        }

        public static string GetRandomLastName()
        {
            Random randomNumber = new Random(DateTime.Now.Second);
            return lastNames[randomNumber.Next(0, lastNames.Length - 1)];
        }

        public static string GetRandomDocument()
        {
            Random randomNumber = new Random(DateTime.Now.Second);
            return documents[randomNumber.Next(0, documents.Length - 1)];
        }

    }
}
