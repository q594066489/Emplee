using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.Emploee.JobUrgents
{
    /// <summary>
    /// 职位加急
    /// </summary>
   public class JobUrgent : Entity, IHasCreationTime
    {
        /// <summary>
        /// 职位编号
        /// </summary>
        [NotNull]
        public int JobId { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        [DefaultValue(0)]
        public int Weight { get; set; }
        /// <summary>
        /// 加急类型
        /// </summary>
        /// 
        [MaxLength(200)]
        public string UrgentType { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? UrgentDate { get; set; }
        /// <summary>
        /// 持续时长
        /// </summary>
        public int UrgentLength { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isDelete { get; set; }
        /// <summary>
        /// 状态 1待审批    2 已通过 管理员手动通过
        /// </summary>
        public int State { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
