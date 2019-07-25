


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





        _$companysTable.jtable({

            title: app.localize('Company'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _companyService.getPagedCompanysAsync
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
                                    _createOrEditModal.open({ id: data.record.id });
                                });
                        }
                        //删除
                        if (_permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deleteCompany(data.record);
                                });
                        }
                        //添加
                        if (_permissions.create) {
                            $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateCompany") + "' ><i class='fa fa-plus'></i></button>")
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

                companyName: {
                    title: app.localize('CompanyName'),
                    width: '10%'
                },


                companyEmail: {
                    title: app.localize('CompanyEmail'),
                    width: '10%'
                },


                companyPhone: {
                    title: app.localize('CompanyPhone'),
                    width: '10%'
                },


                companyAddress: {
                    title: app.localize('CompanyAddress'),
                    width: '10%'
                },


                companyScale: {
                    title: app.localize('CompanyScale'),
                    width: '10%'
                },


                companyIntroduce: {
                    title: app.localize('CompanyIntroduce'),
                    width: '10%'
                },


                classify: {
                    title: app.localize('Classify'),
                    width: '10%'
                },


                finanicing: {
                    title: app.localize('Finanicing'),
                    width: '10%'
                },


                bussinessLicense: {
                    title: app.localize('BussinessLicense'),
                    width: '10%'
                },


                registerDate: {
                    title: app.localize('RegisterDate'),
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
                _$companysTable.jtable('reload');
            } else {
                _$companysTable.jtable('load', {
                    filtertext: $('#CompanysTableFilter').val()
                });
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
