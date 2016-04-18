using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace CPy.Model.Models.User
{
    [Description("角色")]
    [Table("SysRole")]
    public class SysRole : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [MaxLength(20)]
        public string RName { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        [MaxLength(20)]
        public string RNo { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; }

        public virtual ICollection<SysUser> SysUsers { get; set; }
        public virtual ICollection<SysFunction> SysFunctions { get; set; }
    }
}