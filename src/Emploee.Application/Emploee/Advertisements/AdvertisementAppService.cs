





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
using Emploee.Emploee.Advertisements.Authorization;
using Emploee.Emploee.Advertisements.Dtos;

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
// Copyright © YoYoCms@China.2019-07-25T10:55:19. All Rights Reserved.
//<生成时间>2019-07-25T10:55:19</生成时间>
#endregion


namespace Emploee.Emploee.Advertisements
{
    /// <summary>
    /// 广告服务实现
    /// </summary>
    [AbpAuthorize(AdvertisementAppPermissions.Advertisement)]


    public class AdvertisementAppService : EmploeeAppServiceBase, IAdvertisementAppService
    {
        private readonly IRepository<Advertisement, int> _advertisementRepository;
        private readonly IAdvertisementListExcelExporter _advertisementListExcelExporter;


        private readonly AdvertisementManage _advertisementManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public AdvertisementAppService(IRepository<Advertisement, int> advertisementRepository,
AdvertisementManage advertisementManage
      , IAdvertisementListExcelExporter advertisementListExcelExporter
  )
        {
            _advertisementRepository = advertisementRepository;
            _advertisementManage = advertisementManage;
            _advertisementListExcelExporter = advertisementListExcelExporter;
        }


        #region 实体的自定义扩展方法
        private IQueryable<Advertisement> _advertisementRepositoryAsNoTrack => _advertisementRepository.GetAll().AsNoTracking();


        #endregion


        #region 广告管理

        /// <summary>
        /// 根据查询条件获取广告分页列表
        /// </summary>
        public async Task<PagedResultDto<AdvertisementListDto>> GetPagedAdvertisementsAsync(GetAdvertisementInput input)
        {

            var query = _advertisementRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var advertisementCount = await query.CountAsync();

            var advertisements = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var advertisementListDtos = advertisements.MapTo<List<AdvertisementListDto>>();
            return new PagedResultDto<AdvertisementListDto>(
            advertisementCount,
            advertisementListDtos
            );
        }

        /// <summary>
        /// 通过Id获取广告信息进行编辑或修改 
        /// </summary>
        public async Task<GetAdvertisementForEditOutput> GetAdvertisementForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetAdvertisementForEditOutput();

            AdvertisementEditDto advertisementEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _advertisementRepository.GetAsync(input.Id.Value);
                advertisementEditDto = entity.MapTo<AdvertisementEditDto>();
            }
            else
            {
                advertisementEditDto = new AdvertisementEditDto();
            }

            output.Advertisement = advertisementEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取广告ListDto信息
        /// </summary>
        public async Task<AdvertisementListDto> GetAdvertisementByIdAsync(EntityDto<int> input)
        {
            var entity = await _advertisementRepository.GetAsync(input.Id);

            return entity.MapTo<AdvertisementListDto>();
        }







        /// <summary>
        /// 新增或更改广告
        /// </summary>
        public async Task CreateOrUpdateAdvertisementAsync(CreateOrUpdateAdvertisementInput input)
        {
            if (input.AdvertisementEditDto.Id.HasValue)
            {
                await UpdateAdvertisementAsync(input.AdvertisementEditDto);
            }
            else
            {
                await CreateAdvertisementAsync(input.AdvertisementEditDto);
            }
        }

        /// <summary>
        /// 新增广告
        /// </summary>
        [AbpAuthorize(AdvertisementAppPermissions.Advertisement_CreateAdvertisement)]
        public virtual async Task<AdvertisementEditDto> CreateAdvertisementAsync(AdvertisementEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Advertisement>();

            entity = await _advertisementRepository.InsertAsync(entity);
            return entity.MapTo<AdvertisementEditDto>();
        }

        /// <summary>
        /// 编辑广告
        /// </summary>
        [AbpAuthorize(AdvertisementAppPermissions.Advertisement_EditAdvertisement)]
        public virtual async Task UpdateAdvertisementAsync(AdvertisementEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _advertisementRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _advertisementRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除广告
        /// </summary>
        [AbpAuthorize(AdvertisementAppPermissions.Advertisement_DeleteAdvertisement)]
        public async Task DeleteAdvertisementAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _advertisementRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除广告
        /// </summary>
        [AbpAuthorize(AdvertisementAppPermissions.Advertisement_DeleteAdvertisement)]
        public async Task BatchDeleteAdvertisementAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _advertisementRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        #region 广告的Excel导出功能


        public async Task<FileDto> GetAdvertisementToExcel()
        {
            var entities = await _advertisementRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<AdvertisementListDto>>();

            var fileDto = _advertisementListExcelExporter.ExportAdvertisementToFile(dtos);



            return fileDto;
        }


        #endregion










    }
}
