using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillSetAzure.Models
{
    public class set_user
    {
        [Key]
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string user_last_name { get; set; }
        public string user_first_name { get; set; }
        public string user_middle_name { get; set; }
        public Nullable<bool> can_PROD { get; set; }
        public Nullable<bool> can_UAT { get; set; }
        public Nullable<bool> can_PEER { get; set; }
        public Nullable<bool> can_DEV { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
    }
}