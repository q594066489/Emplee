





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
using Emploee.Emploee.Job_Positions.Authorization;
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
// Copyright © YoYoCms@China.2019-08-13T10:03:37. All Rights Reserved.
//<生成时间>2019-08-13T10:03:37</生成时间>
#endregion


namespace Emploee.Emploee.Job_Positions
{
    /// <summary>
    /// 服务实现
    /// </summary>
    //[AbpAuthorize(JobPositionAppPermissions.JobPosition)]


    public class JobPositionAppService : EmploeeAppServiceBase, IJobPositionAppService
    {
        private readonly IRepository<JobPosition, int> _jobPositionRepository;


        private readonly JobPositionManage _jobPositionManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public JobPositionAppService(IRepository<JobPosition, int> jobPositionRepository,
JobPositionManage jobPositionManage

  )
        {
            _jobPositionRepository = jobPositionRepository;
            _jobPositionManage = jobPositionManage;

        }


        #region 实体的自定义扩展方法
        private IQueryable<JobPosition> _jobPositionRepositoryAsNoTrack => _jobPositionRepository.GetAll().AsNoTracking();


        #endregion


        #region 管理

        /// <summary>
        /// 根据查询条件获取分页列表
        /// </summary>
        public async Task<PagedResultDto<JobPositionListDto>> GetPagedJobPositionsAsync(GetJobPositionInput input)
        {

            var query = _jobPositionRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var jobPositionCount = await query.CountAsync();

            var jobPositions = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var jobPositionListDtos = jobPositions.MapTo<List<JobPositionListDto>>();
            return new PagedResultDto<JobPositionListDto>(
            jobPositionCount,
            jobPositionListDtos
            );
        }
        
        /// <summary>
        /// 通过Id获取信息进行编辑或修改 
        /// </summary>
        public async Task<GetJobPositionForEditOutput> GetJobPositionForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetJobPositionForEditOutput();

            JobPositionEditDto jobPositionEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _jobPositionRepository.GetAsync(input.Id.Value);
                jobPositionEditDto = entity.MapTo<JobPositionEditDto>();
            }
            else
            {
                jobPositionEditDto = new JobPositionEditDto();
            }

            output.JobPosition = jobPositionEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取ListDto信息
        /// </summary>
        public async Task<JobPositionListDto> GetJobPositionByIdAsync(EntityDto<int> input)
        {
            var entity = await _jobPositionRepository.GetAsync(input.Id);

            return entity.MapTo<JobPositionListDto>();
        }







        /// <summary>
        /// 新增或更改
        /// </summary>
        public async Task CreateOrUpdateJobPositionAsync(CreateOrUpdateJobPositionInput input)
        {
            if (input.JobPositionEditDto.Id.HasValue)
            {
                await UpdateJobPositionAsync(input.JobPositionEditDto);
            }
            else
            {
                await CreateJobPositionAsync(input.JobPositionEditDto);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        //[AbpAuthorize(JobPositionAppPermissions.JobPosition_CreateJobPosition)]	 
        public virtual async Task<JobPositionEditDto> CreateJobPositionAsync(JobPositionEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<JobPosition>();

            entity = await _jobPositionRepository.InsertAsync(entity);
            return entity.MapTo<JobPositionEditDto>();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        // [AbpAuthorize(JobPositionAppPermissions.JobPosition_EditJobPosition)]
        public virtual async Task UpdateJobPositionAsync(JobPositionEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _jobPositionRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _jobPositionRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        //[AbpAuthorize(JobPositionAppPermissions.JobPosition_DeleteJobPosition)]
        public async Task DeleteJobPositionAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _jobPositionRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        // [AbpAuthorize(JobPositionAppPermissions.JobPosition_DeleteJobPosition)]
        public async Task BatchDeleteJobPositionAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _jobPositionRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion

        public async Task<List<JobPositionListDto>> GetAllPosition()
        {
            var query = _jobPositionRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件
             
            var jobPositions = await query
             
            .ToListAsync();

            var jobPositionListDtos = jobPositions.MapTo<List<JobPositionListDto>>();
            return jobPositionListDtos;
        }
        

    }
}
