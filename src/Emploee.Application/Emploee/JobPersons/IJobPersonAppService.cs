                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Emploee.JobPersons.Dtos;
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
// Copyright © YoYoCms@China.2019-07-24T22:37:54. All Rights Reserved.
//<生成时间>2019-07-24T22:37:54</生成时间>
	#endregion
namespace Emploee.Emploee.JobPersons
{
	/// <summary>
    /// 职位用户表服务接口
    /// </summary>
    public interface IJobPersonAppService : IApplicationService
    {
        #region 职位用户表管理

        /// <summary>
        /// 根据查询条件获取职位用户表分页列表
        /// </summary>
        Task<PagedResultDto<JobPersonListDto>> GetPagedJobPersonsAsync(GetJobPersonInput input);

        /// <summary>
        /// 通过Id获取职位用户表信息进行编辑或修改 
        /// </summary>
        Task<GetJobPersonForEditOutput> GetJobPersonForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取职位用户表ListDto信息
        /// </summary>
		Task<JobPersonListDto> GetJobPersonByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改职位用户表
        /// </summary>
        Task CreateOrUpdateJobPersonAsync(CreateOrUpdateJobPersonInput input);





        /// <summary>
        /// 新增职位用户表
        /// </summary>
        Task<JobPersonEditDto> CreateJobPersonAsync(JobPersonEditDto input);

        /// <summary>
        /// 更新职位用户表
        /// </summary>
        Task UpdateJobPersonAsync(JobPersonEditDto input);

        /// <summary>
        /// 删除职位用户表
        /// </summary>
        Task DeleteJobPersonAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除职位用户表
        /// </summary>
        Task BatchDeleteJobPersonAsync(List<int> input);

        #endregion


        Task<int> CreateFactoryAsync(GetJobPersonInput input);

    }
}
