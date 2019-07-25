


(function () {
    $(function () {

        var _$personInfosTable = $('#PersonInfosTable');
        var _personInfoService = abp.services.app.personInfo;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.PersonInfo.CreatePersonInfo"),
            edit: abp.auth.hasPermission("Pages.PersonInfo.EditPersonInfo"),
            'delete': abp.auth.hasPermission("Pages.PersonInfo.DeletePersonInfo")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/PersonInfoManage/CreateOrEditPersonInfoModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/PersonInfoManage/_CreateOrEditPersonInfoModal.es5.min.js',
            modalClass: 'CreateOrEditPersonInfoModal'
        });

    



        _$personInfosTable.jtable({

            title: app.localize('PersonInfo'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _personInfoService.getPagedPersonInfosAsync
        }
            },

        fields: {
           
            actions: {
                title: app.localize('Actions'),
                width: '10%',
                sorting: false,
                display: function (data) {
                    var $span = $('<span></span>');
                    //编辑
                    if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
 _createOrEditModal.open({ id: data.record.id });                            });
                    }
                    //删除
                    if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deletePersonInfo(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreatePersonInfo") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
							 _createOrEditModal.open();				                  

                            });
                    }

                    return $span;
            }
        },
		//此处开始循环数据

	 

          id: {           
                 key: true,
                list: false
         }, 	  

name: {
            title: app.localize('Name'),
            width: '10%'
         },     
	  

age: {
            title: app.localize('Age'),
            width: '10%'
         },     
	  

sex: {
            title: app.localize('Sex'),
            width: '10%'
         },     
	  

education: {
            title: app.localize('Education'),
            width: '10%'
         },     
	  

phone: {
            title: app.localize('Phone'),
            width: '10%'
         },     
	  

email: {
            title: app.localize('Email'),
            width: '10%'
         },     
	  

expectPosition: {
            title: app.localize('ExpectPosition'),
            width: '10%'
         },     
	  

expectTrade: {
            title: app.localize('ExpectTrade'),
            width: '10%'
         },     
	  

resume: {
            title: app.localize('Resume'),
            width: '10%'
         },     
	  
 

isOnJob: {
            title: app.localize('isOnJob'),
            width: '10%',     
display: function (data) {

                        if (data.record.isOnJob) {
                            return "<span class=\"label label-success\"> 是</span>";
                        }

                        return "<span class=\"label label-danger\"> 否</span>";

                    }
         },     


	  

state: {
            title: app.localize('State'),
            width: '10%'
         },     
	  

jobYear: {
            title: app.localize('JobYear'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewPersonInfoButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getPersonInfos();
        });




//模糊查询功能
function getPersonInfos(reload) {
    if (reload) {
        _$personInfosTable.jtable('reload');
    } else {
        _$personInfosTable.jtable('load', {
            filtertext: $('#PersonInfosTableFilter').val()
        });
    }
}
//
//删除当前personInfo实体
function deletePersonInfo(personInfo) {   
    abp.message.confirm(
        app.localize('PersonInfoDeleteWarningMessage', personInfo. name),
            function (isConfirmed) {
                if (isConfirmed) {
                    _personInfoService.deletePersonInfoAsync({
                        id: personInfo.id
                        }).done(function () {
                            getPersonInfos(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportPersonInfosToExcelButton').click(function () {
    _personInfoService
        .getPersonInfosToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetPersonInfosButton').click(function (e) {
    e.preventDefault();
    getPersonInfos();
});

//制作PersonInfo事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditPersonInfoModalSaved', function () {
    getPersonInfos(true);
});

getPersonInfos();
 
 
    });
})();
