
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-09-03T16:25:46. All Rights Reserved.
//<生成时间>2019-09-03T16:25:46</生成时间>
namespace Emploee.PayLogs
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var payLog=new MenuItemDefinition(
                PayLogAppPermissions.PayLog,
                L("PayLog"),
				url:"Mpa/PayLogManage",
				icon:"icon-grid",
				 				 requiredPermissionName: PayLogAppPermissions.PayLog
				 					);

*/
				//有下级菜单
            /*

			   var payLog=new MenuItemDefinition(
                PayLogAppPermissions.PayLog,
                L("PayLog"),			
				icon:"icon-grid"				
				);

				payLog.AddItem(
			new MenuItemDefinition(
			PayLogAppPermissions.PayLog,
			L("PayLog"),
			"icon-star",
			url:"Mpa/PayLogManage",
				 			requiredPermissionName: PayLogAppPermissions.PayLog));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到EmploeeApplicationModule
 //   Configuration.Authorization.Providers.Add<PayLogAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploeezh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 交款记录管理 -->
	    <text name="PayLog" value="交款记录" />
	    <text name="PayLogHeaderInfo" value="交款记录管理列表" />
		    <text name="CreatePayLog" value="新增交款记录" />
    <text name="EditPayLog" value="编辑交款记录" />
    <text name="DeletePayLog" value="删除交款记录" />

	  
		

		    <text name="PayLogDeleteWarningMessage" value="交款记录名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyID" value="企业编号" />
				 	<text name="PayAmount" value="交款金额" />
				 	<text name="PayTime" value="交款时间" />
				 	<text name="CoopTime" value="缴费时长" />
				 	<text name="Weight" value="权重" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploee.xml
/*
    <!-- 交款记录english管理 -->
		    <text name="	PayLogHeaderInfo" value="交款记录List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyID" value="企业编号" />
				 	<text name="PayAmount" value="交款金额" />
				 	<text name="PayTime" value="交款时间" />
				 	<text name="CoopTime" value="缴费时长" />
				 	<text name="Weight" value="权重" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="PayLog" value="ManagementPayLog" />
    <text name="CreatePayLog" value="CreatePayLog" />
    <text name="EditPayLog" value="EditPayLog" />
    <text name="DeletePayLog" value="DeletePayLog" />
*/




}