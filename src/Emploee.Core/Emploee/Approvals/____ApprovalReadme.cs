﻿
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-25T10:30:58. All Rights Reserved.
//<生成时间>2019-07-25T10:30:58</生成时间>
namespace Emploee.Approvals
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var approval=new MenuItemDefinition(
                ApprovalAppPermissions.Approval,
                L("Approval"),
				url:"Mpa/ApprovalManage",
				icon:"icon-grid",
				 				 requiredPermissionName: ApprovalAppPermissions.Approval
				 					);

*/
				//有下级菜单
            /*

			   var approval=new MenuItemDefinition(
                ApprovalAppPermissions.Approval,
                L("Approval"),			
				icon:"icon-grid"				
				);

				approval.AddItem(
			new MenuItemDefinition(
			ApprovalAppPermissions.Approval,
			L("Approval"),
			"icon-star",
			url:"Mpa/ApprovalManage",
				 			requiredPermissionName: ApprovalAppPermissions.Approval));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到EmploeeApplicationModule
 //   Configuration.Authorization.Providers.Add<ApprovalAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploeezh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 企业注册审批管理 -->
	    <text name="Approval" value="企业注册审批" />
	    <text name="ApprovalHeaderInfo" value="企业注册审批管理列表" />
		    <text name="CreateApproval" value="新增企业注册审批" />
    <text name="EditApproval" value="编辑企业注册审批" />
    <text name="DeleteApproval" value="删除企业注册审批" />

	  
		

		    <text name="ApprovalDeleteWarningMessage" value="企业注册审批名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyID" value="企业编号" />
				 	<text name="RegisterDate" value="注册时间" />
				 	<text name="IsPay" value="是否交款" />
				 	<text name="PayAmount" value="交款金额" />
				 	<text name="PayTime" value="交款时间" />
				 	<text name="CoopTime" value="缴费时长" />
				 	<text name="Weight" value="权重" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploee.xml
/*
    <!-- 企业注册审批english管理 -->
		    <text name="	ApprovalHeaderInfo" value="企业注册审批List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyID" value="企业编号" />
				 	<text name="RegisterDate" value="注册时间" />
				 	<text name="IsPay" value="是否交款" />
				 	<text name="PayAmount" value="交款金额" />
				 	<text name="PayTime" value="交款时间" />
				 	<text name="CoopTime" value="缴费时长" />
				 	<text name="Weight" value="权重" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Approval" value="ManagementApproval" />
    <text name="CreateApproval" value="CreateApproval" />
    <text name="EditApproval" value="EditApproval" />
    <text name="DeleteApproval" value="DeleteApproval" />
*/




}