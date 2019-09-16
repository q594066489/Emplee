





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
using Emploee.Emploee.PersonInfos.Authorization;
using Emploee.Emploee.PersonInfos.Dtos;

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
// Copyright © YoYoCms@China.2019-07-24T22:14:54. All Rights Reserved.
//<生成时间>2019-07-24T22:14:54</生成时间>
#endregion


namespace Emploee.Emploee.PersonInfos
{
    /// <summary>
    /// 个人中心服务实现
    /// </summary>
    [AbpAuthorize(PersonInfoAppPermissions.PersonInfo)]


    public class PersonInfoAppService : EmploeeAppServiceBase, IPersonInfoAppService
    {
        private readonly IRepository<PersonInfo, int> _personInfoRepository;
        private readonly IPersonInfoListExcelExporter _personInfoListExcelExporter;
        private publicListDto pdto = new publicListDto();

        private readonly PersonInfoManage _personInfoManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public PersonInfoAppService(
            IRepository<PersonInfo, int> personInfoRepository
            , PersonInfoManage personInfoManage
            , IPersonInfoListExcelExporter personInfoListExcelExporter
        )
        {
            _personInfoRepository = personInfoRepository;
            _personInfoManage = personInfoManage;
            _personInfoListExcelExporter = personInfoListExcelExporter;
        }


        #region 实体的自定义扩展方法
        private IQueryable<PersonInfo> _personInfoRepositoryAsNoTrack => _personInfoRepository.GetAll().AsNoTracking();


        #endregion


        #region 个人中心管理

        /// <summary>
        /// 根据查询条件获取个人中心分页列表
        /// </summary>
        public async Task<PagedResultDto<PersonInfoListDto>> GetPagedPersonInfos(GetPersonInfoInput input)
        {

            var query = _personInfoRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var personInfoCount = await query.CountAsync();

            var personInfos = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var personInfoListDtos = personInfos.MapTo<List<PersonInfoListDto>>();
            return new PagedResultDto<PersonInfoListDto>(
            personInfoCount,
            personInfoListDtos
            );
        }

        /// <summary>
        /// 通过Id获取个人中心信息进行编辑或修改 
        /// </summary>
        public async Task<GetPersonInfoForEditOutput> GetPersonInfoForEditAsync(NullableIdDto<long> input)
        {

            var output = new GetPersonInfoForEditOutput();

            PersonInfoEditDto personInfoEditDto;

            if (input.Id.HasValue)
            {
                long _personid = (long)input.Id;
                var entity = await _personInfoRepository.FirstOrDefaultAsync(u => u.PersonID == _personid);
                personInfoEditDto = entity.MapTo<PersonInfoEditDto>();
            }
            else
            {
                personInfoEditDto = new PersonInfoEditDto();
            }
            output.PersonInfo = personInfoEditDto;
            List<string> ExpectTradeslist = pdto.GetClassigys();
            List<string> JobYearslist = pdto.GetExperiencesforperson();

            List<string> Stateslist = pdto.GetState();

            output.ExpectTrades = ExpectTradeslist.Select(c => new ComboboxItemDto(c, c)
            {
                IsSelected = output.PersonInfo.ExpectTrade == c
            }).ToList();
            output.JobYears = JobYearslist.Select(c => new ComboboxItemDto(c, c)
            {
                IsSelected = output.PersonInfo.JobYear == c
            }).ToList();
            output.States = Stateslist.Select(c => new ComboboxItemDto(c, c)
            {
                IsSelected = output.PersonInfo.State == c
            }).ToList();

            return output;
        }


        /// <summary>
        /// 通过指定id获取个人中心ListDto信息
        /// </summary>
        public async Task<PersonInfoListDto> GetPersonInfoByIdAsync(EntityDto<int> input)
        {
            var entity = await _personInfoRepository.GetAsync(input.Id);

            return entity.MapTo<PersonInfoListDto>();
        }







        /// <summary>
        /// 新增或更改个人中心
        /// </summary>
        public async Task CreateOrUpdatePersonInfoAsync(CreateOrUpdatePersonInfoInput input)
        {
            if (input.PersonInfoEditDto.Id.HasValue)
            {
                await UpdatePersonInfoAsync(input.PersonInfoEditDto);
            }
            else
            {
                await CreatePersonInfoAsync(input.PersonInfoEditDto);
            }
        }

        /// <summary>
        /// 新增个人中心
        /// </summary>
        [AbpAuthorize(PersonInfoAppPermissions.PersonInfo_CreatePersonInfo)]
        public virtual async Task<PersonInfoEditDto> CreatePersonInfoAsync(PersonInfoEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<PersonInfo>();

            entity = await _personInfoRepository.InsertAsync(entity);
            return entity.MapTo<PersonInfoEditDto>();
        }

        /// <summary>
        /// 编辑个人中心
        /// </summary>
        [AbpAuthorize(PersonInfoAppPermissions.PersonInfo_EditPersonInfo)]
        public virtual async Task UpdatePersonInfoAsync(PersonInfoEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _personInfoRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _personInfoRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除个人中心
        /// </summary>
        [AbpAuthorize(PersonInfoAppPermissions.PersonInfo_DeletePersonInfo)]
        public async Task DeletePersonInfoAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _personInfoRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除个人中心
        /// </summary>
        [AbpAuthorize(PersonInfoAppPermissions.PersonInfo_DeletePersonInfo)]
        public async Task BatchDeletePersonInfoAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _personInfoRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        #region 个人中心的Excel导出功能


        public async Task<FileDto> GetPersonInfoToExcel()
        {
            var entities = await _personInfoRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<PersonInfoListDto>>();

            var fileDto = _personInfoListExcelExporter.ExportPersonInfoToFile(dtos);



            return fileDto;
        }


        #endregion










    }
}
