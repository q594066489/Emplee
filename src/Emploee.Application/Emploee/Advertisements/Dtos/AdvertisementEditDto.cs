                          
  
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploee.Advertisements;
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
// Copyright © YoYoCms@China.2019-07-25T10:55:05. All Rights Reserved.
//<生成时间>2019-07-25T10:55:05</生成时间>
	#endregion
namespace Emploee.Emploee.Advertisements.Dtos
{
    /// <summary>
    /// 广告编辑用Dto
    /// </summary>
    [AutoMap(typeof(Advertisement))]
    public class AdvertisementEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 厂家
        /// </summary>
        [DisplayName("厂家")]
        [Required]
        [MaxLength(200)]
        public   string  Advertiser { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [DisplayName("图片")]
        [Required]
        public   string  AdverPicture { get; set; }

        /// <summary>
        /// 广告链接
        /// </summary>
        [DisplayName("广告链接")]
        [Required]
        [MaxLength(400)]
        public   string  AdverAddress { get; set; }

        /// <summary>
        /// 缴费金额
        /// </summary>
        [DisplayName("缴费金额")]
        [Required]
        public   string  PayAmount { get; set; }

        /// <summary>
        /// 缴费时间
        /// </summary>
        [DisplayName("缴费时间")]
        [Required]
        public   DateTime  PayTime { get; set; }

        /// <summary>
        /// 缴费时长
        /// </summary>
        [DisplayName("缴费时长")]
        [Required]
        public   int  CoopTime { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [DisplayName("是否显示")]
        public   bool  IsShow { get; set; }

    }
}
