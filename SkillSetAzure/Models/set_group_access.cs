using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillSetAzure.Models
{
    public class set_group_access
    {
        public string grp_id { get; set; }
        public string mod_id { get; set; }
        public bool can_view { get; set; }
        public bool can_add { get; set; }
        public bool can_edit { get; set; }
        public bool can_delete { get; set; }
    }
}