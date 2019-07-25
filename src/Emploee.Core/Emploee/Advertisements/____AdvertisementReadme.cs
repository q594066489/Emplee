
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-25T10:55:25. All Rights Reserved.
//<生成时间>2019-07-25T10:55:25</生成时间>
namespace Emploee.Emploee.Advertisements
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var advertisement=new MenuItemDefinition(
                AdvertisementAppPermissions.Advertisement,
                L("Advertisement"),
				url:"Mpa/AdvertisementManage",
				icon:"icon-grid",
				 				 requiredPermissionName: AdvertisementAppPermissions.Advertisement
				 					);

*/
				//有下级菜单
            /*

			   var advertisement=new MenuItemDefinition(
                AdvertisementAppPermissions.Advertisement,
                L("Advertisement"),			
				icon:"icon-grid"				
				);

				advertisement.AddItem(
			new MenuItemDefinition(
			AdvertisementAppPermissions.Advertisement,
			L("Advertisement"),
			"icon-star",
			url:"Mpa/AdvertisementManage",
				 			requiredPermissionName: AdvertisementAppPermissions.Advertisement));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到EmploeeApplicationModule
 //   Configuration.Authorization.Providers.Add<AdvertisementAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploeezh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 广告管理 -->
	    <text name="Advertisement" value="广告" />
	    <text name="AdvertisementHeaderInfo" value="广告管理列表" />
		    <text name="CreateAdvertisement" value="新增广告" />
    <text name="EditAdvertisement" value="编辑广告" />
    <text name="DeleteAdvertisement" value="删除广告" />

	  
		

		    <text name="AdvertisementDeleteWarningMessage" value="广告名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="Advertiser" value="厂家" />
				 	<text name="AdverPicture" value="图片" />
				 	<text name="AdverAddress" value="广告链接" />
				 	<text name="PayAmount" value="缴费金额" />
				 	<text name="PayTime" value="缴费时间" />
				 	<text name="CoopTime" value="缴费时长" />
				 	<text name="IsShow" value="是否显示" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploee.xml
/*
    <!-- 广告english管理 -->
		    <text name="	AdvertisementHeaderInfo" value="广告List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="Advertiser" value="厂家" />
				 	<text name="AdverPicture" value="图片" />
				 	<text name="AdverAddress" value="广告链接" />
				 	<text name="PayAmount" value="缴费金额" />
				 	<text name="PayTime" value="缴费时间" />
				 	<text name="CoopTime" value="缴费时长" />
				 	<text name="IsShow" value="是否显示" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Advertisement" value="ManagementAdvertisement" />
    <text name="CreateAdvertisement" value="CreateAdvertisement" />
    <text name="EditAdvertisement" value="EditAdvertisement" />
    <text name="DeleteAdvertisement" value="DeleteAdvertisement" />
*/




}