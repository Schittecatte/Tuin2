using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
using Application.Filters;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using WebApplication2.Models;
using Microsoft.AspNet.Identity;
using Context = System.Runtime.Remoting.Contexts.Context;


namespace WebApplication2.Controllers
{

    public static class Extensions
    {
        public static string ToJson(this object o)
            => JsonConvert.SerializeObject(o);
    }

    [AuthorizeAD(Groups = "Maintenance_Auth")]
    public class GetController : Controller
    {
        // GET: Get
        public async Task<ActionResult> LocalUsers()
        {
            // api call localusers
            LocalUsers localUsers = null;

            IEnumerable<Models.GetLocalUsers> users = null;


            using (var client = new HttpClient())
            {
                //Authenticatie
                var credentials = Encoding.ASCII.GetBytes("staict01:NwQ6pnVprxdHJycdifefmI2qtyGy2HMsTgOmzqP7");
                var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
                client.DefaultRequestHeaders.Authorization = header;
                //HTTP GET
                client.BaseAddress =
                    new Uri("https://fortiauthenticator.ventilationserver.com/api/v1/localusers/?format=json");
                var localUsersCall = await client.GetAsync("");

                var result = localUsersCall;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<LocalUsers>();
                    localUsers = readTask;
                    users = localUsers.Objects;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    users = Enumerable.Empty<Models.GetLocalUsers>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

                // list filtering
                List<GetLocalUsers> filteredListUsers = new List<GetLocalUsers>();
                foreach (var user in users)
                {
                    if (!user.Email.Contains("@renson.be") && user.Active == true)
                    {
                        filteredListUsers.Add(user);
                    }
                }

                return View(filteredListUsers);
            }
        }

        //api call usergroups
        public ActionResult UserGroups()
        {
            GetUserGroups.UserGroups userGroups = null;
            IEnumerable<Models.GetUserGroups> groups = null;

            using (var client = new HttpClient())
            {
                //Authenticatie
                var credentials = Encoding.ASCII.GetBytes("staict01:NwQ6pnVprxdHJycdifefmI2qtyGy2HMsTgOmzqP7");
                var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
                client.DefaultRequestHeaders.Authorization = header;
                //HTTP GET
                client.BaseAddress =
                    new Uri("https://fortiauthenticator.ventilationserver.com/api/v1/usergroups/?format=json");
                var userGroupsCall = client.GetAsync("");

                userGroupsCall.Wait();
                var result = userGroupsCall.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GetUserGroups.UserGroups>();
                    readTask.Wait();
                    userGroups = readTask.Result;
                    groups = userGroups.Objects;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    groups = Enumerable.Empty<Models.GetUserGroups>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            // list filtering SSL
            List<GetUserGroups> filteredListGroups = new List<GetUserGroups>();
            foreach (var group in groups)
            {
                if (group.GroupName.Contains("ssl") || group.GroupName.Contains("SSL"))
                {
                    filteredListGroups.Add(group);
                }
            }

            return View(filteredListGroups);
        }

        // Id users call

        public async Task<ActionResult> IdUser(int? id)
        {
            // api call localusers
            GetIdusers getIdusers = null;
            GetIdusers idusers = null;

            using (var client = new HttpClient())
            {
                //Authenticatie                    
                var credentials = Encoding.ASCII.GetBytes("staict01:NwQ6pnVprxdHJycdifefmI2qtyGy2HMsTgOmzqP7");
                var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
                client.DefaultRequestHeaders.Authorization = header;
                client.BaseAddress =
                    new Uri(
                        "https://fortiauthenticator.ventilationserver.com/api/v1/localusers/" + id + "/?format=json");
                var localUsersCall = await client.GetAsync("");

                var result = localUsersCall;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<GetIdusers>();
                    getIdusers = readTask;
                    idusers = getIdusers;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    //idusers = Enumerable.Empty<Models.GetIdusers>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(getIdusers);
        }
        
        // Id groups call

        public async Task<ActionResult> IdGroup(int? id)
        {
            // api call localusers
            GetIdGroups getIdGroups = null;
            GetIdGroups idGroups = null;
            using (var client = new HttpClient())
            {
                //Authenticatie                    
                var credentials = Encoding.ASCII.GetBytes("staict01:NwQ6pnVprxdHJycdifefmI2qtyGy2HMsTgOmzqP7");
                var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
                client.DefaultRequestHeaders.Authorization = header;
                client.BaseAddress =
                    new Uri(
                        "https://fortiauthenticator.ventilationserver.com/api/v1/usergroups/" + id + "/?format=json");

                var data = new { Users = new string[]{ "app/v1/localuser/9"} };
                var test = await client.SendAsync(new HttpRequestMessage
                {
                    Method = new HttpMethod("PATCH"),
                    Content = new StringContent(data.ToJson(), Encoding.UTF8, "application/json")
                });

                // of

                //var localUsersCall = await client.GetAsync("");
                //var result = localUsersCall;
                if (test.IsSuccessStatusCode)
                {
                    var readTask = await test.Content.ReadAsAsync<GetIdGroups>();
                    getIdGroups = readTask;
                    idGroups = getIdGroups;

                    //getIdGroups.Name = "SSL-MainAuth";

                }
                else //web api sent error response 
                {
                    //log response status here..

                    //idusers = Enumerable.Empty<Models.GetIdusers>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(getIdGroups);
        }
    }
}


















