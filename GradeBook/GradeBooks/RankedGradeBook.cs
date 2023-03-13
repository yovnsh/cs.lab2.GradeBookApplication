using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeighted) : base(name, IsWeighted)
        {
            Type = GradeBookType.Ranked; 
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            int top20Percent = (int)Math.Ceiling(Students.Count * 0.2);

            int higherCount = 0;
            foreach (var Student in Students)
            {
                if (Student.AverageGrade > averageGrade)
                {
                    higherCount++;
                }
            }

            if (higherCount < top20Percent)
            {
                return 'A';
            }
                else if (higherCount < top20Percent * 2)
                {
                    return 'B';
                }
                    else if (higherCount < top20Percent * 3)
                    {
                        return 'C';
                    }
                        else if (higherCount < top20Percent * 4)
                        {
                            return 'D';
                        }
                            else
                            {
                                return 'F';
                            }
        }

        public override void CalculateStatistics()
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}