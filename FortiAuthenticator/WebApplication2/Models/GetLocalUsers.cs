using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class GetLocalUsers
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string  Username { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string Firstname { get; set; }

        [Display(Name = "Checking")]
        public bool Checking { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "user_groups")]
        public string[] GroupName { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }
    }

    // get localusers
    public class LocalUsers
    {
        public List<GetLocalUsers> Objects { get; set; }
    }

}