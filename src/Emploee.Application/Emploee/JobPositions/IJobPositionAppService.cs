﻿                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Emploee.Job_Positions.Dtos;
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
// Copyright © YoYoCms@China.2019-08-13T10:03:36. All Rights Reserved.
//<生成时间>2019-08-13T10:03:36</生成时间>
	#endregion
namespace Emploee.Emploee.Job_Positions
{
	/// <summary>
    /// 服务接口
    /// </summary>
    public interface IJobPositionAppService : IApplicationService
    {
        #region 管理

        /// <summary>
        /// 根据查询条件获取分页列表
        /// </summary>
        Task<PagedResultDto<JobPositionListDto>> GetPagedJobPositionsAsync(GetJobPositionInput input);

        /// <summary>
        /// 通过Id获取信息进行编辑或修改 
        /// </summary>
        Task<GetJobPositionForEditOutput> GetJobPositionForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取ListDto信息
        /// </summary>
		Task<JobPositionListDto> GetJobPositionByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改
        /// </summary>
        Task CreateOrUpdateJobPositionAsync(CreateOrUpdateJobPositionInput input);





        /// <summary>
        /// 新增
        /// </summary>
        Task<JobPositionEditDto> CreateJobPositionAsync(JobPositionEditDto input);

        /// <summary>
        /// 更新
        /// </summary>
        Task UpdateJobPositionAsync(JobPositionEditDto input);

        /// <summary>
        /// 删除
        /// </summary>
        Task DeleteJobPositionAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除
        /// </summary>
        Task BatchDeleteJobPositionAsync(List<int> input);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns>返回list</returns>
        Task<List<JobPositionListDto>> GetAllPosition();
        #endregion



        
    }
}
