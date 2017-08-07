using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SkillSetAzure.Models;

namespace SkillSetAzure.Controllers
{
    public class CurrentUserController : ApiController
    {
        // GET api/currentuser
        //EROS
        public CurrentUser Get()
        {
            //withDomain
            //string currentDomainUser = HttpContext.Current.User.Identity.Name.ToString();
            //username only
            //string currentUsername = currentDomainUser.Remove(0, currentDomainUser.IndexOf('\\') + 1);
            //int index = currentDomainUser.IndexOf("\\" + currentUsername);
            string currentDomainUser = HttpContext.Current.User.Identity.Name.ToString();
            //currentDomainUser = currentDomainUser.Remove(0, currentDomainUser.IndexOf('@') + 1);
            currentDomainUser = currentDomainUser==null||currentDomainUser.Trim().Equals("") ? "" : currentDomainUser.Substring(0, currentDomainUser.IndexOf('@'));

           

            CurrentUser cu = new CurrentUser
            {
                id = 1,
                UserName = currentDomainUser
            };

            return cu;
        }

        [Route("api/GetDoma")]
        public CurrentUser GetDoma()
        {
            string currentDomainUser = HttpContext.Current.User.Identity.Name.ToString();
            //currentDomainUser = currentDomainUser.Remove(0, currentDomainUser.IndexOf('@') + 1);
            //currentDomainUser = currentDomainUser.Substring(0, currentDomainUser.IndexOf('@'));
            currentDomainUser = currentDomainUser == null || currentDomainUser.Trim().Equals("") ? "" : currentDomainUser.Substring(0, currentDomainUser.IndexOf('@'));

            string curdom2 = Environment.UserName; ;

            CurrentUser cu = new CurrentUser
            {
                id = 1,
                UserName = currentDomainUser,
                //UserName = "1) " + currentDomainUser + " - other type - 2)" + curdom2

                
                //UserName = "1)" + Environment.UserDomainName + 
                //    " 2)" + Environment.UserInteractive +
                //    " 3)" + currentDomainUser +
                //    " 4)" + HttpContext.Current.Request.LogonUserIdentity.User.ToString() +
                //    " 5)" + HttpContext.Current.Request.LogonUserIdentity.Owner.ToString()+
                //    " 6)" + RequestContext.Principal.Identity.Name.ToString()+
                //    " 7)" + HttpContext.Current.Request.LogonUserIdentity.Name+
                //    " "
            };

            return cu;
        }
        //// GET api/currentuser/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/currentuser
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/currentuser/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/currentuser/5
        //public void Delete(int id)
        //{
        //}
    }
}
