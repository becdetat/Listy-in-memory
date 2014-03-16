using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listy.Core.Invariants;
using Shouldly;
using Xunit;

namespace Listy.Tests.Core.Invariants.GuardTests
{
    public class GuardForTests
    {
        [Fact]
        public void WhenExpressionPasses_NoExceptionIsThrown()
        {
            Should.NotThrow(() => Guard.For(() => true));
        }

        [Fact]
        public void WhenExpressionDoesNotPassOnStringComparison_ExceptionMessageWinsTheHeartsOfMillions()
        {
            var name = "";

            var exception = Should.Throw<InvariantException>(() => Guard.For(() => name != ""));

            exception.Message.ShouldBe("Invariant failed - guard for: (name != \"\")");
        }

        [Fact]
        public void WhenExpressionDoesNotPassOnMethodReturn_ExceptionMessageCleansesTheSpirit()
        {
            var name = "Aardvark";

            var exception = Should.Throw<InvariantException>(() => Guard.For(() => name.StartsWith("B")));

            exception.Message.ShouldBe("Invariant failed - guard for: name.StartsWith(\"B\")");
        }
    }
}
