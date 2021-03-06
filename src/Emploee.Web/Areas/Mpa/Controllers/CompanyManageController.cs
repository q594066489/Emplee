﻿        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-24T16:52:40. All Rights Reserved.
//<生成时间>2019-07-24T16:52:40</生成时间>
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Emploee.Emploees.Companies;
using Emploee.Emploees.Companies.Authorization;
using Emploee.Emploees.Companies.Dtos;
using Emploee.Web.Areas.Mpa.Models.CompanyManage;
using Emploee.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vocs.Npoi;

namespace Emploee.Web.Areas.Mpa.Controllers
{
    public class CompanyManageController : EmploeeControllerBase
    {

        private readonly ICompanyAppService _companyAppService;
        private readonly IAbpSession _abpSession;
        public CompanyManageController(ICompanyAppService companyAppService
            , IAbpSession abpSession)
        {
            _companyAppService = companyAppService;
            _abpSession = abpSession;
        }

        public  ActionResult Index()
        {
		   var model = new GetCompanyInput {FilterText = Request.QueryString["filterText"]};
             
            return View(model);


        }

	 

			  /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[AbpMvcAuthorize(CompanyAppPermissions.Company_CreateCompany,CompanyAppPermissions.Company_EditCompany)]
        public async Task<PartialViewResult> CreateOrEditCompanyModal(int? id)
        {
		var input=new NullableIdDto<int>{Id=id};
	 
                 var output=    await _companyAppService.GetCompanyForEditAsync(input);

				 var viewModel=new CreateOrEditCompanyModalViewModel(output);


            return PartialView("_CreateOrEditCompanyModal", viewModel);
        }
        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AbpMvcAuthorize(CompanyAppPermissions.Company_EditCompany)]
        public async Task<ActionResult> CompanyInfo()
        {
            var sid=(long)_abpSession.UserId;
             

            var output = await _companyAppService.GetCompanyByCompanyID(sid);

            var viewModel = new CreateOrEditCompanyModalViewModel(output);


            return View("CompanyInfo", viewModel);
        }

        public ActionResult ImportCompanyManages(int? id)
        {
            return PartialView("_ImportCompanyManages");
        }
        /// <summary>
        /// 上传附件到服务器上
        /// </summary>
        /// <param name="fileData">附件信息</param>
        /// <param name="guid">附件组GUID</param>
        /// <param name="folder">指定的上传目录</param>
        /// <returns></returns>
        [DisableAbpAntiForgeryTokenValidation]
        public ActionResult UpLoadfileinput(string guid, string folder)
        {

            string strjson = string.Empty;
            HttpFileCollectionBase files = HttpContext.Request.Files;
            //获取返回文件信息
            UpLoadFile file = new UpLoadFile();
            var result = file.UpLoad(files,1);
            return Json(result);


        }
        public ActionResult ShowPicture(string src)
        {
            var viewModel = new ShowPictureModal(src);
            return PartialView("_ShowPicture", viewModel);
             
        }
    }
}