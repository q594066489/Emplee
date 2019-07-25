                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Dto;
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
// Copyright © YoYoCms@China.2019-07-25T10:55:17. All Rights Reserved.
//<生成时间>2019-07-25T10:55:17</生成时间>
	#endregion
namespace Emploee.Emploee.Advertisements
{
	/// <summary>
    /// 广告服务接口
    /// </summary>
    public interface IAdvertisementAppService : IApplicationService
    {
        #region 广告管理

        /// <summary>
        /// 根据查询条件获取广告分页列表
        /// </summary>
        Task<PagedResultDto<AdvertisementListDto>> GetPagedAdvertisementsAsync(GetAdvertisementInput input);

        /// <summary>
        /// 通过Id获取广告信息进行编辑或修改 
        /// </summary>
        Task<GetAdvertisementForEditOutput> GetAdvertisementForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取广告ListDto信息
        /// </summary>
		Task<AdvertisementListDto> GetAdvertisementByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改广告
        /// </summary>
        Task CreateOrUpdateAdvertisementAsync(CreateOrUpdateAdvertisementInput input);





        /// <summary>
        /// 新增广告
        /// </summary>
        Task<AdvertisementEditDto> CreateAdvertisementAsync(AdvertisementEditDto input);

        /// <summary>
        /// 更新广告
        /// </summary>
        Task UpdateAdvertisementAsync(AdvertisementEditDto input);

        /// <summary>
        /// 删除广告
        /// </summary>
        Task DeleteAdvertisementAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除广告
        /// </summary>
        Task BatchDeleteAdvertisementAsync(List<int> input);

        #endregion

#region Excel导出功能



         /// <summary>
        /// 获取广告信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetAdvertisementToExcel();

#endregion





    }
}
