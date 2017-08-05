using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSetAzure.Models
{
    public class SS_Skillsets
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillsetID { get; set; }
        public string SkillsetDescr { get; set; }
        public bool IsActive { get; set; }
    }
}