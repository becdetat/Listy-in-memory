using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listy.Core.Invariants;
using Listy.Data.Entities;
using Shouldly;
using Xunit;

namespace Listy.Tests.Data.Entities.ListyListItemTests
{
    public class SettingTheOrdinal
        : ConcernFor<ListyListItem>
    {
        protected override ListyListItem Given()
        {
            return new ListyListItem();
        }

        [Fact]
        public void SettingTheOrdinalToZeroSucceeds()
        {
            Subject.SetOrdinal(0);

            Subject.Ordinal.ShouldBe(0);
        }

        [Fact]
        public void SettingTheOrdinalToFiveSucceeds()
        {
            Subject.SetOrdinal(5);

            Subject.Ordinal.ShouldBe(5);
        }

        [Fact]
        public void SettingTheOrdinalToNegativeOneThrows()
        {
            Should.Throw<InvariantException>(() => Subject.SetOrdinal(-1));
        }
    }
}
