
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-24T16:21:08. All Rights Reserved.
//<生成时间>2019-07-24T16:21:08</生成时间>
namespace Emploee.Emploees.Companies
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var company=new MenuItemDefinition(
                CompanyAppPermissions.Company,
                L("Company"),
				url:"Mpa/CompanyManage",
				icon:"icon-grid",
				 				 requiredPermissionName: CompanyAppPermissions.Company
				 					);

*/
				//有下级菜单
            /*

			   var company=new MenuItemDefinition(
                CompanyAppPermissions.Company,
                L("Company"),			
				icon:"icon-grid"				
				);

				company.AddItem(
			new MenuItemDefinition(
			CompanyAppPermissions.Company,
			L("Company"),
			"icon-star",
			url:"Mpa/CompanyManage",
				 			requiredPermissionName: CompanyAppPermissions.Company));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到EmploeesApplicationModule
 //   Configuration.Authorization.Providers.Add<CompanyAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploeeszh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 企业信息管理 -->
	    <text name="Company" value="企业信息" />
	    <text name="CompanyHeaderInfo" value="企业信息管理列表" />
		    <text name="CreateCompany" value="新增企业信息" />
    <text name="EditCompany" value="编辑企业信息" />
    <text name="DeleteCompany" value="删除企业信息" />

	  
		

		    <text name="CompanyDeleteWarningMessage" value="企业信息名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyName" value="企业名称" />
				 	<text name="CompanyEmail" value="邮箱" />
				 	<text name="CompanyPhone" value="联系电话" />
				 	<text name="CompanyAddress" value="公司地址" />
				 	<text name="CompanyScale" value="公司规模" />
				 	<text name="CompanyIntroduce" value="公司介绍" />
				 	<text name="Classify" value="行业类型" />
				 	<text name="Finanicing" value="融资阶段" />
				 	<text name="BussinessLicense" value="营业执照" />
				 	<text name="RegisterDate" value="注册时间" />
				 	<text name="isDelete" value="isDelete" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploees.xml
/*
    <!-- 企业信息english管理 -->
		    <text name="	CompanyHeaderInfo" value="企业信息List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="CompanyName" value="企业名称" />
				 	<text name="CompanyEmail" value="邮箱" />
				 	<text name="CompanyPhone" value="联系电话" />
				 	<text name="CompanyAddress" value="公司地址" />
				 	<text name="CompanyScale" value="公司规模" />
				 	<text name="CompanyIntroduce" value="公司介绍" />
				 	<text name="Classify" value="行业类型" />
				 	<text name="Finanicing" value="融资阶段" />
				 	<text name="BussinessLicense" value="营业执照" />
				 	<text name="RegisterDate" value="注册时间" />
				 	<text name="isDelete" value="isDelete" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Company" value="ManagementCompany" />
    <text name="CreateCompany" value="CreateCompany" />
    <text name="EditCompany" value="EditCompany" />
    <text name="DeleteCompany" value="DeleteCompany" />
*/




}