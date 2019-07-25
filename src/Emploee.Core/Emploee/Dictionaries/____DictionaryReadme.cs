
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2019-07-25T13:16:10. All Rights Reserved.
//<生成时间>2019-07-25T13:16:10</生成时间>
namespace Emploee.Emploee.Dictionaries
{
	
	

		//TODO:多页面后端的导航栏目设计

	/*
	//无次级导航属性
	   var dictionary=new MenuItemDefinition(
                DictionaryAppPermissions.Dictionary,
                L("Dictionary"),
				url:"Mpa/DictionaryManage",
				icon:"icon-grid",
				 				 requiredPermissionName: DictionaryAppPermissions.Dictionary
				 					);

*/
				//有下级菜单
            /*

			   var dictionary=new MenuItemDefinition(
                DictionaryAppPermissions.Dictionary,
                L("Dictionary"),			
				icon:"icon-grid"				
				);

				dictionary.AddItem(
			new MenuItemDefinition(
			DictionaryAppPermissions.Dictionary,
			L("Dictionary"),
			"icon-star",
			url:"Mpa/DictionaryManage",
				 			requiredPermissionName: DictionaryAppPermissions.Dictionary));
	

			
			*/

	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到EmploeeApplicationModule
 //   Configuration.Authorization.Providers.Add<DictionaryAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploeezh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 数据字典管理 -->
	    <text name="Dictionary" value="数据字典" />
	    <text name="DictionaryHeaderInfo" value="数据字典管理列表" />
		    <text name="CreateDictionary" value="新增数据字典" />
    <text name="EditDictionary" value="编辑数据字典" />
    <text name="DeleteDictionary" value="删除数据字典" />

	  
		

		    <text name="DictionaryDeleteWarningMessage" value="数据字典名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="ParentCode" value="ParentCode" />
				 	<text name="Code" value="编号" />
				 	<text name="Name" value="名称" />
				 	<text name="OrderIndex" value="排序" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/Emploee.xml
/*
    <!-- 数据字典english管理 -->
		    <text name="	DictionaryHeaderInfo" value="数据字典List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="ParentCode" value="ParentCode" />
				 	<text name="Code" value="编号" />
				 	<text name="Name" value="名称" />
				 	<text name="OrderIndex" value="排序" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Dictionary" value="ManagementDictionary" />
    <text name="CreateDictionary" value="CreateDictionary" />
    <text name="EditDictionary" value="EditDictionary" />
    <text name="DeleteDictionary" value="DeleteDictionary" />
*/




}