                            
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
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
// Copyright © YoYoCms@China.2019-07-25T10:55:10. All Rights Reserved.
//<生成时间>2019-07-25T10:55:10</生成时间>
	#endregion
namespace Emploee.Emploee.Advertisements.Dtos
{
	/// <summary>
    /// 广告列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Advertisement))]
    public class AdvertisementListDto : EntityDto<int>
    {
        /// <summary>
        /// 厂家
        /// </summary>
        [DisplayName("厂家")]
        public      string Advertiser { get; set; }
        /// <summary>
        /// 广告链接
        /// </summary>
        [DisplayName("广告链接")]
        public      string AdverAddress { get; set; }
        /// <summary>
        /// 缴费时间
        /// </summary>
        [DisplayName("缴费时间")]
        public      DateTime PayTime { get; set; }
        /// <summary>
        /// 缴费时长
        /// </summary>
        [DisplayName("缴费时长")]
        public      int CoopTime { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [DisplayName("是否显示")]
        public      bool IsShow { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
