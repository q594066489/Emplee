 using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Approvals.Dtos;

namespace Emploee.Web.Areas.Mpa.Models.ApprovalManage
{
    /// <summary>
    /// 新建或编辑企业注册审批时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetApprovalForEditOutput ))]
    public class CreateOrEditApprovalModalViewModel : GetApprovalForEditOutput
    {
		/// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
	   public CreateOrEditApprovalModalViewModel(GetApprovalForEditOutput output)
        {
            output.MapTo(this);
        }



		 /// <summary>
        /// 是否处于编辑状态
        /// </summary>
	  public bool IsEditMode { get { return Approval.Id.HasValue; } }

	    
		
        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
