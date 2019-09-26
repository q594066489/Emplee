using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploee.Dictionaries.Dtos;

namespace Emploee.Web.Areas.Mpa.Models.DictionaryManage
{
    /// <summary>
    /// 新建或编辑数据字典时使用的Viewmodel
    /// </summary>
    [AutoMap(typeof(GetDictionaryForEditOutput))]
    public class CreateOrEditDictionaryModalViewModel : GetDictionaryForEditOutput
    {
		/// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="output"></param>
	   public CreateOrEditDictionaryModalViewModel(GetDictionaryForEditOutput output)
        {
            output.MapTo(this);
        }



		 /// <summary>
        /// 是否处于编辑状态
        /// </summary>
	  public bool IsEditMode { get { return Dictionary.Id.HasValue; } }

	    
		
        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string FilterText { get; set; }

    }
}
