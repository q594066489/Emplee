﻿
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Emploee.Emploee.JobPosts;
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
// Copyright © YoYoCms@China.2019-07-24T17:49:38. All Rights Reserved.
//<生成时间>2019-07-24T17:49:38</生成时间>
#endregion
namespace Emploee.Emploee.JobPosts.Dtos
{
    /// <summary>
    /// 职位发布列表Dto
    /// </summary>
    [AutoMapFrom(typeof(JobPost))]
    public class JobPostListDto : EntityDto<int>
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        [DisplayName("企业编号")]
        public int CompanyId { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        [DisplayName("职位名称")]
        public string JobName { get; set; }
        /// <summary>
        /// 薪资min
        /// </summary>
        [DisplayName("薪资min")]
        public double SalaryMin { get; set; }
        /// <summary>
        /// 薪资max
        /// </summary>
        [DisplayName("薪资max")]
        public double SalaryMax { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        [DisplayName("学历")]
        public string Education { get; set; }
        /// <summary>
        /// 工作经验
        /// </summary>
        [DisplayName("工作经验")]
        public string Experience { get; set; }
        /// <summary>
        /// 工作地点
        /// </summary>
        [DisplayName("工作地点")]
        public string JobAddress { get; set; }
        /// <summary>
        /// 技能要求
        /// </summary>
        [DisplayName("技能要求")]
        public string SkillRequire { get; set; }
        /// <summary>
        /// 职位详情
        /// </summary>
        [DisplayName("职位详情")]
        public string JobDetail { get; set; }
        /// <summary>
        /// 行业选择
        /// </summary>
        [DisplayName("行业选择")]
        public string JobSelect { get; set; }
        /// <summary>
        /// 职位类型
        /// </summary>
        [DisplayName("职位类型")]
        public string JobType { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [DisplayName("发布时间")]
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [DisplayName("是否有效")]
        public bool isDelete { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        [DisplayName("企业名称")]
        public string CompanyName { get; set; }
        [DisplayName("公司规模")]
        public string CompanyScale { get; set; }
        /// <summary>
        /// 融资阶段
        /// </summary>
        [DisplayName("融资阶段")]
        public string Finanicing { get; set; }

        public int JobId { get; set; }

        public int Weight { get; set; }
        public int state { get; set; }
        public string urgentType { get; set; }
        public string Memo { get; set; }
    }
}
