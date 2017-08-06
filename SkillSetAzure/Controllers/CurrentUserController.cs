﻿using System;
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
            string currentDomainUser = HttpContext.Current.User.Identity.Name.ToString();
            //username only
            string currentUsername = currentDomainUser.Remove(0, currentDomainUser.IndexOf('\\') + 1);
            int index = currentDomainUser.IndexOf("\\" + currentUsername);

            CurrentUser cu = new CurrentUser
            {
                id = 1,
                UserName = currentUsername
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