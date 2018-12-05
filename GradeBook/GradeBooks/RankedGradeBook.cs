using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked Grading must have at least 5 students to work");

            // Figure out how many students I must score lower than before dropping a grade

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);  //used for index, hence the int
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();  //order by average grade

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[threshold - 2] <= averageGrade)
                return 'B';
            else if (grades[threshold - 3] <= averageGrade)
                return 'C';
            else if (grades[threshold - 4] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
