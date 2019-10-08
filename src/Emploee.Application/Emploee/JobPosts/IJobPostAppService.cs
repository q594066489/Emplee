                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Dto;
using Emploee.Emploee.JobPosts.Dtos;
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
// Copyright © YoYoCms@China.2019-07-24T17:49:43. All Rights Reserved.
//<生成时间>2019-07-24T17:49:43</生成时间>
	#endregion
namespace Emploee.Emploee.JobPosts
{
	/// <summary>
    /// 职位发布服务接口
    /// </summary>
    public interface IJobPostAppService : IApplicationService
    {
        #region 职位发布管理

        /// <summary>
        /// 根据查询条件获取职位发布分页列表
        /// </summary>
        Task<PagedResultDto<JobPostListDto>> GetPagedJobPosts(GetJobPostInput input);

        /// <summary>
        /// 通过Id获取职位发布信息进行编辑或修改 
        /// </summary>
        Task<GetJobPostForEditOutput> GetJobPostForEdit(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取职位发布ListDto信息
        /// </summary>
		Task<JobPostListDto> GetJobPostById(EntityDto<int> input);



        /// <summary>
        /// 新增或更改职位发布
        /// </summary>
        Task CreateOrUpdateJobPost(CreateOrUpdateJobPostInput input);





        /// <summary>
        /// 新增职位发布
        /// </summary>
        Task<JobPostEditDto> CreateJobPost(JobPostEditDto input);

        /// <summary>
        /// 更新职位发布
        /// </summary>
        Task UpdateJobPost(JobPostEditDto input);

        /// <summary>
        /// 删除职位发布
        /// </summary>
        Task DeleteJobPost(EntityDto<int> input);

        /// <summary>
        /// 批量删除职位发布
        /// </summary>
        Task BatchDeleteJobPost(List<int> input);

        #endregion

#region Excel导出功能



         /// <summary>
        /// 获取职位发布信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetJobPostToExcel();

        #endregion


        Task<PagedResultDto<JobPostListDto>> GetPositionForHome(GetJobPostInput input);
        Task<GetJobPostForEditOutput> GetJobIntroduce(int input);

    }
}
