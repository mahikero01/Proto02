using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSetAzure.Models
{
    public class SS_Locations
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        public string LocationDescr { get; set; }
        public bool IsActive { get; set; }
    }
}