using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace FINT.Model.Resource.Test
{
    public class LinkTest
    {
        public LinkTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly ITestOutputHelper output;

        [Fact]
        public void Create_Link_with_Person_placeholder()
        {
            var link = Link.with(typeof(Person), "/id");

            Assert.Equal("${test.person}/id", link.href);
        }

        [Fact]
        public void Create_Link_with_PersonResource_placeholder()
        {
            var link = Link.with(typeof(PersonResource), "/id");

            Assert.Equal("${test.person}/id", link.href);
        }

        [Fact]
        public void Serialise_Link_with_Person_placeholder()
        {
            var link = Link.with(typeof(Person), "/id");

            Assert.Equal("${test.person}/id", link.href);

            output.WriteLine(ObjectDumper.Dump(link));
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };
            var json = JsonConvert.SerializeObject(link, settings);

            output.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<Link>(json);
            output.WriteLine(ObjectDumper.Dump(deserializeObject));
            Assert.NotNull(deserializeObject.href);
            Assert.Equal(link.href, deserializeObject.href);
        }
    }
}