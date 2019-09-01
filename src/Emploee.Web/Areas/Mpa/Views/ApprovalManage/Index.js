


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


        _$approvalsTable.bootstrapTable({
            abpMethod: _approvalService.getPagedApprovals,
            toolbar: '#toolbar', //工具按钮用哪个容器，
            striped: true,                      //是否显示行间隔色
            queryParams: function (param) {
                var abpParam = {

                    FilterText: $('#txtFilterText').val(),
                    Sorting: param.sort,
                    skipCount: param.offset,
                    maxResultCount: param.limit
                };
                return abpParam;
            },
            columns:
                [{
                    checkbox: true,//是否显示复选框
                    visible: true,
                    width: '1%'
                },
                {
                    field: 'id',
                    title: 'ID',
                    halign: 'center',
                    align: 'center',
                    width: '3%',
                    visible: false
                },
                {

                    field: 'companyId',
                    title: '企业编号',
                    halign: 'center',
                    align: 'center',
                    width: '3%',
                    visible: false
                    },
                    {

                        field: 'companyName',
                        title: '企业',
                        halign: 'center',
                        align: 'center',
                        width: '3%',
                        visible: false
                    },
                {
                    field: 'registerDate',
                    title: app.localize('RegisterDate'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    formatter: function (value, row, index) {
                        if (value != null) {
                            return moment(value).format('L');
                        }
                       
                    }
                },
                {
                    field: 'isPay',
                    title: '已付款',
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    formatter: function (value, row, index) {
                        if (value.isPay) {
                            return "<span class=\"label label-success\"> 是</span>";
                        }
                        return "<span class=\"label label-danger\"> 否</span>";
                    }
                },
                {
                    field: 'payAmount',
                    title: app.localize('Education'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                },
                {
                    field: 'payTime',
                    title: app.localize('PayTime'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    formatter: function (value, row, index) {
                        if (value != null) {
                            return moment(value).format('L');
                        }
                    }
                },
                {
                    field: 'coopTime',
                    title: app.localize('CoopTime'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    formatter: function (value, row, index) {
                        if (value != null) {
                            return moment(value).format('L');
                        }
                    }
                },
                {
                    field: 'weight',
                    title: app.localize('Weight'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    visible: false
                },
                {
                    field: 'actions',
                    title: '操作',
                    align: 'center',
                    width: '10%',
                    formatter: function (value, row, index) {
                        var actions = '';
                        actions += ' <a class="edit" href="javascript:void(0)" title="' + app.localize('Edit') + '" style="margin-left: 10px;"><i class="fa fa-edit"></i></a>';
                        return actions;
                    },
                    events: {
                        'click .edit': function (e, value, row, index) {
                            _createOrEditModal.open({ size: '1800', id: row.id });
                        }
                    }
                }
                ]

        });

        //打开添加窗口SPA
        $('#CreateNewApprovalButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });
        //模糊查询功能
        function getApprovals(reload) {
            _$approvalsTable.bootstrapTable('removeAll').bootstrapTable('refresh');

        }

        //搜索
        $('#GetApprovalsButton').click(function (e) {
            e.preventDefault();
            getApprovals();
        });
        //制作Approval事件,用于请求变化后，刷新表格信息
        abp.event.on('app.createOrEditApprovalModalSaved', function () {
            getApprovals();
        });
        getApprovals();


    });
})();
