


(function () {
    $(function () {

        var _$companysTable = $('#CompanysTable');
        var _companyService = abp.services.app.company;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.Company.CreateCompany"),
            edit: abp.auth.hasPermission("Pages.Company.EditCompany"),
            'delete': abp.auth.hasPermission("Pages.Company.DeleteCompany")

        };


        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/CompanyManage/CreateOrEditCompanyModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/CompanyManage/_CreateOrEditCompanyModal.js',
            modalClass: 'CreateOrEditCompanyModal'
        });





        
        _$companysTable.bootstrapTable({
            abpMethod: _companyService.getPagedCompanys,
            toolbar: '#toolbar', //工具按钮用哪个容器
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

                [
                    {
                        field: 'companyID',
                        title:  '企业编号' ,
                        halign: 'center',
                        width: '3%',
                        visible: false
                    },
                    {
                        field: 'companyName',
                        title: app.localize('CompanyName'),
                        halign: 'center',
                        width: '10%',
                    },
                    {
                        field: 'companyEmail',
                        title: app.localize('CompanyEmail'),
                        halign: 'center',
                        width: '10%',
                    },
                    {
                        field: 'companyPhone',
                        title: app.localize('CompanyPhone'),
                        halign: 'center',
                        width: '10%',
                    },
                    {
                        field: 'companyAddress',
                        title: app.localize('CompanyAddress'),
                        halign: 'center',
                        width: '10%',
                    },
                    {
                        field: 'companyScale',
                        title: app.localize('CompanyScale'),
                        halign: 'center',
                        width: '10%',
                    },
                    {
                        field: 'classify',
                        title: app.localize('Classify'),
                        halign: 'center',
                        width: '10%',
                    },
                    {
                        field: 'finanicing',
                        title: app.localize('Finanicing'),
                        halign: 'center',
                        width: '10%',
                    },
                    {
                        field: 'bussinessLicense',
                        title: app.localize('BussinessLicense'),
                        halign: 'center',
                        width: '10%',
                    },
                    {
                        field: 'registerDate',
                        title: app.localize('RegisterDate'),
                        halign: 'center',
                        width: '10%',
                        formatter: function (value, row, index) {
                            return moment(value).format('L');
                        }
                    },

                    {
                        field: 'actions',
                        title: '操作',
                        align: 'center',
                        width: '10%',
                        formatter: function (value, row, index) {
                            var actions = '';
                            actions += ' <a class="edit" href="javascript:void(0)" title="' + app.localize('Edit') + '" style="margin-left: 10px;"><i class="fa fa-edit"></i></a>';
                            actions += ' <a class="remove" href="javascript:void(0)" title="' + app.localize('Delete') + '" style="margin-left: 10px;"><i class="fa fa-remove"></i></a>';
                            return actions;
                        },
                        events: {
                            'click .edit': function (e, value, row, index) {
                                _createOrEditModal.open({ id: row.id });
                            },
                            'click .remove': function (e, value, row, index) {
                                deleteCompany(row);
                            }
                        }
                    }
                ]

        });

        //打开添加窗口SPA
        $('#CreateNewCompanyButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });




        //刷新表格信息
        $("#ButtonReload").click(function () {
            getCompanys();
        });




        //模糊查询功能
        function getCompanys(reload) {
            if (reload) {
                //_$companysTable.jtable('reload');
            } else {
                //_$companysTable.jtable('load', {
                //    filtertext: $('#CompanysTableFilter').val()
                //});
                _$companysTable.bootstrapTable('removeAll').bootstrapTable('refresh');
            }
        }
        //
        //删除当前company实体
        function deleteCompany(company) {
            abp.message.confirm(
                app.localize('CompanyDeleteWarningMessage', company.companyName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _companyService.deleteCompanyAsync({
                            id: company.id
                        }).done(function () {
                            getCompanys(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }



        //导出为excel文档
        $('#ExportCompanysToExcelButton').click(function () {
            _companyService
                .getCompanysToExcel({})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });
        //搜索
        $('#GetCompanysButton').click(function (e) {
            e.preventDefault();
            getCompanys();
        });

        //制作Company事件,用于请求变化后，刷新表格信息
        abp.event.on('app.createOrEditCompanyModalSaved', function () {
            getCompanys(true);
        });

        getCompanys();


    });
})();
