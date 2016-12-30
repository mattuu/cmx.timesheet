using Cmx.Timesheet.TestUtils.Attributes;
using Ploeh.AutoFixture.Idioms;
using Xunit;

namespace Cmx.Timesheet.Mappings.Tests
{
    public class AutoMapperMapTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull<TFrom, TTo>(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AutoMapperMap<TFrom, TTo>).GetConstructors());
        }
    }
}