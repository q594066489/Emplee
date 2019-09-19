        
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-24T22:27:19. All Rights Reserved.
//<生成时间>2019-07-24T22:27:19</生成时间>
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Authorization;
using Emploee.Emploee.PersonInfos;
using Emploee.Emploee.PersonInfos.Authorization;
using Emploee.Emploee.PersonInfos.Dtos;
using Emploee.Web.Models.PersonInfoManage;
using Emploee.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Security.AntiForgery;
using System.Web;
using Vocs.Npoi;

namespace Emploee.Web.Controllers
{
    public class PersonInfoManageController : EmploeeControllerBase
    {

        private readonly IPersonInfoAppService _personInfoAppService;
        private readonly IAbpSession _IAbpSession;
        public PersonInfoManageController(IPersonInfoAppService personInfoAppService
            , IAbpSession IAbpSession)
        {
            _personInfoAppService = personInfoAppService;
            _IAbpSession = IAbpSession;


        }

        public async Task<ActionResult> Index()
        {

            try
            {


                var input = new NullableIdDto<long> { Id = _IAbpSession.UserId };

                var output = await _personInfoAppService.GetPersonInfoForEditAsync(input);

                var viewModel = new CreateOrEditPersonInfoModalViewModel(output);


                return View("index", viewModel);
            }
            catch 
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult ImportPersonManages(int? id)
        {
            return PartialView("_ImportPersonManages");
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
            var result = file.UpLoad(files);
            return Json(result);


        }

    }
}