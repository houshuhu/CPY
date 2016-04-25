using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CPy.Domain.Entities.Audit;

namespace CPy.Model.Models.Admin
{
    [Description("模块")]
    [Table("SysModule")]
    public class SysModule : AuditEntity
    {
        /// <summary>
        /// 模块编号
        /// </summary>
        [MaxLength(20)]
        public string MNo { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        [MaxLength(30)]
        public string MName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; }

        public virtual ICollection<SysFunction> SysFunctions { get; set; }
    }
}