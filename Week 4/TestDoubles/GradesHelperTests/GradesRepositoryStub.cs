using GradesHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelperTests
{
    public class GradesRepositoryStub : IGradeRepository
    {
        public void AddScore(Student student, int score)
        {
            throw new NotImplementedException();
        }

        public void ClearScore(Student student)
        {
            throw new NotImplementedException();
        }

        public List<int> GetGrades(Student student)
        {
            return new List<int>(){ 5, 10, 15};
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
