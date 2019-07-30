


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
        //只能输入数字
        amountKeydownFun = function (obj) {
            if (obj.value.length == 1) {
                obj.value = obj.value.replace(/[^1-9]/g, '')
            } else {
                obj.value = obj.value.replace(/\D/g, '')
            }
        }

        amountKeyupFun = function (obj) {
            if (obj.value.length == 1) {
                obj.value = obj.value.replace(/[^1-9]/g, '')
            } else {
                obj.value = obj.value.replace(/\D/g, '')
            }
        }

        amoutPasteFun = function (obj) {
            if (obj.value.length == 1) {
                obj.value = obj.value.replace(/[^1-9]/g, '');
            } else {
                obj.value = obj.value.replace(/\D/g, '');
            }
        }

        $("#CompanyPhone").keyup(function () {
            amountKeyupFun(this);
        })

        $("#CompanyPhone").keydown(function () {
            amountKeydownFun(this);
        })

        $("#CompanyPhone").bind("paste", function () {
            amoutPasteFun(this);
        })

        
         

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
