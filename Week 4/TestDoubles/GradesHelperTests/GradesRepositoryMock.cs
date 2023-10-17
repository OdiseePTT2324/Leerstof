using GradesHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelperTests
{
    internal class GradesRepositoryMock : IGradeRepository
    {
        public void AddScore(Student student, int score)
        {
            throw new NotImplementedException();
        }

        public void ClearScore(Student student)
        {
            Assert.Pass();
        }

        public List<int> GetGrades(Student student)
        {
            throw new NotImplementedException();
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
