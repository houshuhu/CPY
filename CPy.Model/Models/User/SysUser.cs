using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace CPy.Model.Models.User
{
    [Description("用户")]
    [Table("SysUser")]
    public class SysUser:FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 账号
        /// </summary>
        [MaxLength(20)]
        public string UName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(50)]
        public string UPassWord { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [MaxLength(20)]
        public string UNo { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(20)]
        public string URealName { get; set; }
        /// <summary>
        /// 身份证ID
        /// </summary>
        [MaxLength(20)]
        public string UIDCard { get; set; }
        public virtual ICollection<SysRole> SysRoles { get; set; }
    }
}