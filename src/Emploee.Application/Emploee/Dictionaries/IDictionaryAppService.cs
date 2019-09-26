                           
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Emploee.Dictionaries.Dtos;
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
// Copyright © YoYoCms@China.2019-07-25T13:16:06. All Rights Reserved.
//<生成时间>2019-07-25T13:16:06</生成时间>
	#endregion
namespace Emploee.Emploee.Dictionaries
{
	/// <summary>
    /// 数据字典服务接口
    /// </summary>
    public interface IDictionaryAppService : IApplicationService
    {
        #region 数据字典管理

        /// <summary>
        /// 根据查询条件获取数据字典分页列表
        /// </summary>
        Task<PagedResultDto<DictionaryListDto>> GetPagedDictionarysAsync(GetDictionaryInput input);

        /// <summary>
        /// 通过Id获取数据字典信息进行编辑或修改 
        /// </summary>
        Task<GetDictionaryForEditOutput> GetDictionaryForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取数据字典ListDto信息
        /// </summary>
		Task<DictionaryListDto> GetDictionaryByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改数据字典
        /// </summary>
        Task CreateOrUpdateDictionaryAsync(CreateOrUpdateDictionaryInput input);





        /// <summary>
        /// 新增数据字典
        /// </summary>
        Task<DictionaryEditDto> CreateDictionaryAsync(DictionaryEditDto input);

        /// <summary>
        /// 更新数据字典
        /// </summary>
        Task UpdateDictionaryAsync(DictionaryEditDto input);

        /// <summary>
        /// 删除数据字典
        /// </summary>
        Task DeleteDictionaryAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除数据字典
        /// </summary>
        Task BatchDeleteDictionaryAsync(List<int> input);

        #endregion



        Task<ListResultDto<DictionaryListDto>> GetDictionaryLists(string ParentCode);

        List<DictionaryListDto> GetParentList(string parentCode);

    }
}
