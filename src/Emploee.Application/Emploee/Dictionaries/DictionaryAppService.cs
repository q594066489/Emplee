                                
                            
                                 
     
        

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
	  using Emploee.Authorization;
using Emploee.Emploee.Dictionaries.Authorization;
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
// Copyright © YoYoCms@China.2019-07-25T13:16:07. All Rights Reserved.
//<生成时间>2019-07-25T13:16:07</生成时间>
	#endregion


    namespace Emploee.Emploee.Dictionaries
{
    /// <summary>
    /// 数据字典服务实现
    /// </summary>
          [AbpAuthorize(DictionaryAppPermissions.Dictionary)]
		 
       
    public class DictionaryAppService : EmploeeAppServiceBase, IDictionaryAppService
    {
        private readonly IRepository<Dictionary,int> _dictionaryRepository;
		

		private readonly DictionaryManage _dictionaryManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public DictionaryAppService( IRepository<Dictionary,int> dictionaryRepository	,
DictionaryManage dictionaryManage
	
  )
        {
            _dictionaryRepository = dictionaryRepository;
			 _dictionaryManage = dictionaryManage;
			 
        }


		  #region 实体的自定义扩展方法
        private IQueryable<Dictionary> _dictionaryRepositoryAsNoTrack => _dictionaryRepository.GetAll().AsNoTracking();


        #endregion


    #region 数据字典管理

    /// <summary>
    /// 根据查询条件获取数据字典分页列表
    /// </summary>
    public async Task<PagedResultDto<DictionaryListDto>> GetPagedDictionarysAsync(GetDictionaryInput input)
{
			
    var query = _dictionaryRepositoryAsNoTrack;
    //TODO:根据传入的参数添加过滤条件

    var dictionaryCount = await query.CountAsync();

    var dictionarys = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var dictionaryListDtos = dictionarys.MapTo<List<DictionaryListDto>>();
    return new PagedResultDto<DictionaryListDto>(
    dictionaryCount,
    dictionaryListDtos
    );
    }

        /// <summary>
    /// 通过Id获取数据字典信息进行编辑或修改 
    /// </summary>
    public async Task<GetDictionaryForEditOutput> GetDictionaryForEditAsync(NullableIdDto<int> input)
{
    var output=new GetDictionaryForEditOutput();

    DictionaryEditDto dictionaryEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _dictionaryRepository.GetAsync(input.Id.Value);
    dictionaryEditDto=entity.MapTo<DictionaryEditDto>();
    }
	else 
	{
	dictionaryEditDto=new DictionaryEditDto();	
	}

	output.Dictionary=dictionaryEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取数据字典ListDto信息
    /// </summary>
    public async Task<DictionaryListDto> GetDictionaryByIdAsync(EntityDto<int> input)
{
    var entity = await _dictionaryRepository.GetAsync(input.Id);

    return entity.MapTo<DictionaryListDto>();
    }







    /// <summary>
    /// 新增或更改数据字典
    /// </summary>
    public async Task CreateOrUpdateDictionaryAsync(CreateOrUpdateDictionaryInput input)
{
    if (input.DictionaryEditDto.Id.HasValue)
{
    await UpdateDictionaryAsync(input.DictionaryEditDto);
    }
    else
{
    await CreateDictionaryAsync(input.DictionaryEditDto);
    }
    }

    /// <summary>
    /// 新增数据字典
    /// </summary>
	        [AbpAuthorize(DictionaryAppPermissions.Dictionary_CreateDictionary)]	 
         public virtual async Task<DictionaryEditDto> CreateDictionaryAsync(DictionaryEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<Dictionary>();
	
    entity = await _dictionaryRepository.InsertAsync(entity);
    return entity.MapTo<DictionaryEditDto>();
    }

    /// <summary>
    /// 编辑数据字典
    /// </summary>
	      [AbpAuthorize(DictionaryAppPermissions.Dictionary_EditDictionary)]
         public virtual async Task UpdateDictionaryAsync(DictionaryEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _dictionaryRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _dictionaryRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除数据字典
    /// </summary>
	    [AbpAuthorize(DictionaryAppPermissions.Dictionary_DeleteDictionary)]
         public async Task DeleteDictionaryAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _dictionaryRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除数据字典
    /// </summary>
	    [AbpAuthorize(DictionaryAppPermissions.Dictionary_DeleteDictionary)]
         public async Task BatchDeleteDictionaryAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _dictionaryRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion
  









    }
    }
