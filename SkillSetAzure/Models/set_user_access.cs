using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillSetAzure.Models
{
    public class set_user_access
    {
        public int Id { get; set; }
        public string user_id { get; set; }
        public string grp_id { get; set; }
    }
}