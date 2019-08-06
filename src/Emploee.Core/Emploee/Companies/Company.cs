using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.Emploees.Companies
{
    public class Company:Entity, IHasCreationTime
    {
        [Required]
        public long CompanyID { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        [MaxLength(200)]
        public string CompanyName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        /// 
        [MaxLength(200)]
        public string CompanyEmail { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// 
        [MaxLength(15)]
        public string CompanyPhone { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        /// 
        [MaxLength(200)]
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 公司规模
        /// </summary>
        /// 
        [MaxLength(200)]
        public string CompanyScale { get; set; }
        /// <summary>
        /// 公司介绍
        /// </summary>
        /// 
         
        public string CompanyIntroduce { get; set; }
        /// <summary>
        /// 行业类型
        /// </summary>
         
        public string Classify { get; set; }
        /// <summary>
        /// 融资阶段
        /// </summary>
        /// 
        [MaxLength(200)]
        public string Finanicing { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        /// 
         
        public string BussinessLicense { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        
        public DateTime RegisterDate { get; set; }
        public bool isDelete { get; set; }


        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
