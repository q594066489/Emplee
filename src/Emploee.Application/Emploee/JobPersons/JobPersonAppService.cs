





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
using Abp.Runtime.Session;
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
// Copyright © YoYoCms@China.2019-07-24T22:37:55. All Rights Reserved.
//<生成时间>2019-07-24T22:37:55</生成时间>
#endregion


namespace Emploee.Emploee.JobPersons
{
    /// <summary>
    /// 职位用户表服务实现
    /// </summary>

    public class JobPersonAppService : EmploeeAppServiceBase, IJobPersonAppService
    {
        private readonly IRepository<JobPerson, int> _jobPersonRepository;


        private readonly JobPersonManage _jobPersonManage;
        private readonly IAbpSession _IAbpSession;
        /// <summary>
        /// 构造方法
        /// </summary>
        public JobPersonAppService(
            IRepository<JobPerson, int> jobPersonRepository,
            JobPersonManage jobPersonManage,
            IAbpSession IAbpSession

        )
        {
            _jobPersonRepository = jobPersonRepository;
            _jobPersonManage = jobPersonManage;
            _IAbpSession = IAbpSession;

        }


        #region 实体的自定义扩展方法
        private IQueryable<JobPerson> _jobPersonRepositoryAsNoTrack => _jobPersonRepository.GetAll().AsNoTracking();


        #endregion


        #region 职位用户表管理

        /// <summary>
        /// 根据查询条件获取职位用户表分页列表
        /// </summary>
        public async Task<PagedResultDto<JobPersonListDto>> GetPagedJobPersonsAsync(GetJobPersonInput input)
        {

            var query = _jobPersonRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var jobPersonCount = await query.CountAsync();

            var jobPersons = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var jobPersonListDtos = jobPersons.MapTo<List<JobPersonListDto>>();
            return new PagedResultDto<JobPersonListDto>(
            jobPersonCount,
            jobPersonListDtos
            );
        }

        /// <summary>
        /// 通过Id获取职位用户表信息进行编辑或修改 
        /// </summary>
        public async Task<GetJobPersonForEditOutput> GetJobPersonForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetJobPersonForEditOutput();

            JobPersonEditDto jobPersonEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _jobPersonRepository.GetAsync(input.Id.Value);
                jobPersonEditDto = entity.MapTo<JobPersonEditDto>();
            }
            else
            {
                jobPersonEditDto = new JobPersonEditDto();
            }

            output.JobPerson = jobPersonEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取职位用户表ListDto信息
        /// </summary>
        public async Task<JobPersonListDto> GetJobPersonByIdAsync(EntityDto<int> input)
        {
            var entity = await _jobPersonRepository.GetAsync(input.Id);

            return entity.MapTo<JobPersonListDto>();
        }







        /// <summary>
        /// 新增或更改职位用户表
        /// </summary>
        public async Task CreateOrUpdateJobPersonAsync(CreateOrUpdateJobPersonInput input)
        {
            if (input.JobPersonEditDto.Id.HasValue)
            {
                await UpdateJobPersonAsync(input.JobPersonEditDto);
            }
            else
            {
                await CreateJobPersonAsync(input.JobPersonEditDto);
            }
        }

        /// <summary>
        /// 新增职位用户表
        /// </summary>
        public virtual async Task<JobPersonEditDto> CreateJobPersonAsync(JobPersonEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<JobPerson>();

            entity = await _jobPersonRepository.InsertAsync(entity);
            return entity.MapTo<JobPersonEditDto>();
        }

        /// <summary>
        /// 编辑职位用户表
        /// </summary>
        public virtual async Task UpdateJobPersonAsync(JobPersonEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _jobPersonRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _jobPersonRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除职位用户表
        /// </summary>
        public async Task DeleteJobPersonAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _jobPersonRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除职位用户表
        /// </summary>
        public async Task BatchDeleteJobPersonAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _jobPersonRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        public async Task<int> CreateFactoryAsync(GetJobPersonInput input)
        {
            var _uid = Convert.ToInt32(  _IAbpSession.UserId.Value);
            if (input.JobId.HasValue && input.CompanyId.HasValue)
            {
                var _factory= await _jobPersonRepository.FirstOrDefaultAsync(t => t.JobID == input.JobId.Value && t.PersonID == _uid);
                if (_factory != null)
                    return 0;//已经投递
                JobPerson jobperson = new JobPerson();
                jobperson.CompanyID = input.CompanyId.Value;
                jobperson.JobID = input.JobId.Value;
                jobperson.PersonID = _uid;
                jobperson.PostDate = DateTime.Now;
                var returnid = await _jobPersonRepository.InsertAndGetIdAsync(jobperson);
                return returnid;
            }

            else
            {
                return 0;
            }

        }
        #endregion










    }
}
