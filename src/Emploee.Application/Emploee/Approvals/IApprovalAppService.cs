                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Approvals.Dtos;
using Emploee.Dto;
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
// Copyright © YoYoCms@China.2019-07-25T10:30:54. All Rights Reserved.
//<生成时间>2019-07-25T10:30:54</生成时间>
#endregion
namespace Emploee.Approvals
{
	/// <summary>
    /// 企业注册审批服务接口
    /// </summary>
    public interface IApprovalAppService : IApplicationService
    {
        #region 企业注册审批管理

        /// <summary>
        /// 根据查询条件获取企业注册审批分页列表
        /// </summary>
        Task<PagedResultDto<ApprovalListDto>> GetPagedApprovalsAsync(GetApprovalInput input);

        /// <summary>
        /// 通过Id获取企业注册审批信息进行编辑或修改 
        /// </summary>
        Task<GetApprovalForEditOutput> GetApprovalForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取企业注册审批ListDto信息
        /// </summary>
		Task<ApprovalListDto> GetApprovalByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改企业注册审批
        /// </summary>
        Task CreateOrUpdateApprovalAsync(CreateOrUpdateApprovalInput input);





        /// <summary>
        /// 新增企业注册审批
        /// </summary>
        Task<ApprovalEditDto> CreateApprovalAsync(ApprovalEditDto input);

        /// <summary>
        /// 更新企业注册审批
        /// </summary>
        Task UpdateApprovalAsync(ApprovalEditDto input);

        /// <summary>
        /// 删除企业注册审批
        /// </summary>
        Task DeleteApprovalAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除企业注册审批
        /// </summary>
        Task BatchDeleteApprovalAsync(List<int> input);

        /// <summary>
        /// 批量修改审批
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task BatchChangeState(string input, bool isShow);
        #endregion

        #region Excel导出功能



        /// <summary>
        /// 获取企业注册审批信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetApprovalToExcel();

#endregion





    }
}
