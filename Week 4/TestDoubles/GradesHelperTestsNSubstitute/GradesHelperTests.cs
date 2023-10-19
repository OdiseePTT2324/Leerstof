using GradesHelper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace GradesHelperTestsNSubstitute
{
    [TestFixture]
    internal class GradesHelperTests
    {
        // Dit vervangt de stub
        [Test]
        public void CalcAverageGrade_WtihFixedScores_ReturnCorrectAverage()
        {
            // Arrange
            // Met substitute for maken we eigenlijk de stub testdouble
            var gradeRepository = Substitute.For<IGradeRepository>();
            // bepaal nu het gedrag van de test double
            // bvb als de GetGrades wordt opgeroepen return de lijst
            // let op het argument van de GetGrades. Hij gaat de return enkel doen als het argument klopt
            // als het niet uitmaakt kies default en returns for any args
            gradeRepository.GetGrades(default).ReturnsForAnyArgs(new List<int>() { 5, 10, 15 });

            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(gradeRepository);
            Student s = null;

            // Act
            double score = sut.CalcAverageGrade(s);

            // Assert
            Assert.That(score, Is.EqualTo(10));
        }

        // Dit vervangt de fake
        [Test]
        public void DidStudentPerformBetterWithNewScore_WithHigherScore_ReturnTrue()
        {
            // Arrange
            var gradeRepository = Substitute.For<IGradeRepository>();
            List<int> grades = new List<int>() { 5, 10, 15 };
            Student s = null;
            int score = 20;
            // LET OP dat je lambda expressie gebruikt x => ipg gewoon grades
            // anders heb je niet noodzakelijk de laatste update mee
            gradeRepository.GetGrades(s).Returns(x => grades);
            // dit doet de AddScore van de fake
            // in de do hebben we de score nodig. Dit is het tweede element (dus index 1) van de functieoproep
            // met ArgAt krijgen we deze score en we voegen het toe aan de lijst grades

            gradeRepository.When(x => x.AddScore(s, score)).Do(x => grades.Add(x.ArgAt<int>(1)));

            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(gradeRepository);

            // Act
            // Deze functie begint met 5, 10, 15 in de scorelijst
            // De add voegt er 20 aan toe
            bool result = sut.DidStudentPerformBetterWithNewScore(s, score);

            // Assert
            Assert.That(result, Is.True);
        }

        // Mock (gebruik liever spy)
        [Test]
        public void RemoveAllScores_ClearScoreInRepositoryCalled()
        {
            // Arrange
            var gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(gradeRepository);
            Student s = null; 
            gradeRepository.When(x => x.ClearScore(s)).Do(x => Assert.Pass());


            // Act
            sut.RemoveAllScores(s);

            // Assert
            Assert.Fail();
        }


        // Spy
        [Test]
        public void RemoveAllScores_ClearScoreInRepositoryCalled2()
        {
            // Arrange
            var gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(gradeRepository);
            Student s = null;


            // Act
            sut.RemoveAllScores(s);

            // Assert
            // hiermee zeg je je hebt 1 keer de ClearScore functie opgeroepen met een willekeurige student
            // doet het aantal er niet toe, dan doe je de 1 weg
            gradeRepository.Received(1).ClearScore(Arg.Any<Student>());
            // Dit is het omgekeerde (functie niet opgeroepen)
            //gradeRepository.DidNotReceive().ClearScore(Arg.Any<Student>());
        }

        [Test]
        public void AddScore_WithInvalidData_ExceptionThrowsAndAddScoreNotCalled()
        {
            // Arrange
            var gradeRepository = Substitute.For<IGradeRepository>();
            List<int> grades = new List<int>() { 5, 10, 15 };
            Student s = null;
            int score = -5;

            gradeRepository.GetGrades(s).Returns(x => grades);
            gradeRepository.When(x => x.AddScore(s, score)).Do(x => grades.Add(x.ArgAt<int>(1)));

            GradesHelper.GradesHelper sut = new GradesHelper.GradesHelper(gradeRepository);

            // Act
            Assert.Throws<Exception>(() => sut.AddScore(s, score));

            // Assert
            gradeRepository.DidNotReceive().AddScore(Arg.Any<Student>(), score);
        }

    }
}
