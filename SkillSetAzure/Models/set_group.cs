using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillSetAzure.Models
{
    public class set_group
    {
        public string grp_id { get; set; }
        public string grp_name { get; set; }
        public string grp_desc { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
    }
}