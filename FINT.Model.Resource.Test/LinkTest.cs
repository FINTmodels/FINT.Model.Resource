using Xunit;

namespace FINT.Model.Resource.Test
{
    public class LinkTest
    {
        [Fact]
        public void Create_Link_with_PersonResource_placeholder()
        {
            var link = Link.with(typeof(PersonResource), new string[] { "/id" });

            Assert.Equal(link.href, "${test.person}/id");
        }

        [Fact]
        public void Create_Link_with_Person_placeholder()
        {
            var link = Link.with(typeof(Person), new string[] { "/id" });

            Assert.Equal(link.href, "${test.person}/id");
        }
    }
}