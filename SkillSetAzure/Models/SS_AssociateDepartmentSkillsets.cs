using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSetAzure.Models
{
    public class SS_AssociateDepartmentSkillsets
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssociateDepartmentSkillsetID { get; set; }
        public int AssociateID { get; set; }
        public int DepartmentSkillsetID { get; set; }
    }
}