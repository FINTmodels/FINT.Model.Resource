using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FINT.Model.Resource
{
    // TODO: Don't know how to do this since C# is not supporting default implementations
    public interface IFintLinks
    {
        Dictionary<string, List<Link>> GetLinks();

        [JsonProperty(PropertyName = "_links")]
        Dictionary<string, List<Link>> Links { get; set; }

        [OnSerialized]
        void OnSerializedMethod(StreamingContext context)
        {
            if (GetLinks().Count == 0)
            {
                Links = null;
            }

            Links = GetLinks();
        }

        [OnDeserialized]
        void OnDeserializedMethod(StreamingContext context)
        {
            if (Links == null) return;
            
            foreach (var link in Links)
            {
                GetLinks().Add(link.Key, link.Value);
            }
        }

        void AddLink(string key, Link link)
        {
            if (GetLinks().ContainsKey(key)) return;
            
            GetLinks().Add(key, new List<Link>());
            GetLinks()[key].Add(link);
        }

        Dictionary<string, List<Link>> CreateLinks()
        {
            return new Dictionary<string, List<Link>>();
        }

        List<IFintLinks> GetNestedResources()
        {
            return new List<IFintLinks>();
        }

        List<Link> GetSelfLinks()
        {
            return GetLinks()["self"];
        }

 
    }
}