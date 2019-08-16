
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-08-13T10:03:40. All Rights Reserved.
//<生成时间>2019-08-13T10:03:40</生成时间>
namespace Emploee.Emploee.Job_Positions
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var jobPosition=new MenuItemDefinition(
                JobPositionAppPermissions.JobPosition,
                L("JobPosition"),
				url:"Mpa/JobPositionManage",
				icon:"icon-grid",
				 				 requiredPermissionName: JobPositionAppPermissions.JobPosition
				 					);

*/
				//有下级菜单
            /*

			   var jobPosition=new MenuItemDefinition(
                JobPositionAppPermissions.JobPosition,
                L("JobPosition"),			
				icon:"icon-grid"				
				);

				jobPosition.AddItem(
			new MenuItemDefinition(
			JobPositionAppPermissions.JobPosition,
			L("JobPosition"),
			"icon-star",
			url:"Mpa/JobPositionManage",
				 			requiredPermissionName: JobPositionAppPermissions.JobPosition));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到EmploeeApplicationModule
 //   Configuration.Authorization.Providers.Add<JobPositionAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploeezh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 管理 -->
	    <text name="JobPosition" value="" />
	    <text name="JobPositionHeaderInfo" value="管理列表" />
		    <text name="CreateJobPosition" value="新增" />
    <text name="EditJobPosition" value="编辑" />
    <text name="DeleteJobPosition" value="删除" />

	  
		

		    <text name="JobPositionDeleteWarningMessage" value="名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="Position_no" value="Position_no" />
				 	<text name="Position_name" value="Position_name" />
				 	<text name="Parent_id" value="Parent_id" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploee.xml
/*
    <!-- english管理 -->
		    <text name="	JobPositionHeaderInfo" value="List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Position_no" value="Position_no" />
				 	<text name="Position_name" value="Position_name" />
				 	<text name="Parent_id" value="Parent_id" />
				 
    <text name="JobPosition" value="ManagementJobPosition" />
    <text name="CreateJobPosition" value="CreateJobPosition" />
    <text name="EditJobPosition" value="EditJobPosition" />
    <text name="DeleteJobPosition" value="DeleteJobPosition" />
*/




}