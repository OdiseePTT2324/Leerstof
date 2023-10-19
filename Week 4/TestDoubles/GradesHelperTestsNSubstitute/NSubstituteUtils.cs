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
    internal class NSubstituteUtils
    {
        public static DbSet<T> GenerateMockDbSet<T>(List<T> data) where T : class
        {
            var mockDbSet = Substitute.For<DbSet<T>, IQueryable<T>>();
            ((IQueryable<T>)mockDbSet).Provider.Returns(data.AsQueryable().Provider);
            ((IQueryable<T>)mockDbSet).Expression.Returns(data.AsQueryable().Expression);
            ((IQueryable<T>)mockDbSet).GetEnumerator().Returns(data.AsQueryable().GetEnumerator());

            return mockDbSet;
        }
    }
}
