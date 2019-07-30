


(function () {
    $(function () {

        var _$companysTable = $('#CompanysTable');
        var _companyService = abp.services.app.company;
        console.log(_companyService.getPagedCompanys);

        var _userService = abp.services.app.user;
        console.log(_userService.getUsers.data);
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
        var SampleUnitInfo = {

            $table: $('#CompanysTable'),
            $tableContainer: $('#CompanysTableContainer'),
            //$emptyInfo: $('#Vocs_SampleUnitInfosEmptyInfo'),
            //$addUserToOuButton: $('#CreateNewVocs_SampleUnitInfoButton'),
            //$selectedOuRightTitle: $('#SelectedOuRightTitle'),

            showTable: function () {
                //SampleUnitInfo.$emptyInfo.hide();
                SampleUnitInfo.$table.show();
                SampleUnitInfo.$tableContainer.show();
                //SampleUnitInfo.$addUserToOuButton.show();
                //SampleUnitInfo.$selectedOuRightTitle.text(': ' + FSourceClass.selectedOu.classsName).show();
            },

            hideTable: function () {
                //SampleUnitInfo.$selectedOuRightTitle.hide();
                //SampleUnitInfo.$addUserToOuButton.hide();
                SampleUnitInfo.$table.hide();
                SampleUnitInfo.$tableContainer.hide();
                //SampleUnitInfo.$emptyInfo.show();
            },
            load: function () {
                //if (!FSourceClass.selectedOu.id) {
                //    SampleUnitInfo.hideTable();
                //    return;
                //}
                SampleUnitInfo.showTable();
                //vocsInfo.$table.jtable('load', {
                //    filtertext: classification.selectedOu.classsId
                //});
                SampleUnitInfo.$table.bootstrapTable('removeAll').bootstrapTable('refresh');

            },

            openAddModal: function () {
                //var ouId = FSourceClass.selectedOu.classsId;
                //if (!ouId) {
                //    return;
                //}

                _createOrEditModal.open({
                    classid: ouId, size: 1200
                });
            },


            //初始化bootstrapTable
            init: function () {
                SampleUnitInfo.$table.bootstrapTable({
                    //  abpMethod: _userService.getUsers,
                    abpMethod: _companyservice.getPagedCompanysAsync,
                    pagination: true,                   //是否显示分页（*）
                    toolbar: '#toolbar', //工具按钮用哪个容器
                    queryParams: function (param) {


                        var abpParam = {

                            FilterText: '',
                            skipCount: 0,
                            maxResultCount: 10
                        };

                        return abpParam;
                    },
                    columns: [
                        {
                            field: 'id',
                            title: app.localize('ID'),
                            halign: 'center',
                            width: '10%',
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
                                    deleteVocs_FSourceClass(row);
                                }
                            }
                        }

                    ]
                });




            }





        };

        //_$companysTable.bootstrapTable({
        //    abpMethod: _companyService.getPagedCompanysAsync,
        //    toolbar: '#toolbar', //工具按钮用哪个容器
        //    queryParams: function (param) {
        //        var abpParam = {

        //            FilterText: $('#txtFilterText').val(),
        //            Sorting: param.sort,
        //            skipCount: param.offset,
        //            maxResultCount: param.limit
        //        };
        //        return abpParam;
        //    },
        //    columns:

        //        [
        //            {
        //                field: 'companyName',
        //                title: app.localize('CompanyName'),
        //                halign: 'center',
        //                width: '10%',
        //            },
        //            {
        //                field: 'companyEmail',
        //                title: app.localize('CompanyEmail'),
        //                halign: 'center',
        //                width: '10%',
        //            },
        //            {
        //                field: 'companyPhone',
        //                title: app.localize('CompanyPhone'),
        //                halign: 'center',
        //                width: '10%',
        //            },
        //            {
        //                field: 'companyAddress',
        //                title: app.localize('CompanyAddress'),
        //                halign: 'center',
        //                width: '10%',
        //            },
        //            {
        //                field: 'companyScale',
        //                title: app.localize('CompanyScale'),
        //                halign: 'center',
        //                width: '10%',
        //            },
        //            {
        //                field: 'classify',
        //                title: app.localize('Classify'),
        //                halign: 'center',
        //                width: '10%',
        //            },
        //            {
        //                field: 'finanicing',
        //                title: app.localize('Finanicing'),
        //                halign: 'center',
        //                width: '10%',
        //            },
        //            {
        //                field: 'bussinessLicense',
        //                title: app.localize('BussinessLicense'),
        //                halign: 'center',
        //                width: '10%',
        //            },
        //            {
        //                field: 'registerDate',
        //                title: app.localize('RegisterDate'),
        //                halign: 'center',
        //                width: '10%',
        //            }

        //            //{
        //            //    field: 'actions',
        //            //    title: '操作',
        //            //    align: 'center',
        //            //    width: '10%',
        //            //    formatter: function (value, row, index) {
        //            //        var actions = '';
        //            //        actions += ' <a class="edit" href="javascript:void(0)" title="' + app.localize('Edit') + '" style="margin-left: 10px;"><i class="fa fa-edit"></i></a>';
        //            //        actions += ' <a class="remove" href="javascript:void(0)" title="' + app.localize('Delete') + '" style="margin-left: 10px;"><i class="fa fa-remove"></i></a>';
        //            //        return actions;
        //            //    },
        //            //    events: {
        //            //        'click .edit': function (e, value, row, index) {
        //            //            _createOrEditModal.open({ id: row.id });
        //            //        },
        //            //        'click .remove': function (e, value, row, index) {
        //            //            deleteCompany(row);
        //            //        }
        //            //    }
        //            //}
        //        ]

        //});

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
            //_$companysTable.bootstrapTable('removeAll').bootstrapTable('refresh');
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
        //SampleUnitInfo.init();
        getCompanys();

        
    });
})();
