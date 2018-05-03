using Xunit;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FINT.Model.Resource.Test
{
  public class AbstractCollectionResourcesTest
  {
    PersonResources personResources;
    public AbstractCollectionResourcesTest()
    {
      personResources = new PersonResources();
      personResources.AddResource(new PersonResource { Name = "test1" });
      personResources.AddResource(new PersonResource { Name = "test2" });
    }

    [Fact]
    public void Get_Total_items()
    {
      Assert.Equal(2, personResources.TotalItems);
    }

    [Fact]
    public void Serialize_Deserialize_PersonResources_getContent()
    {
      var json = JsonConvert.SerializeObject(personResources, Formatting.Indented);
      var deserialized = JsonConvert.DeserializeObject<PersonResources>(json);
      var deserializedContent = deserialized.GetContent();
      var names = deserializedContent.ConvertAll(p => p.Name);

      Assert.Equal(2, deserializedContent.Count);
      Assert.True(names.Contains("test1"));
      Assert.True(names.Contains("test2"));
    }

  }
}