using Xunit;

namespace FINT.Model.Resource.Test
{
    public class LinkTest
    {
        [Fact]
        public void Create_Link_with_PersonResource_placeholder()
        {
            var link = Link.with(typeof(PersonResource), "/id");

            Assert.Equal("${test.person}/id", link.href);
        }

        [Fact]
        public void Create_Link_with_Person_placeholder()
        {
            var link = Link.with(typeof(Person), "/id");

            Assert.Equal("${test.person}/id", link.href);
        }
    }
}