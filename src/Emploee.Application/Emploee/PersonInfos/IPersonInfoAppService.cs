                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Dto;
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
// Copyright © YoYoCms@China.2019-07-24T22:14:53. All Rights Reserved.
//<生成时间>2019-07-24T22:14:53</生成时间>
	#endregion
namespace Emploee.Emploee.PersonInfos
{
	/// <summary>
    /// 个人中心服务接口
    /// </summary>
    public interface IPersonInfoAppService : IApplicationService
    {
        #region 个人中心管理

        /// <summary>
        /// 根据查询条件获取个人中心分页列表
        /// </summary>
        Task<PagedResultDto<PersonInfoListDto>> GetPagedPersonInfosAsync(GetPersonInfoInput input);

        /// <summary>
        /// 通过Id获取个人中心信息进行编辑或修改 
        /// </summary>
        Task<GetPersonInfoForEditOutput> GetPersonInfoForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取个人中心ListDto信息
        /// </summary>
		Task<PersonInfoListDto> GetPersonInfoByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改个人中心
        /// </summary>
        Task CreateOrUpdatePersonInfoAsync(CreateOrUpdatePersonInfoInput input);





        /// <summary>
        /// 新增个人中心
        /// </summary>
        Task<PersonInfoEditDto> CreatePersonInfoAsync(PersonInfoEditDto input);

        /// <summary>
        /// 更新个人中心
        /// </summary>
        Task UpdatePersonInfoAsync(PersonInfoEditDto input);

        /// <summary>
        /// 删除个人中心
        /// </summary>
        Task DeletePersonInfoAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除个人中心
        /// </summary>
        Task BatchDeletePersonInfoAsync(List<int> input);

        #endregion

#region Excel导出功能



         /// <summary>
        /// 获取个人中心信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetPersonInfoToExcel();

#endregion





    }
}
