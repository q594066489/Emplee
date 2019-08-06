                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Dto;
using Emploee.Emploees.Companies.Dtos;
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
// Copyright © YoYoCms@China.2019-07-24T16:21:02. All Rights Reserved.
//<生成时间>2019-07-24T16:21:02</生成时间>
	#endregion
namespace Emploee.Emploees.Companies
{
	/// <summary>
    /// 企业信息服务接口
    /// </summary>
    public interface ICompanyAppService : IApplicationService
    {
        #region 企业信息管理

        /// <summary>
        /// 根据查询条件获取企业信息分页列表
        /// </summary>
        Task<PagedResultDto<CompanyListDto>> GetPagedCompanysAsync(GetCompanyInput input);

        /// <summary>
        /// 通过Id获取企业信息信息进行编辑或修改 
        /// </summary>
        Task<GetCompanyForEditOutput> GetCompanyForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取企业信息ListDto信息
        /// </summary>
		Task<CompanyListDto> GetCompanyByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改企业信息
        /// </summary>
        Task CreateOrUpdateCompanyAsync(CreateOrUpdateCompanyInput input);





        /// <summary>
        /// 新增企业信息
        /// </summary>
        Task<CompanyEditDto> CreateCompanyAsync(CompanyEditDto input);

        /// <summary>
        /// 更新企业信息
        /// </summary>
        Task UpdateCompanyAsync(CompanyEditDto input);

        /// <summary>
        /// 删除企业信息
        /// </summary>
        Task DeleteCompanyAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除企业信息
        /// </summary>
        Task BatchDeleteCompanyAsync(List<int> input);

        Task<GetCompanyForEditOutput> GetCompanyByCompanyID(long CompanyID);
        #endregion

        #region Excel导出功能



        /// <summary>
        /// 获取企业信息信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetCompanyToExcel();

        #endregion

        Task<bool> ImportData(string fileName);


        Task UpdateCompanyInfoAsync(CreateOrUpdateCompanyInput input);
    }
}
