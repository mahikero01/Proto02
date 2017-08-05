using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSetAzure.Models
{
    public class SS_Departments
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short DepartmentID { get; set; }
        public string DepartmentDescr { get; set; }
        public bool IsActive { get; set; }
    }
}