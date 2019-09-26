                            
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Emploee.Emploee.JobUrgents;
 #region 代码生成器相关信息_ABP Code Generator Info
   //你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
   //我的邮箱:werltm@hotmail.com
   // 官方网站:"http://www.yoyocms.com"
 // 交流QQ群：104390185  
 //微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2019-07-24T21:23:46. All Rights Reserved.
//<生成时间>2019-07-24T21:23:46</生成时间>
	#endregion
namespace Emploee.Emploee.JobUrgents.Dtos
{
	/// <summary>
    /// 职位加急列表Dto
    /// </summary>
    [AutoMapFrom(typeof(JobUrgent))]
    public class JobUrgentListDto : EntityDto<int>
    {
        /// <summary>
        /// 职位编号
        /// </summary>
        [DisplayName("职位编号")]
        public      int JobId { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        [DisplayName("权重")]
        public      int Weight { get; set; }
        /// <summary>
        /// 加急类型
        /// </summary>
        [DisplayName("加急类型")]
        public      string UrgentType { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        [DisplayName("起始时间")]
        public      DateTime? UrgentDate { get; set; }
        /// <summary>
        /// 持续时长
        /// </summary>
        [DisplayName("持续时长")]
        public      int UrgentLength { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [DisplayName("是否有效")]
        public      bool isDelete { get; set; }
        public int State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
