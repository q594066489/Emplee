


(function () {
    $(function () {

        var _$approvalsTable = $('#ApprovalsTable');
        var _approvalService = abp.services.app.approval;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.Approval.CreateApproval"),
            edit: abp.auth.hasPermission("Pages.Approval.EditApproval"),
            'delete': abp.auth.hasPermission("Pages.Approval.DeleteApproval")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/ApprovalManage/CreateOrEditApprovalModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/ApprovalManage/_CreateOrEditApprovalModal.js',
            modalClass: 'CreateOrEditApprovalModal'
        });

    



        _$approvalsTable.jtable({

            title: app.localize('Approval'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _approvalService.getPagedApprovalsAsync
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
                                deleteApproval(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateApproval") + "' ><i class='fa fa-plus'></i></button>")
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

companyID: {
            title: app.localize('CompanyID'),
            width: '10%'
         },     
	  

registerDate: {
            title: app.localize('RegisterDate'),
            width: '10%'
         },     
	  
 

isPay: {
            title: app.localize('IsPay'),
            width: '10%',     
display: function (data) {

                        if (data.record.isPay) {
                            return "<span class=\"label label-success\"> 是</span>";
                        }

                        return "<span class=\"label label-danger\"> 否</span>";

                    }
         },     


	  

payAmount: {
            title: app.localize('PayAmount'),
            width: '10%'
         },     
	  

payTime: {
            title: app.localize('PayTime'),
            width: '10%'
         },     
	  

coopTime: {
            title: app.localize('CoopTime'),
            width: '10%'
         },     
	  

weight: {
            title: app.localize('Weight'),
            width: '10%'
         },     
	 
            }

        });

		
				   //打开添加窗口SPA
        $('#CreateNewApprovalButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
 



        //刷新表格信息
        $("#ButtonReload").click(function () {
            getApprovals();
        });




//模糊查询功能
function getApprovals(reload) {
    if (reload) {
        _$approvalsTable.jtable('reload');
    } else {
        _$approvalsTable.jtable('load', {
            filtertext: $('#ApprovalsTableFilter').val()
        });
    }
}
//
//删除当前approval实体
function deleteApproval(approval) {   
    abp.message.confirm(
        app.localize('ApprovalDeleteWarningMessage', approval. companyID),
            function (isConfirmed) {
                if (isConfirmed) {
                    _approvalService.deleteApprovalAsync({
                        id: approval.id
                        }).done(function () {
                            getApprovals(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                }
            }
        );
}

 

//导出为excel文档
$('#ExportApprovalsToExcelButton').click(function () {
    _approvalService
        .getApprovalsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
});
//搜索
$('#GetApprovalsButton').click(function (e) {
    e.preventDefault();
    getApprovals();
});

//制作Approval事件,用于请求变化后，刷新表格信息
abp.event.on('app.createOrEditApprovalModalSaved', function () {
    getApprovals(true);
});

getApprovals();
 
 
    });
})();
