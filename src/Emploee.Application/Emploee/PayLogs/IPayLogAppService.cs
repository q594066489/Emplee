                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.PayLogs.Dtos;
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
// Copyright © YoYoCms@China.2019-09-03T16:25:32. All Rights Reserved.
//<生成时间>2019-09-03T16:25:32</生成时间>
	#endregion
namespace Emploee.PayLogs
{
	/// <summary>
    /// 交款记录服务接口
    /// </summary>
    public interface IPayLogAppService : IApplicationService
    {
        #region 交款记录管理

        /// <summary>
        /// 根据查询条件获取交款记录分页列表
        /// </summary>
        Task<PagedResultDto<PayLogListDto>> GetPagedPayLogsAsync(GetPayLogInput input);

        /// <summary>
        /// 通过Id获取交款记录信息进行编辑或修改 
        /// </summary>
        Task<GetPayLogForEditOutput> GetPayLogForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取交款记录ListDto信息
        /// </summary>
		Task<PayLogListDto> GetPayLogByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改交款记录
        /// </summary>
        Task CreateOrUpdatePayLogAsync(CreateOrUpdatePayLogInput input);





        /// <summary>
        /// 新增交款记录
        /// </summary>
        Task<PayLogEditDto> CreatePayLogAsync(PayLogEditDto input);

        /// <summary>
        /// 更新交款记录
        /// </summary>
        Task UpdatePayLogAsync(PayLogEditDto input);

        /// <summary>
        /// 删除交款记录
        /// </summary>
        Task DeletePayLogAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除交款记录
        /// </summary>
        Task BatchDeletePayLogAsync(List<int> input);

        #endregion




    }
}
