





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
using Emploee.Emploees.Companies.Authorization;
using Emploee.Emploees.Companies.Dtos;

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
// Copyright © YoYoCms@China.2019-07-24T16:21:04. All Rights Reserved.
//<生成时间>2019-07-24T16:21:04</生成时间>
#endregion


namespace Emploee.Emploees.Companies
{
    /// <summary>
    /// 企业信息服务实现
    /// </summary>
    [AbpAuthorize(CompanyAppPermissions.Company)]


    public class CompanyAppService : EmploeeAppServiceBase, ICompanyAppService
    {
        private readonly IRepository<Company, int> _companyRepository;
        private readonly ICompanyListExcelExporter _companyListExcelExporter;


        private readonly CompanyManage _companyManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyAppService(
            IRepository<Company, int> companyRepository,
            CompanyManage companyManage
            , ICompanyListExcelExporter companyListExcelExporter
        )
        {
            _companyRepository = companyRepository;
            _companyManage = companyManage;
            _companyListExcelExporter = companyListExcelExporter;
        }


        #region 实体的自定义扩展方法
        private IQueryable<Company> _companyRepositoryAsNoTrack => _companyRepository.GetAll().AsNoTracking();


        #endregion


        #region 企业信息管理

        /// <summary>
        /// 根据查询条件获取企业信息分页列表
        /// </summary>
        public async Task<PagedResultDto<CompanyListDto>> GetPagedCompanysAsync(GetCompanyInput input)
        {

            var query = _companyRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var companyCount = await query.CountAsync();

            var companys = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var companyListDtos = companys.MapTo<List<CompanyListDto>>();
            return new PagedResultDto<CompanyListDto>(
            companyCount,
            companyListDtos
            );
        }

        /// <summary>
        /// 通过Id获取企业信息信息进行编辑或修改 
        /// </summary>
        public async Task<GetCompanyForEditOutput> GetCompanyForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCompanyForEditOutput();

            CompanyEditDto companyEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _companyRepository.GetAsync(input.Id.Value);
                companyEditDto = entity.MapTo<CompanyEditDto>();
            }
            else
            {
                companyEditDto = new CompanyEditDto();
            }

            output.Company = companyEditDto;
            return output;
        }
        /// <summary>
        /// 通过Id获取企业信息信息进行编辑或修改 
        /// </summary>
        /// 
        [AbpAuthorize(CompanyAppPermissions.Company_EditCompany)]
        public async Task<GetCompanyForEditOutput> GetCompanyByCompanyID(long CompanyID)
        {
            var output = new GetCompanyForEditOutput();

            CompanyEditDto companyEditDto;
            var entity = await _companyRepository.FirstOrDefaultAsync(t=>t.CompanyID==CompanyID);
            companyEditDto = entity.MapTo<CompanyEditDto>();
            output.Company = companyEditDto;

            List<string> Finanicinglist = new List<string>
             {
                  "未融资",
                  "天使轮",
                  "A轮",
                  "B轮",
                  "C轮",
                  "D轮及以上",
                  "已上市",
                  "不需要融资"
             };
            List<string> CompanyScaleslist = new List<string>
             {
                  "0-20人",
                  "20-99人",
                  "100-499人",
                  "500-999人",
                  "1000-9999人",
                  "10000人以上"
             };
            output.Finanicings = Finanicinglist.Select(c => new ComboboxItemDto(c, c)
            {
                IsSelected = output.Company.Finanicing == c
            }).ToList();
            output.CompanyScales = CompanyScaleslist.Select(c => new ComboboxItemDto(c, c)
            {
                IsSelected = output.Company.CompanyScale == c
            }).ToList();

            return output;
        }

        /// <summary>
        /// 通过指定id获取企业信息ListDto信息
        /// </summary>
        public async Task<CompanyListDto> GetCompanyByIdAsync(EntityDto<int> input)
        {
            var entity = await _companyRepository.GetAsync(input.Id);

            return entity.MapTo<CompanyListDto>();
        }







        /// <summary>
        /// 新增或更改企业信息
        /// </summary>
        public async Task CreateOrUpdateCompanyAsync(CreateOrUpdateCompanyInput input)
        {
            if (input.CompanyEditDto.Id.HasValue)
            {
                await UpdateCompanyAsync(input.CompanyEditDto);
            }
            else
            {
                await CreateCompanyAsync(input.CompanyEditDto);
            }
        }

        /// <summary>
        /// 新增企业信息
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_CreateCompany)]
        public virtual async Task<CompanyEditDto> CreateCompanyAsync(CompanyEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Company>();

            entity = await _companyRepository.InsertAsync(entity);
            return entity.MapTo<CompanyEditDto>();
        }

        /// <summary>
        /// 编辑企业信息
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_EditCompany)]
        public virtual async Task UpdateCompanyAsync(CompanyEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _companyRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _companyRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除企业信息
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_DeleteCompany)]
        public async Task DeleteCompanyAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _companyRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除企业信息
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_DeleteCompany)]
        public async Task BatchDeleteCompanyAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _companyRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        #region 企业信息的Excel导出功能


        public async Task<FileDto> GetCompanyToExcel()
        {
            var entities = await _companyRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<CompanyListDto>>();

            var fileDto = _companyListExcelExporter.ExportCompanyToFile(dtos);



            return fileDto;
        }


        #endregion










    }
}
