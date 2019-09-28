                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Dto;
using Emploee.Emploee.JobUrgents.Dtos;
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
// Copyright © YoYoCms@China.2019-07-24T21:23:54. All Rights Reserved.
//<生成时间>2019-07-24T21:23:54</生成时间>
	#endregion
namespace Emploee.Emploee.JobUrgents
{
	/// <summary>
    /// 职位加急服务接口
    /// </summary>
    public interface IJobUrgentAppService : IApplicationService
    {
        #region 职位加急管理

        /// <summary>
        /// 根据查询条件获取职位加急分页列表
        /// </summary>
        Task<PagedResultDto<JobUrgentListDto>> GetPagedJobUrgentsAsync(GetJobUrgentInput input);

        /// <summary>
        /// 通过Id获取职位加急信息进行编辑或修改 
        /// </summary>
        Task<GetJobUrgentForEditOutput> GetJobUrgentForEditAsync(int jobid,string JobName);

		  /// <summary>
        /// 通过指定id获取职位加急ListDto信息
        /// </summary>
		Task<JobUrgentListDto> GetJobUrgentByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改职位加急
        /// </summary>
        Task CreateOrUpdateJobUrgentAsync(CreateOrUpdateJobUrgentInput input);





        /// <summary>
        /// 新增职位加急
        /// </summary>
        Task<JobUrgentEditDto> CreateJobUrgentAsync(JobUrgentEditDto input);

        /// <summary>
        /// 更新职位加急
        /// </summary>
        Task UpdateJobUrgentAsync(JobUrgentEditDto input);

        /// <summary>
        /// 删除职位加急
        /// </summary>
        Task DeleteJobUrgentAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除职位加急
        /// </summary>
        Task BatchDeleteJobUrgentAsync(List<int> input);

        #endregion

#region Excel导出功能



         /// <summary>
        /// 获取职位加急信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetJobUrgentToExcel();

#endregion





    }
}
