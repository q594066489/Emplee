﻿                                
                            
                                 
     
        

	using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Text;
    using System.Threading.Tasks;
    using Abp;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Configuration;
    using Abp.Domain.Repositories;
    using Abp.Extensions;
    using Abp.Linq.Extensions;
using Emploee.Dto;
using Emploee.Emploee.JobPosts.Authorization;  
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
// Copyright © YoYoCms@China.2019-07-24T17:49:44. All Rights Reserved.
//<生成时间>2019-07-24T17:49:44</生成时间>
	#endregion


    namespace Emploee.Emploee.JobPosts
{
    /// <summary>
    /// 职位发布服务实现
    /// </summary>
          [AbpAuthorize(JobPostAppPermissions.JobPost)]
		 
       
    public class JobPostAppService : EmploeeAppServiceBase, IJobPostAppService
    {
        private readonly IRepository<JobPost,int> _jobPostRepository;
		           private readonly IJobPostListExcelExporter _jobPostListExcelExporter;
           

		private readonly JobPostManage _jobPostManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public JobPostAppService( IRepository<JobPost,int> jobPostRepository	,
JobPostManage jobPostManage
	  ,            IJobPostListExcelExporter jobPostListExcelExporter  
  )
        {
            _jobPostRepository = jobPostRepository;
			 _jobPostManage = jobPostManage;
			             _jobPostListExcelExporter = jobPostListExcelExporter;  
        }


		  #region 实体的自定义扩展方法
        private IQueryable<JobPost> _jobPostRepositoryAsNoTrack => _jobPostRepository.GetAll().AsNoTracking();


        #endregion


    #region 职位发布管理

    /// <summary>
    /// 根据查询条件获取职位发布分页列表
    /// </summary>
    public async Task<PagedResultDto<JobPostListDto>> GetPagedJobPostsAsync(GetJobPostInput input)
{
			
    var query = _jobPostRepositoryAsNoTrack;
    //TODO:根据传入的参数添加过滤条件

    var jobPostCount = await query.CountAsync();

    var jobPosts = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var jobPostListDtos = jobPosts.MapTo<List<JobPostListDto>>();
    return new PagedResultDto<JobPostListDto>(
    jobPostCount,
    jobPostListDtos
    );
    }

        /// <summary>
    /// 通过Id获取职位发布信息进行编辑或修改 
    /// </summary>
    public async Task<GetJobPostForEditOutput> GetJobPostForEditAsync(NullableIdDto<int> input)
{
    var output=new GetJobPostForEditOutput();

    JobPostEditDto jobPostEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _jobPostRepository.GetAsync(input.Id.Value);
    jobPostEditDto=entity.MapTo<JobPostEditDto>();
    }
	else 
	{
	jobPostEditDto=new JobPostEditDto();	
	}

	output.JobPost=jobPostEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取职位发布ListDto信息
    /// </summary>
    public async Task<JobPostListDto> GetJobPostByIdAsync(EntityDto<int> input)
{
    var entity = await _jobPostRepository.GetAsync(input.Id);

    return entity.MapTo<JobPostListDto>();
    }







    /// <summary>
    /// 新增或更改职位发布
    /// </summary>
    public async Task CreateOrUpdateJobPostAsync(CreateOrUpdateJobPostInput input)
{
    if (input.JobPostEditDto.Id.HasValue)
{
    await UpdateJobPostAsync(input.JobPostEditDto);
    }
    else
{
    await CreateJobPostAsync(input.JobPostEditDto);
    }
    }

    /// <summary>
    /// 新增职位发布
    /// </summary>
	        [AbpAuthorize(JobPostAppPermissions.JobPost_CreateJobPost)]	 
         public virtual async Task<JobPostEditDto> CreateJobPostAsync(JobPostEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<JobPost>();
	
    entity = await _jobPostRepository.InsertAsync(entity);
    return entity.MapTo<JobPostEditDto>();
    }

    /// <summary>
    /// 编辑职位发布
    /// </summary>
	      [AbpAuthorize(JobPostAppPermissions.JobPost_EditJobPost)]
         public virtual async Task UpdateJobPostAsync(JobPostEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _jobPostRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _jobPostRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除职位发布
    /// </summary>
	    [AbpAuthorize(JobPostAppPermissions.JobPost_DeleteJobPost)]
         public async Task DeleteJobPostAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _jobPostRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除职位发布
    /// </summary>
	    [AbpAuthorize(JobPostAppPermissions.JobPost_DeleteJobPost)]
         public async Task BatchDeleteJobPostAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _jobPostRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion
  #region 职位发布的Excel导出功能


        public async Task<FileDto> GetJobPostToExcel()
        {
                var entities = await    _jobPostRepository.GetAll().ToListAsync();     

var dtos=             entities.MapTo<List<JobPostListDto>>();

var fileDto=_jobPostListExcelExporter.ExportJobPostToFile(dtos);
 
           

            return fileDto;
        }


#endregion
  









    }
    }