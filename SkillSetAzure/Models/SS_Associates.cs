using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSetAzure.Models
{
    public class SS_Associates
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssociateID { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool VPN { get; set; }
        public short DepartmentID { get; set; }
        public int LocationID { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}