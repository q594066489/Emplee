





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
using Emploee.Emploee.JobUrgents.Authorization;
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
// Copyright © YoYoCms@China.2019-07-24T21:23:56. All Rights Reserved.
//<生成时间>2019-07-24T21:23:56</生成时间>
#endregion


namespace Emploee.Emploee.JobUrgents
{
    /// <summary>
    /// 职位加急服务实现
    /// </summary>
    [AbpAuthorize(JobUrgentAppPermissions.JobUrgent)]


    public class JobUrgentAppService : EmploeeAppServiceBase, IJobUrgentAppService
    {
        private readonly IRepository<JobUrgent, int> _jobUrgentRepository;
        private readonly IJobUrgentListExcelExporter _jobUrgentListExcelExporter;


        private readonly JobUrgentManage _jobUrgentManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public JobUrgentAppService(IRepository<JobUrgent, int> jobUrgentRepository,
JobUrgentManage jobUrgentManage
      , IJobUrgentListExcelExporter jobUrgentListExcelExporter
  )
        {
            _jobUrgentRepository = jobUrgentRepository;
            _jobUrgentManage = jobUrgentManage;
            _jobUrgentListExcelExporter = jobUrgentListExcelExporter;
        }


        #region 实体的自定义扩展方法
        private IQueryable<JobUrgent> _jobUrgentRepositoryAsNoTrack => _jobUrgentRepository.GetAll().AsNoTracking();


        #endregion


        #region 职位加急管理

        /// <summary>
        /// 根据查询条件获取职位加急分页列表
        /// </summary>
        public async Task<PagedResultDto<JobUrgentListDto>> GetPagedJobUrgentsAsync(GetJobUrgentInput input)
        {

            var query = _jobUrgentRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var jobUrgentCount = await query.CountAsync();

            var jobUrgents = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var jobUrgentListDtos = jobUrgents.MapTo<List<JobUrgentListDto>>();
            return new PagedResultDto<JobUrgentListDto>(
            jobUrgentCount,
            jobUrgentListDtos
            );
        }

        /// <summary>
        /// 通过Id获取职位加急信息进行编辑或修改 
        /// </summary>
        public async Task<GetJobUrgentForEditOutput> GetJobUrgentForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetJobUrgentForEditOutput();

            JobUrgentEditDto jobUrgentEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _jobUrgentRepository.GetAsync(input.Id.Value);
                jobUrgentEditDto = entity.MapTo<JobUrgentEditDto>();
            }
            else
            {
                jobUrgentEditDto = new JobUrgentEditDto();
            }

            output.JobUrgent = jobUrgentEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取职位加急ListDto信息
        /// </summary>
        public async Task<JobUrgentListDto> GetJobUrgentByIdAsync(EntityDto<int> input)
        {
            var entity = await _jobUrgentRepository.GetAsync(input.Id);

            return entity.MapTo<JobUrgentListDto>();
        }







        /// <summary>
        /// 新增或更改职位加急
        /// </summary>
        public async Task CreateOrUpdateJobUrgentAsync(CreateOrUpdateJobUrgentInput input)
        {
            if (input.JobUrgentEditDto.Id.HasValue)
            {
                await UpdateJobUrgentAsync(input.JobUrgentEditDto);
            }
            else
            {
                await CreateJobUrgentAsync(input.JobUrgentEditDto);
            }
        }

        /// <summary>
        /// 新增职位加急
        /// </summary>
        [AbpAuthorize(JobUrgentAppPermissions.JobUrgent_CreateJobUrgent)]
        public virtual async Task<JobUrgentEditDto> CreateJobUrgentAsync(JobUrgentEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<JobUrgent>();

            entity = await _jobUrgentRepository.InsertAsync(entity);
            return entity.MapTo<JobUrgentEditDto>();
        }

        /// <summary>
        /// 编辑职位加急
        /// </summary>
        [AbpAuthorize(JobUrgentAppPermissions.JobUrgent_EditJobUrgent)]
        public virtual async Task UpdateJobUrgentAsync(JobUrgentEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _jobUrgentRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _jobUrgentRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除职位加急
        /// </summary>
        [AbpAuthorize(JobUrgentAppPermissions.JobUrgent_DeleteJobUrgent)]
        public async Task DeleteJobUrgentAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _jobUrgentRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除职位加急
        /// </summary>
        [AbpAuthorize(JobUrgentAppPermissions.JobUrgent_DeleteJobUrgent)]
        public async Task BatchDeleteJobUrgentAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _jobUrgentRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        #region 职位加急的Excel导出功能


        public async Task<FileDto> GetJobUrgentToExcel()
        {
            var entities = await _jobUrgentRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<JobUrgentListDto>>();

            var fileDto = _jobUrgentListExcelExporter.ExportJobUrgentToFile(dtos);



            return fileDto;
        }


        #endregion










    }
}
