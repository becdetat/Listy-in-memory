using System;
using Listy.Core.Invariants;
using Shouldly;
using Xunit;

namespace Listy.Tests.Core.Invariants.GuardTests
{
    public class GuardAgainstTests
    {
        [Fact]
        public void WhenExpressionPasses_NoExceptionIsThrown()
        {
            Should.NotThrow(() => Guard.Against(() => false));
        }

        [Fact]
        public void WhenExpressionDoesNotPass_DomainExceptionIsThrown()
        {
            Should.Throw<InvariantException>(() => Guard.Against(() => true));
        }

        [Fact]
        public void WhenExpressionDoesNotPassOnSimpleBool_ExceptionMessageIsNotTooShabby()
        {
            var exception = Should.Throw<InvariantException>(() => Guard.Against(() => true));

            exception.Message.ShouldBe("Invariant failed - guard against: True");
        }

        [Fact]
        public void WhenExpressionDoesNotPassOnSimpleBoolComparison_ExceptionMessageIsCollapsedProbablyFromTheCompiler()
        {
            var exception = Should.Throw<InvariantException>(() => Guard.Against(() => true == true));

            exception.Message.ShouldBe("Invariant failed - guard against: True");
        }

        [Fact]
        public void WhenExpressionDoesNotPassOnGuidComparison_ExceptionMessageIsSexyNo()
        {
            var id = Guid.Empty;
            var exception = Should.Throw<InvariantException>(() => Guard.Against(() => id == Guid.Empty));

            exception.Message.ShouldBe("Invariant failed - guard against: (id == Guid.Empty)");
        }
    }
}