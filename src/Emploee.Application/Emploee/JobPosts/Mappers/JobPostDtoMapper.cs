                            

using AutoMapper;
using Emploee.Emploee.JobPosts.Dtos;
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
// Copyright © YoYoCms@China.2019-07-24T17:49:46. All Rights Reserved.
//<生成时间>2019-07-24T17:49:46</生成时间>
	#endregion
namespace Emploee.Emploee.JobPosts.Mappers
{
	/// <summary>
    /// JobPostDto映射配置
    /// </summary>
    public class JobPostDtoMapper 
    {

    private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();



        /// <summary>
        /// 初始化映射
        /// </summary>
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
        
		  lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(configuration);

                _mappedBefore = true;
            }

        }
    




	    /// <summary>
       ///    Configuration.Modules.AbpAutoMapper().Configurators.Add(JobPostDtoMapper.CreateMappings);
      ///注入位置    < see cref = "EmploeeApplicationModule" /> 
     /// <param name="configuration"></param>
    /// </summary>       
	  private static void CreateMappingsInternal(IMapperConfigurationExpression configuration)
	  {
	           
			      //默认ABP功能已经实现了，如果你要单独对DTO进行拓展，可以在此处放开注释文件。

	  // Configuration.Modules.AbpAutoMapper().Configurators.Add(JobPostDtoMapper.CreateMappings);

	    //    Mapper.CreateMap<JobPost,JobPostEditDto>();
       //     Mapper.CreateMap<JobPost, JobPostListDto>();

     //       Mapper.CreateMap<JobPostEditDto, JobPost>();
    //        Mapper.CreateMap<JobPostListDto,JobPost>();
  






 	  }


}}