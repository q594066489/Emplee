using Emploee.Emploee.JobPosts;
using System.Threading.Tasks;
using System.Web.Mvc;
using Emploee.Web.Areas.Mpa.Models.JobPostManage;
namespace Emploee.Web.Controllers
{
    public class PersonHomeController : EmploeeControllerBase
    {
        private readonly IJobPostAppService _jobPostAppService;
        
         

        public PersonHomeController(IJobPostAppService jobPostAppService)
        {
            _jobPostAppService = jobPostAppService;
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 根据id获取进行编辑或者添加的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         
        public async Task<ActionResult> Introduce(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var output = await _jobPostAppService.GetJobIntroduce((int)id);


            var viewModel = new CreateOrEditJobPostModalViewModel(output);
            //if(viewModel.JobPost.SkillRequire!=null)
            //    viewModel.JobPost.SkillRequire= viewModel.JobPost.SkillRequire.Replace("\r\n", "<br />");
            //if (viewModel.JobPost.JobDetail != null)
            //    viewModel.JobPost.JobDetail=viewModel.JobPost.JobDetail.Replace("\r\n", "<br />");
            //if (viewModel.JobPost.Memo != null)
            //    viewModel.JobPost.Memo=viewModel.JobPost.Memo.Replace("\r\n", "<br />");
            return View("Introduce", viewModel);


        }
    }
}