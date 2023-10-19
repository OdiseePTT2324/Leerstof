using GradesHelper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelperTestsNSubstitute
{
    internal class GradeRepositoryTests
    {
        List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id  =1,
                    FirstName = "John",
                    LastName = "Doe",
                    Scores = new List<int>(){1,2,3,4,5}
                },new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Scores = new List<int>(){5,6,7,8,9}
                }
            };

        [Test]
        public void GetGrades_ReturnAllGrades()
        {
            // Arrange
            // Maak een substitute voor de dbset (1 keer onderstaande per dbset die je gebruikt)
            var studentDbSet = Substitute.For<DbSet<Student>, IQueryable<Student>>();
            ((IQueryable<Student>)studentDbSet).Provider.Returns(students.AsQueryable().Provider);
            ((IQueryable<Student>)studentDbSet).Expression.Returns(students.AsQueryable().Expression);
            ((IQueryable<Student>)studentDbSet).GetEnumerator().Returns(students.AsQueryable().GetEnumerator());

            // dit geeft moeilijkheden zonder de speciale zaken van hierboven
            var dbContext = Substitute.For<StudentsDbContext>();
            dbContext.Students.Returns(studentDbSet);

            GradeRepository sut = new GradeRepository(dbContext);

            // Act
            List<int> grades = sut.GetGrades(students[0]);

            // Assert
            Assert.That(grades, Is.EqualTo(students[0].Scores));
        }
        
        // Zelfde als hierboven maar met gebruik van de functie in NSubstitute Utils
        [Test]
        public void GetGrades_ReturnAllGrades2()
        {
            // Arrange
            // Maak een substitute voor de dbset (1 keer onderstaande per dbset die je gebruikt)
            var studentDbSet = NSubstituteUtils.GenerateMockDbSet<Student>(students);

            // dit geeft moeilijkheden zonder de speciale zaken van hierboven
            var dbContext = Substitute.For<StudentsDbContext>();
            dbContext.Students.Returns(studentDbSet);

            GradeRepository sut = new GradeRepository(dbContext);

            // Act
            List<int> grades = sut.GetGrades(students[0]);

            // Assert
            Assert.That(grades, Is.EqualTo(students[0].Scores));
        }
    }
}
