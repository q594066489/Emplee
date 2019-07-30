                            
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Emploee.Emploees.Companies;
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
// Copyright © YoYoCms@China.2019-07-24T16:20:56. All Rights Reserved.
//<生成时间>2019-07-24T16:20:56</生成时间>
	#endregion
namespace Emploee.Emploees.Companies.Dtos
{
	/// <summary>
    /// 企业信息列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Company))]
    public class CompanyListDto : EntityDto<int>
    {
        public long CompanyID { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        [DisplayName("企业名称")]
        public      string CompanyName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [DisplayName("邮箱")]
        public      string CompanyEmail { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName("联系电话")]
        public      string CompanyPhone { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        [DisplayName("公司地址")]
        public      string CompanyAddress { get; set; }
        /// <summary>
        /// 公司规模
        /// </summary>
        [DisplayName("公司规模")]
        public      string CompanyScale { get; set; }
        /// <summary>
        /// 公司介绍
        /// </summary>
        [DisplayName("公司介绍")]
        public      string CompanyIntroduce { get; set; }
        /// <summary>
        /// 行业类型
        /// </summary>
        [DisplayName("行业类型")]
        public      string Classify { get; set; }
        /// <summary>
        /// 融资阶段
        /// </summary>
        [DisplayName("融资阶段")]
        public      string Finanicing { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        [DisplayName("营业执照")]
        public      string BussinessLicense { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        [DisplayName("注册时间")]
        public      DateTime RegisterDate { get; set; }
        public      bool isDelete { get; set; }
    }
}
