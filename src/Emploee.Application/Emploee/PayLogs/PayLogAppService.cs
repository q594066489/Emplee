                                
                            
                                 
     
        

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
	  using Emploee.PayLogs.Authorization;  
    using Emploee.PayLogs.Dtos; 

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
// Copyright © YoYoCms@China.2019-09-03T16:25:37. All Rights Reserved.
//<生成时间>2019-09-03T16:25:37</生成时间>
	#endregion


    namespace Emploee.PayLogs
{
    /// <summary>
    /// 交款记录服务实现
    /// </summary>
          [AbpAuthorize(PayLogAppPermissions.PayLog)]
		 
       
    public class PayLogAppService : EmploeeAppServiceBase, IPayLogAppService
    {
        private readonly IRepository<PayLog,int> _payLogRepository;
		

		private readonly PayLogManage _payLogManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public PayLogAppService( IRepository<PayLog,int> payLogRepository	,
PayLogManage payLogManage
	
  )
        {
            _payLogRepository = payLogRepository;
			 _payLogManage = payLogManage;
			 
        }


		  #region 实体的自定义扩展方法
        private IQueryable<PayLog> _payLogRepositoryAsNoTrack => _payLogRepository.GetAll().AsNoTracking();


        #endregion


    #region 交款记录管理

    /// <summary>
    /// 根据查询条件获取交款记录分页列表
    /// </summary>
    public async Task<PagedResultDto<PayLogListDto>> GetPagedPayLogsAsync(GetPayLogInput input)
{
			
    var query = _payLogRepositoryAsNoTrack;
    //TODO:根据传入的参数添加过滤条件

    var payLogCount = await query.CountAsync();

    var payLogs = await query
    .OrderBy(input.Sorting)
    .PageBy(input)
    .ToListAsync();

    var payLogListDtos = payLogs.MapTo<List<PayLogListDto>>();
    return new PagedResultDto<PayLogListDto>(
    payLogCount,
    payLogListDtos
    );
    }

        /// <summary>
    /// 通过Id获取交款记录信息进行编辑或修改 
    /// </summary>
    public async Task<GetPayLogForEditOutput> GetPayLogForEditAsync(NullableIdDto<int> input)
{
    var output=new GetPayLogForEditOutput();

    PayLogEditDto payLogEditDto;

    if(input.Id.HasValue)
	{
    var entity=await _payLogRepository.GetAsync(input.Id.Value);
    payLogEditDto=entity.MapTo<PayLogEditDto>();
    }
	else 
	{
	payLogEditDto=new PayLogEditDto();	
	}

	output.PayLog=payLogEditDto;
	return output;
    }


    /// <summary>
    /// 通过指定id获取交款记录ListDto信息
    /// </summary>
    public async Task<PayLogListDto> GetPayLogByIdAsync(EntityDto<int> input)
{
    var entity = await _payLogRepository.GetAsync(input.Id);

    return entity.MapTo<PayLogListDto>();
    }







    /// <summary>
    /// 新增或更改交款记录
    /// </summary>
    public async Task CreateOrUpdatePayLogAsync(CreateOrUpdatePayLogInput input)
{
    if (input.PayLogEditDto.Id.HasValue)
{
    await UpdatePayLogAsync(input.PayLogEditDto);
    }
    else
{
    await CreatePayLogAsync(input.PayLogEditDto);
    }
    }

    /// <summary>
    /// 新增交款记录
    /// </summary>
	        [AbpAuthorize(PayLogAppPermissions.PayLog_CreatePayLog)]	 
         public virtual async Task<PayLogEditDto> CreatePayLogAsync(PayLogEditDto input)
{
    //TODO:新增前的逻辑判断，是否允许新增

	var entity = input.MapTo<PayLog>();
	
    entity = await _payLogRepository.InsertAsync(entity);
    return entity.MapTo<PayLogEditDto>();
    }

    /// <summary>
    /// 编辑交款记录
    /// </summary>
	      [AbpAuthorize(PayLogAppPermissions.PayLog_EditPayLog)]
         public virtual async Task UpdatePayLogAsync(PayLogEditDto input)
{
    //TODO:更新前的逻辑判断，是否允许更新

    var entity = await _payLogRepository.GetAsync(input.Id.Value);
	input.MapTo(entity);

    await _payLogRepository.UpdateAsync(entity);
    }

    /// <summary>
    /// 删除交款记录
    /// </summary>
	    [AbpAuthorize(PayLogAppPermissions.PayLog_DeletePayLog)]
         public async Task DeletePayLogAsync(EntityDto<int> input)
{
    //TODO:删除前的逻辑判断，是否允许删除
    await _payLogRepository.DeleteAsync(input.Id);
    }

        /// <summary>
    /// 批量删除交款记录
    /// </summary>
	    [AbpAuthorize(PayLogAppPermissions.PayLog_DeletePayLog)]
         public async Task BatchDeletePayLogAsync(List<int> input)
{
    //TODO:批量删除前的逻辑判断，是否允许删除
    await _payLogRepository.DeleteAsync(s=>input.Contains(s.Id));
    }

            #endregion
  









    }
    }
