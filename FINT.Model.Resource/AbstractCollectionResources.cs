using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FINT.Model.Resource
{
    public abstract class AbstractCollectionResources<T>
    {
        [JsonProperty(PropertyName = "_links")]
        protected readonly Dictionary<string, List<Link>> Links = new Dictionary<string, List<Link>>();

        [JsonProperty(PropertyName = "_embedded")]
        protected EmbeddedResources<T> Embedded = new EmbeddedResources<T>();

        [JsonProperty(PropertyName = "total_items")]
        public int TotalItems { get; set; }


        [OnSerialized]
        internal void OnSerializedMethod(StreamingContext context)
        {
            TotalItems = Embedded.Entries.Count;
        }

        public void AddResource(T resource)
        {
            Embedded.Entries.Add(resource);
        }

        public List<Link> GetSelfLinks()
        {
            return Links["self"];
        }

        public List<T> GetContent()
        {
            return Embedded.Entries;
        }

        public class EmbeddedResources<T>
        {
            public EmbeddedResources()
            {
                Entries = new List<T>();
            }

            [JsonProperty(PropertyName = "_entries")]
            public List<T> Entries { get; set; }
        }
    }
}