 using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploee.PersonInfos.Dtos;

namespace Emploee.Web.Areas.Mpa.Models.PersonInfoManage
{
    /// <summary>
    /// 新建或编辑个人中心时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetPersonInfoForEditOutput ))]
    public class CreateOrEditPersonInfoModalViewModel : GetPersonInfoForEditOutput
    {
		/// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
	   public CreateOrEditPersonInfoModalViewModel(GetPersonInfoForEditOutput output)
        {
            output.MapTo(this);
        }



		 /// <summary>
        /// 是否处于编辑状态
        /// </summary>
	  public bool IsEditMode { get { return PersonInfo.Id.HasValue; } }

	    
		
        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
