using GradesHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelperTests
{
    internal class GradesRepositorySpy : IGradeRepository
    {
        public GradesRepositorySpy() { 
            IsClearScoreCalled = false;
        }

        public bool IsClearScoreCalled { get; private set; }

        public void AddScore(Student student, int score)
        {
            throw new NotImplementedException();
        }

        public void ClearScore(Student student)
        {
            IsClearScoreCalled = true;
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
