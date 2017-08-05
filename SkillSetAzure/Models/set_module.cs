using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillSetAzure.Models
{
    public class set_module
    {
        [Key]
        public string mod_id { get; set; }
        public string mod_name { get; set; }
        public string mod_desc { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
    }
}