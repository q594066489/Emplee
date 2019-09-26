        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-24T21:49:47. All Rights Reserved.
//<生成时间>2019-07-24T21:49:47</生成时间>
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Emploee.Emploee.JobUrgents;
using Emploee.Emploee.JobUrgents.Authorization;
using Emploee.Emploee.JobUrgents.Dtos;
using Emploee.Web.Areas.Mpa.Models.JobUrgentManage;
using Emploee.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Emploee.Web.Areas.Mpa.Controllers
{
    public class JobUrgentManageController : EmploeeControllerBase
    {

        private readonly IJobUrgentAppService _jobUrgentAppService;

        public JobUrgentManageController(IJobUrgentAppService jobUrgentAppService)
        {
            _jobUrgentAppService = jobUrgentAppService;
           
        }

        public  ActionResult Index()
        {
		   var model = new GetJobUrgentInput {FilterText = Request.QueryString["filterText"]};
            return View(model);



           
        }

	 

			  /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[AbpMvcAuthorize(JobUrgentAppPermissions.JobUrgent_CreateJobUrgent,JobUrgentAppPermissions.JobUrgent_EditJobUrgent)]
        public async Task<PartialViewResult> CreateOrEditJobUrgentModal(int? id,int JobId)
        {
		var input=new NullableIdDto<int>{Id=id};
	 
                 var output=    await _jobUrgentAppService.GetJobUrgentForEditAsync(input);
            output.JobUrgent.JobId = JobId;
				 var viewModel=new CreateOrEditJobUrgentModalViewModel(output);


            return PartialView("_CreateOrEditJobUrgentModal",viewModel);
        }
	 
       
    }
}