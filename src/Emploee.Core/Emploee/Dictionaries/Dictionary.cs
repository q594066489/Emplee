using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.Emploee.Dictionaries
{
    public class  Dictionary : Entity, ICreationAudited
    {
        public const int MaxCodeLength = 20;
        public const int MaxNameLength = 100;

        [MaxLength(MaxCodeLength)]
        public string ParentCode { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        [MaxLength(MaxCodeLength)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [MaxLength(MaxNameLength)]
        public string value { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int OrderIndex { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public Dictionary()
        {
            this.OrderIndex = 0;
        }
    }
}
