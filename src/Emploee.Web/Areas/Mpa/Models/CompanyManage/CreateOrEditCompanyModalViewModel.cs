 using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploees.Companies.Dtos;

namespace Emploee.Web.Areas.Mpa.Models.CompanyManage
{
    /// <summary>
    /// 新建或编辑公司信息时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetCompanyForEditOutput ))]
    public class CreateOrEditCompanyModalViewModel : GetCompanyForEditOutput
    {
		/// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
	   public CreateOrEditCompanyModalViewModel(GetCompanyForEditOutput output)
        {
            output.MapTo(this);
        }



		 /// <summary>
        /// 是否处于编辑状态
        /// </summary>
	  public bool IsEditMode { get { return Company.Id.HasValue; } }

	    
		
        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
