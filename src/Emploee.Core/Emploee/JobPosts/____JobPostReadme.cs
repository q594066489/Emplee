
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-24T17:49:47. All Rights Reserved.
//<生成时间>2019-07-24T17:49:47</生成时间>
namespace Emploee.Emploee.JobPosts
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var jobPost=new MenuItemDefinition(
                JobPostAppPermissions.JobPost,
                L("JobPost"),
				url:"Mpa/JobPostManage",
				icon:"icon-grid",
				 				 requiredPermissionName: JobPostAppPermissions.JobPost
				 					);

*/
				//有下级菜单
            /*

			   var jobPost=new MenuItemDefinition(
                JobPostAppPermissions.JobPost,
                L("JobPost"),			
				icon:"icon-grid"				
				);

				jobPost.AddItem(
			new MenuItemDefinition(
			JobPostAppPermissions.JobPost,
			L("JobPost"),
			"icon-star",
			url:"Mpa/JobPostManage",
				 			requiredPermissionName: JobPostAppPermissions.JobPost));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到EmploeeApplicationModule
 //   Configuration.Authorization.Providers.Add<JobPostAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploeezh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 职位发布管理 -->
	    <text name="JobPost" value="职位发布" />
	    <text name="JobPostHeaderInfo" value="职位发布管理列表" />
		    <text name="CreateJobPost" value="新增职位发布" />
    <text name="EditJobPost" value="编辑职位发布" />
    <text name="DeleteJobPost" value="删除职位发布" />

	  
		

		    <text name="JobPostDeleteWarningMessage" value="职位发布名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyId" value="企业编号" />
				 	<text name="JobName" value="职位名称" />
				 	<text name="SalaryMin" value="薪资min" />
				 	<text name="SalaryMax" value="薪资max" />
				 	<text name="Education" value="学历" />
				 	<text name="Experience" value="工作经验" />
				 	<text name="JobAddress" value="工作地点" />
				 	<text name="SkillRequire" value="技能要求" />
				 	<text name="JobDetail" value="职位详情" />
				 	<text name="JobSelect" value="行业选择" />
				 	<text name="JobType" value="职位类型" />
				 	<text name="PublishDate" value="发布时间" />
				 	<text name="isDelete" value="是否有效" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploee.xml
/*
    <!-- 职位发布english管理 -->
		    <text name="	JobPostHeaderInfo" value="职位发布List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyId" value="企业编号" />
				 	<text name="JobName" value="职位名称" />
				 	<text name="SalaryMin" value="薪资min" />
				 	<text name="SalaryMax" value="薪资max" />
				 	<text name="Education" value="学历" />
				 	<text name="Experience" value="工作经验" />
				 	<text name="JobAddress" value="工作地点" />
				 	<text name="SkillRequire" value="技能要求" />
				 	<text name="JobDetail" value="职位详情" />
				 	<text name="JobSelect" value="行业选择" />
				 	<text name="JobType" value="职位类型" />
				 	<text name="PublishDate" value="发布时间" />
				 	<text name="isDelete" value="是否有效" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="JobPost" value="ManagementJobPost" />
    <text name="CreateJobPost" value="CreateJobPost" />
    <text name="EditJobPost" value="EditJobPost" />
    <text name="DeleteJobPost" value="DeleteJobPost" />
*/




}