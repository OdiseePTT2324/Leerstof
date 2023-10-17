using GradesHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelperTests
{
    internal class GradesRepositoryFake : IGradeRepository
    {
        private List<int> scores = new List<int>() { 5, 10, 15};

        public void AddScore(Student student, int score)
        {
            scores.Add(score);
        }

        public void ClearScore(Student student)
        {
            throw new NotImplementedException();
        }

        public List<int> GetGrades(Student student)
        {
            return scores;
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
