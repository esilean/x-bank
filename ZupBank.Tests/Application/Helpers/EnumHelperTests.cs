using System.Runtime.Serialization;
using Xunit;
using ZupBank.Application.Helpers;

namespace ZupBank.Tests.Application.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumHelperTests
    {
        public enum FooBar
        {
            [EnumMember(Value = "FOO")]
            Foo,
            [EnumMember(Value = "BAR")]
            Bar
        }

        [Fact]
        public void EnumHelperGetValueFromEnumMember_OK()
        {
            var value = EnumHelper.GetValueFromEnumMember<FooBar>("FOO");
            Assert.Equal(FooBar.Foo, value);
        }

        [Fact]
        public void EnumHelperGetDescription_OK()
        {
            var value = EnumHelper.GetDescription(FooBar.Foo);

            Assert.NotNull(value);
            Assert.Equal("FOO", value);
        }
    }
}
