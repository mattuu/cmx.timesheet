using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmx.Timesheet.TestUtils.Attributes;
using Ploeh.AutoFixture.Idioms;
using Xunit;

namespace Cmx.Timesheet.DataAccess.Tests
{
    public class WorkDayDataStoreTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(WorkDayDataStore).GetConstructors());
        }

        //[Theory, AutoMoqData]
        //public async Task SaveWorkDay
    }
}
