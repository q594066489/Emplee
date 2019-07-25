


(function () {
    $(function () {

        var _$jobUrgentsTable = $('#JobUrgentsTable');
        var _jobUrgentService = abp.services.app.jobUrgent;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.JobUrgent.CreateJobUrgent"),
            edit: abp.auth.hasPermission("Pages.JobUrgent.EditJobUrgent"),
            'delete': abp.auth.hasPermission("Pages.JobUrgent.DeleteJobUrgent")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/JobUrgentManage/CreateOrEditJobUrgentModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/JobUrgentManage/_CreateOrEditJobUrgentModal.es5.min.js',
            modalClass: 'CreateOrEditJobUrgentModal'
        });

    



        _$jobUrgentsTable.jtable({

            title: app.localize('JobUrgent'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _jobUrgentService.getPagedJobUrgentsAsync
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
                                deleteJobUrgent(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateJobUrgent") + "' ><i class='fa fa-plus'></i></button>")
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

jobId: {
            title: app.localize('JobId'),
            width: '10%'
         },     
	  

weight: {
            title: app.localize('Weight'),
            width: '10%'
         },     
	  

urgentType: {
            title: app.localize('UrgentType'),
            width: '10%'
         },     
	  

urgentDate: {
            title: app.localize('UrgentDate'),
            width: '10%'
         },     
	  

urgentLength: {
            title: app.localize('UrgentLength'),
            width: '10%'
         },     
	  
 

isDelete: {
            title: app.localize('isDelete'),
            width: '10%',     
display: function (data) {

                        if (data.record.isDelete) {
                            return "<span class=\"label label-success\"> 是</span>";
                        }

                        return "<span class=\"label label-danger\"> 否</span>";

                    }
         },     


	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewJobUrgentButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getJobUrgents();
        });




//模糊查询功能
function getJobUrgents(reload) {
    if (reload) {
        _$jobUrgentsTable.jtable('reload');
    } else {
        _$jobUrgentsTable.jtable('load', {
            filtertext: $('#JobUrgentsTableFilter').val()
        });
    }
}
//
//删除当前jobUrgent实体
function deleteJobUrgent(jobUrgent) {   
    abp.message.confirm(
        app.localize('JobUrgentDeleteWarningMessage', jobUrgent. jobId),
            function (isConfirmed) {
                if (isConfirmed) {
                    _jobUrgentService.deleteJobUrgentAsync({
                        id: jobUrgent.id
                        }).done(function () {
                            getJobUrgents(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportJobUrgentsToExcelButton').click(function () {
    _jobUrgentService
        .getJobUrgentsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetJobUrgentsButton').click(function (e) {
    e.preventDefault();
    getJobUrgents();
});

//制作JobUrgent事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditJobUrgentModalSaved', function () {
    getJobUrgents(true);
});

getJobUrgents();
 
 
    });
})();
