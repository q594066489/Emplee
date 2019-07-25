﻿        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-24T21:00:27. All Rights Reserved.
//<生成时间>2019-07-24T21:00:27</生成时间>
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Emploee.Emploee.JobPosts;
using Emploee.Emploee.JobPosts.Authorization;
using Emploee.Emploee.JobPosts.Dtos;
using Emploee.Web.Areas.Mpa.Models.JobPostManage;
using Emploee.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Emploee.Web.Areas.Mpa.Controllers
{
    public class JobPostManageController : EmploeeControllerBase
    {

        private readonly IJobPostAppService _jobPostAppService;

        public JobPostManageController(IJobPostAppService jobPostAppService)
        {
            _jobPostAppService = jobPostAppService;
           
        }

        public  ActionResult Index()
        {
		   var model = new GetJobPostInput {FilterText = Request.QueryString["filterText"]};
            return View(model);



           
        }

	 

			  /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[AbpMvcAuthorize(JobPostAppPermissions.JobPost_CreateJobPost,JobPostAppPermissions.JobPost_EditJobPost)]
        public async Task<PartialViewResult> CreateOrEditJobPostModal(int? id)
        {
		var input=new NullableIdDto<int>{Id=id};
	 
                 var output=    await _jobPostAppService.GetJobPostForEditAsync(input);

				 var viewModel=new CreateOrEditJobPostModalViewModel(output);


            return PartialView("_CreateOrEditJobPostModal",viewModel);
        }
	 
       
    }
}