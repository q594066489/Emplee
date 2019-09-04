                          
  
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.PayLogs;
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
// Copyright © YoYoCms@China.2019-09-03T16:25:11. All Rights Reserved.
//<生成时间>2019-09-03T16:25:11</生成时间>
	#endregion
namespace Emploee.PayLogs.Dtos
{
    /// <summary>
    /// 交款记录编辑用Dto
    /// </summary>
    [AutoMap(typeof(PayLog))]
    public class PayLogEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 企业编号
        /// </summary>
        [DisplayName("企业编号")]
        public   int  CompanyID { get; set; }

        /// <summary>
        /// 交款金额
        /// </summary>
        [DisplayName("交款金额")]
        public   double  PayAmount { get; set; }

        /// <summary>
        /// 交款时间
        /// </summary>
        [DisplayName("交款时间")]
        public   DateTime  PayTime { get; set; }

        /// <summary>
        /// 缴费时长
        /// </summary>
        [DisplayName("缴费时长")]
        public   int  CoopTime { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        [DisplayName("权重")]
        public   int  Weight { get; set; }

    }
}
