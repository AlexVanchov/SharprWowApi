using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharprWowApi.Models.Character.AuditModel;

namespace SharprWowApi.Models.Character
{
    /// <summary>
    /// The Character Profile API is the primary way to access character information.
    /// </summary>
    /// 
	[DataContract]
    public class CharacterRoot
    {
        //public CharacterRoot(string json)
        //{
        //    JObject jObject = JObject.Parse(json);
        //    //JToken jObj = jObject["user"];
        //    this.Name = (string)jObject["name"];
        //    this.Realm = (string)jObject["realm"];
        //    this.Id = (int)jObject["id"];
        //    //players = jUser["players"].ToArray();
        //}
        /// <summary>
        /// Gets or setsTimestamp that shows when the character API was last updated.
        /// </summary>

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }
    }
}
