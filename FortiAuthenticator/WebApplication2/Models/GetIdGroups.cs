using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class GetIdGroups
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}