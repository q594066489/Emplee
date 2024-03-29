﻿

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploee.PersonInfos;
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
// Copyright © YoYoCms@China.2019-07-24T22:14:43. All Rights Reserved.
//<生成时间>2019-07-24T22:14:43</生成时间>
#endregion
namespace Emploee.Emploee.PersonInfos.Dtos
{
    /// <summary>
    /// 个人中心编辑用Dto
    /// </summary>
    [AutoMap(typeof(PersonInfo))]
    public class PersonInfoEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }
        public long PersonID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [DisplayName("年龄")]
        public int? Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName("性别")]
        public string Sex { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [DisplayName("学历")]
        [MaxLength(200)]
        public string Education { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName("联系电话")]
        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DisplayName("邮箱")]
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 期望职位
        /// </summary>
        [DisplayName("期望职位")]
        [MaxLength(200)]
        public string ExpectPosition { get; set; }

        /// <summary>
        /// 期望行业
        /// </summary>
        [DisplayName("期望行业")]
        [MaxLength(200)]
        public string ExpectTrade { get; set; }

        /// <summary>
        /// 简历
        /// </summary>
        [DisplayName("简历")]
        public string Resume { get; set; }

        /// <summary>
        /// 是否找到工作
        /// </summary>
        [DisplayName("是否找到工作")]
        public bool isOnJob { get; set; }

        /// <summary>
        /// 状态（在职，离职，考虑中...)
        /// </summary>
        [DisplayName("状态（在职，离职，考虑中...)")]
        public string State { get; set; }

        /// <summary>
        /// 工作年限
        /// </summary>
        [DisplayName("工作年限")]
        public string JobYear { get; set; }

    }
}
