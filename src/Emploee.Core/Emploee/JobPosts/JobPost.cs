using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Emploee.Emploees.Companies;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.Emploee.JobPosts
{
    /// <summary>
    /// 职位发布
    /// </summary>
   public  class JobPost:Entity, IHasCreationTime
    {
        /// <summary>
        /// 企业编号
        /// </summary>
         [Required]
         [NotNull]
        public int CompanyId { get; set; }


        /// <summary>
        /// 职位名称
        /// </summary>
        /// 
        [Required]
        [NotNull]
        [MaxLength(200)]
        public string JobName { get; set; }
        /// <summary>
        /// 薪资min
        /// </summary>
        /// 
        [DefaultValue(0)]
        public int SalaryMin { get; set; }
        /// <summary>
        /// 薪资max
        /// </summary>
        /// 
        [DefaultValue(0)]
        public int SalaryMax { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        /// 
        [MaxLength(200)]
        public string Education { get; set; }
        /// <summary>
        /// 工作经验
        /// </summary>
        /// 
        [MaxLength(200)]
        public string Experience { get; set; }
        /// <summary>
        /// 工作地点
        /// </summary>
        [MaxLength(400)]
        public string JobAddress { get; set; }
        /// <summary>
        /// 技能要求
        /// </summary>
        /// 
         
        public string SkillRequire { get; set; }
        /// <summary>
        /// 职位详情
        /// </summary>
        /// 

        public string JobDetail { get; set; }
        /// <summary>
        /// 行业选择
        /// </summary>
        /// 
        [MaxLength(200)]
        public string JobSelect { get; set; }
        /// <summary>
        /// 职位类型
        /// </summary>
        /// 
        [MaxLength(200)]
        public string JobType { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>

        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isDelete { get; set; }


        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
