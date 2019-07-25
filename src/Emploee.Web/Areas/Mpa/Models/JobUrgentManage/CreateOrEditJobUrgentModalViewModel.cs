 using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploee.JobUrgents.Dtos;

namespace Emploee.Web.Areas.Mpa.Models.JobUrgentManage
{
    /// <summary>
    /// 新建或编辑职位加急时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetJobUrgentForEditOutput ))]
    public class CreateOrEditJobUrgentModalViewModel : GetJobUrgentForEditOutput
    {
		/// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
	   public CreateOrEditJobUrgentModalViewModel(GetJobUrgentForEditOutput output)
        {
            output.MapTo(this);
        }



		 /// <summary>
        /// 是否处于编辑状态
        /// </summary>
	  public bool IsEditMode { get { return JobUrgent.Id.HasValue; } }

	    
		
        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
