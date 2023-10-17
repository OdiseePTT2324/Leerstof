using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper
{
    public interface IGradeRepository
    {
        void AddScore(Student student, int score);

        void ClearScore(Student student);

        List<int> GetGrades(Student student);

        int GetTotalScore(Student student);
    }

    public class GradeRepository: IGradeRepository
    {
        private readonly StudentsDbContext studentsDbContext;

        public GradeRepository()
        {
            this.studentsDbContext = new StudentsDbContext();
        }

        public void AddScore(Student student, int score)
        {
            studentsDbContext.Students.First(s => s.Id == student.Id).Scores.Add(score);

        }

        public void ClearScore(Student student)
        {
            studentsDbContext.Students.First(s => s.Id == student.Id).Scores.Clear();
        }

        public List<int> GetGrades(Student student)
        {
            return studentsDbContext.Students.First(s => s.Id == student.Id).Scores;
        }

        public int GetTotalScore(Student student)
        {
            return studentsDbContext.Students.First(s => s.Id == student.Id).Scores.Sum();
        }
    }
}
