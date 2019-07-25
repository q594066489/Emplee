                          
   using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
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
// Copyright © YoYoCms@China.2019-07-24T16:21:13. All Rights Reserved.
//<生成时间>2019-07-24T16:21:13</生成时间>
	#endregion
namespace Emploee.Emploees.Companies.EntityMapper.Companies
{

	/// <summary>
    /// 企业信息的数据配置文件
    /// </summary>
    public class CompanyCfg : EntityTypeConfiguration<Company>
    {
		/// <summary>
        ///  构造方法[默认链接字符串< see cref = "EmploeesDbContext" /> ]
        /// </summary>
		public CompanyCfg ()
		{
		            ToTable("Company", EmploeeConsts.SchemaName.Basic);
 
      //todo: 需要将以下文件注入到EmploeesDbContext中

  //		public IDbSet<Company> Companys { get; set; }
   //		 modelBuilder.Configurations.Add(new CompanyCfg());




		    // 企业名称
			Property(a => a.CompanyName).HasMaxLength(200);
		    // 邮箱
			Property(a => a.CompanyEmail).HasMaxLength(200);
		    // 联系电话
			Property(a => a.CompanyPhone).HasMaxLength(15);
		    // 公司地址
			Property(a => a.CompanyAddress).HasMaxLength(200);
		    // 公司规模
			Property(a => a.CompanyScale).HasMaxLength(200);
		    // 公司介绍
			Property(a => a.CompanyIntroduce).HasMaxLength(200);
		    // 行业类型
			Property(a => a.Classify).HasMaxLength(4000);
		    // 融资阶段
			Property(a => a.Finanicing).HasMaxLength(200);
		    // 营业执照
			Property(a => a.BussinessLicense).HasMaxLength(4000);
		}
    }
}