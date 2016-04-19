using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CPy.Domain.Entities.Audit;

namespace CPy.Model.Models.User
{
    [Description("功能")]
    [Table("SysFunction")]
    public class SysFunction:AuditEntity
    {
        [MaxLength(50)]
        public string FUrl { get; set; }
        [MaxLength(20)]
        public string FNo { get; set; }
        [MaxLength(50)]
        public string FName { get; set; }

        public Guid SysModuleId { get; set; }
        public virtual SysModule SysModule { get; set; }
        public virtual ICollection<SysRole> SysRoles { get; set; }
    }
}