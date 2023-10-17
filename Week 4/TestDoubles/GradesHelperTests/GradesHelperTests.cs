using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradesHelper;

namespace GradesHelperTests
{
    internal class GradesHelperTests
    {
        [Test]
        public void CalcAverageGrade_WtihFixedScores_ReturnCorrectAverage()
        {
            // Arrange
            IGradeRepository stub = new GradesRepositoryStub();
            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(stub);
            // hierboven zeggen we tegen de gradeshelper: gebruik onze eigen klasse ipv de database
            // in de eigen klasse hebben we gezegd: return steeds {5, 10, 15}
            Student s = null;

            // Act
            double score = sut.CalcAverageGrade(s);

            // Assert
            Assert.That(score, Is.EqualTo(10));
        }

        [Test]
        public void DidStudentPerformBetterWithNewScore_WithHigherScore_ReturnTrue()
        {
            // Arrange
            IGradeRepository fake = new GradesRepositoryFake();
            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(fake);
            Student s = null;

            // Act
            // Deze functie begint met 5, 10, 15 in de scorelijst
            // De add voegt er 20 aan toe
            bool result = sut.DidStudentPerformBetterWithNewScore(s, 20);

            // Assert
            Assert.That(result, Is.True);
        }


        [Test]
        public void RemoveAllScores_ClearScoreInRepositoryCalled()
        {
            // Arrange
            IGradeRepository mock = new GradesRepositoryMock();
            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(mock);
            Student s = null;

            // Act
            sut.RemoveAllScores(s);

            // Assert
            Assert.Fail();
        }


        [Test]
        public void RemoveAllScores_ClearScoreInRepositoryCalled_WithSpy()
        {
            // Arrange
            IGradeRepository spy = new GradesRepositorySpy();
            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(spy);
            Student s = null;

            // Act
            sut.RemoveAllScores(s);

            // Assert
            // verbetering ten opzicht van mock want je ziet hier in de test wat er gecontroleerd wordt.
            Assert.That(((GradesRepositorySpy)spy).IsClearScoreCalled, Is.True);
        }
    }
}
