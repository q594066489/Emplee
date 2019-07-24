using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee.Emploee.JobPersons
{
    /// <summary>
    /// 职位用户表 
    /// </summary>
    public class JobPerson:Entity
    {
        /// <summary>
        /// 公司编码
        /// </summary>
        public int CompanyID { get; set; }
        /// <summary>
        /// 职位编码
        /// </summary>
        public int JobID { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public int PersonID { get; set; }
        /// <summary>
        /// 投递时间
        /// </summary>
        public int PostDate { get; set; }

    }
}
