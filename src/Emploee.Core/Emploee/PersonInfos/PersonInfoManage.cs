                          
 
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
 #region 代码生成器相关信息_ABP Code Generator Info
   //你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
   //我的邮箱:werltm@hotmail.com
   // 官方网站:"http://www.yoyocms.com"
 // 交流QQ群：104390185  
 //微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2019-07-24T22:14:59. All Rights Reserved.
//<生成时间>2019-07-24T22:14:59</生成时间>
	#endregion
namespace Emploee.Emploee.PersonInfos
{
    /// <summary>
    /// 个人中心业务管理
    /// </summary>
    public class PersonInfoManage : IDomainService
    {
        private readonly IRepository<PersonInfo,int> _personInfoRepository;

         /// <summary>
        /// 构造方法
        /// </summary>
        public PersonInfoManage(IRepository<PersonInfo,int> personInfoRepository  )
        {
            _personInfoRepository = personInfoRepository;
        }

		//TODO:编写领域业务代码


		/// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {


 

        }


		}

    
	
}
