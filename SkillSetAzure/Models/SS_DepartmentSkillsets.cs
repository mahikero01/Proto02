using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSetAzure.Models
{
    public class SS_DepartmentSkillsets
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentSkillsetID { get; set; }
        public short DepartmentID { get; set; }
        public int SkillsetID { get; set; }
    }
}