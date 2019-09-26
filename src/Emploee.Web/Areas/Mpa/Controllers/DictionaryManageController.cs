
// 项目展示地址:"http://www.ddxc.org/"
// 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-12-28T09:13:40. All Rights Reserved.
//<生成时间>2017-12-28T09:13:40</生成时间>
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Emploee.Emploee.Dictionaries;
using Emploee.Emploee.Dictionaries.Authorization;
using Emploee.Emploee.Dictionaries.Dtos;
using Emploee.Web.Areas.Mpa.Models.DictionaryManage;
using Emploee.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Emploee.Web.Areas.Mpa.Controllers
{
    public class DictionaryManageController : EmploeeControllerBase
    {

        private readonly IDictionaryAppService _DictionaryAppService;

        public DictionaryManageController(IDictionaryAppService DictionaryAppService)
        {
            _DictionaryAppService = DictionaryAppService;
           
        }

        public  ActionResult Index()
        {
            // var model = new GetDictionaryInput {FilterText = Request.QueryString["filterText"]};

            try
            {
                var model = new DictionaryViewModel
                {
                    ParentCode = Request.QueryString["parentCode"],
                    ParentList = _DictionaryAppService.GetParentList(Request.QueryString["parentCode"])
                };


                return View(model);
            }
            catch
            {
                return   RedirectToAction("Index", "Home");
            }


           
        }

	 

			  /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[AbpMvcAuthorize(DictionaryAppPermissions.Dictionary_CreateDictionary,DictionaryAppPermissions.Dictionary_EditDictionary)]
        public async Task<PartialViewResult> CreateOrEditDictionaryModal(int? id,string parentCode)
        {
		var input=new NullableIdDto<int>{Id=id};
	 
                 var output=    await _DictionaryAppService.GetDictionaryForEditAsync(input);
            if (string.IsNullOrEmpty(output.Dictionary.ParentCode))
                output.Dictionary.ParentCode = parentCode;


                 var viewModel=new CreateOrEditDictionaryModalViewModel(output);


            return PartialView("_CreateOrEditDictionaryModal",viewModel);
        }
	 
       
    }
}