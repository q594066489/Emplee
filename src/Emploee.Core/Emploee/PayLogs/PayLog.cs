using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.PayLogs
{
    /// <summary>
    /// 企业注册审批
    /// </summary>
    public class PayLog : Entity, IHasCreationTime
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public int CompanyID { get; set; }
        
        /// <summary>
        /// 交款金额
        /// </summary>
        public double PayAmount { get; set; }
        /// <summary>
        /// 交款时间
        /// </summary>
        public DateTime PayTime { get; set; }
        /// <summary>
        /// 缴费时长
        /// </summary>
        public int CoopTime { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { get; set; }
         
        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
