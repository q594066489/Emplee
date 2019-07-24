
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-24T21:24:00. All Rights Reserved.
//<生成时间>2019-07-24T21:24:00</生成时间>
namespace Emploee.Emploee.JobUrgents
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var jobUrgent=new MenuItemDefinition(
                JobUrgentAppPermissions.JobUrgent,
                L("JobUrgent"),
				url:"Mpa/JobUrgentManage",
				icon:"icon-grid",
				 				 requiredPermissionName: JobUrgentAppPermissions.JobUrgent
				 					);

*/
				//有下级菜单
            /*

			   var jobUrgent=new MenuItemDefinition(
                JobUrgentAppPermissions.JobUrgent,
                L("JobUrgent"),			
				icon:"icon-grid"				
				);

				jobUrgent.AddItem(
			new MenuItemDefinition(
			JobUrgentAppPermissions.JobUrgent,
			L("JobUrgent"),
			"icon-star",
			url:"Mpa/JobUrgentManage",
				 			requiredPermissionName: JobUrgentAppPermissions.JobUrgent));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到EmploeeApplicationModule
 //   Configuration.Authorization.Providers.Add<JobUrgentAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploeezh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 职位加急管理 -->
	    <text name="JobUrgent" value="职位加急" />
	    <text name="JobUrgentHeaderInfo" value="职位加急管理列表" />
		    <text name="CreateJobUrgent" value="新增职位加急" />
    <text name="EditJobUrgent" value="编辑职位加急" />
    <text name="DeleteJobUrgent" value="删除职位加急" />

	  
		

		    <text name="JobUrgentDeleteWarningMessage" value="职位加急名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="JobId" value="职位编号" />
				 	<text name="Weight" value="权重" />
				 	<text name="UrgentType" value="加急类型" />
				 	<text name="UrgentDate" value="起始时间" />
				 	<text name="UrgentLength" value="持续时长" />
				 	<text name="isDelete" value="是否有效" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploee.xml
/*
    <!-- 职位加急english管理 -->
		    <text name="	JobUrgentHeaderInfo" value="职位加急List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="JobId" value="职位编号" />
				 	<text name="Weight" value="权重" />
				 	<text name="UrgentType" value="加急类型" />
				 	<text name="UrgentDate" value="起始时间" />
				 	<text name="UrgentLength" value="持续时长" />
				 	<text name="isDelete" value="是否有效" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="JobUrgent" value="ManagementJobUrgent" />
    <text name="CreateJobUrgent" value="CreateJobUrgent" />
    <text name="EditJobUrgent" value="EditJobUrgent" />
    <text name="DeleteJobUrgent" value="DeleteJobUrgent" />
*/




}