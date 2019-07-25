﻿                          
  
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploee.JobPersons;
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
// Copyright © YoYoCms@China.2019-07-24T22:37:46. All Rights Reserved.
//<生成时间>2019-07-24T22:37:46</生成时间>
	#endregion
namespace Emploee.Emploee.JobPersons.Dtos
{
    /// <summary>
    /// 职位用户表编辑用Dto
    /// </summary>
    [AutoMap(typeof(JobPerson))]
    public class JobPersonEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 公司编码
        /// </summary>
        [DisplayName("公司编码")]
        [Required]
        public   int  CompanyID { get; set; }

        /// <summary>
        /// 职位编码
        /// </summary>
        [DisplayName("职位编码")]
        [Required]
        public   int  JobID { get; set; }

        /// <summary>
        /// 用户编码
        /// </summary>
        [DisplayName("用户编码")]
        [Required]
        public   int  PersonID { get; set; }

        /// <summary>
        /// 投递时间
        /// </summary>
        [DisplayName("投递时间")]
        [Required]
        public   int  PostDate { get; set; }

    }
}