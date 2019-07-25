 using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploee.JobPosts.Dtos;

namespace Emploee.Web.Areas.Mpa.Models.JobPostManage
{
    /// <summary>
    /// 新建或编辑职位发布时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetJobPostForEditOutput ))]
    public class CreateOrEditJobPostModalViewModel : GetJobPostForEditOutput
    {
		/// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
	   public CreateOrEditJobPostModalViewModel(GetJobPostForEditOutput output)
        {
            output.MapTo(this);
        }



		 /// <summary>
        /// 是否处于编辑状态
        /// </summary>
	  public bool IsEditMode { get { return JobPost.Id.HasValue; } }

	    
		
        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
