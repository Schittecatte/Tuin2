using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class GetUserGroups
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string GroupName { get; set; }

        //get usergroups
        public class UserGroups
        {
            public List<GetUserGroups> Objects { get; set; }
        }
    }
}