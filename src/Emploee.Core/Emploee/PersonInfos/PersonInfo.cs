using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.Emploee.PersonInfos
{
    public class PersonInfo : Entity, IHasCreationTime
    {
        [Required]
        public long PersonID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        
        public int? Age { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        /// 
        [MaxLength(200)]
        public string Education { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// 
        [MaxLength(15)]
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        /// 
        [MaxLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// 期望职位
        /// </summary>
        /// 
        [MaxLength(200)]
        public string ExpectPosition { get; set; }
        /// <summary>
        /// 期望行业
        /// </summary>
        /// 
        [MaxLength(200)]
        public string ExpectTrade { get; set; }
        /// <summary>
        /// 简历
        /// </summary>
        /// 
         
        public string Resume { get; set; }
        /// <summary>
        /// 是否找到工作
        /// </summary>
        public bool isOnJob { get; set; }
        /// <summary>
        /// 状态（在职，离职，考虑中...)
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 工作年限
        /// </summary>
        public int JobYear { get; set; }
        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
