using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.Emploee.Advertisements
{
    public class Advertisement: Entity, IHasCreationTime
    {
        /// <summary>
        /// 厂家
        /// </summary>
        /// 
        [MaxLength(200)]
        public string Advertiser { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        /// 
         
        public string AdverPicture { get; set; }
        /// <summary>
        /// 广告链接
        /// </summary>
        /// 
        [MaxLength(400)]
        public string AdverAddress { get; set; }
        /// <summary>
        /// 缴费金额
        /// </summary>
        /// 

        public string PayAmount { get; set; }
        /// <summary>
        /// 缴费时间
        /// </summary>
        public DateTime PayTime { get; set; }
        /// <summary>
        /// 缴费时长
        /// </summary>
        public int CoopTime { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }
         

        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
