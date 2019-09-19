


(function () {
    $(function () {

        var _$companysTable = $('#CompanysTable');
        var _companyService = abp.services.app.company;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.Company.CreateCompany"),
            edit: abp.auth.hasPermission("Pages.Company.EditCompany"),
            'delete': abp.auth.hasPermission("Pages.Company.DeleteCompany")

        };
        var _import = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/CompanyManage/ImportCompanyManages',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/CompanyManage/_ImportCompanyManages.js',
            modalClass: 'ImportOpeManages'
        });

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
        });

        $("#CompanyPhone").keydown(function () {
            amountKeydownFun(this);
        });

        $("#CompanyPhone").bind("paste", function () {
            amoutPasteFun(this);
        });
 
        $('#uploadBtn').click(function () {
            _import.open();

        });
        $('#SaveCompanyBtn').click(function () {
            //_$companyInformationForm = $("form[name=companyInformationsForm]");

            var _option = {
                CompanyID: $("#CompanyID").val(),
                CompanyName: $("#CompanyName").val(),
                CompanyEmail: $("#CompanyEmail").val(),
                CompanyPhone: $("#CompanyPhone").val(),
                isDelete: $("input[name=isDelete]").val(),
                CompanyAddress: $("#CompanyAddress").val(),
                CompanyScale: $("#CompanyScaleEdit").val(),
                Classify: $("#ClassifyEdit").val(),
                Finanicing: $("#FinanicingEdit").val(),
                CompanyIntroduce: $("#CompanyIntroduce").val(),

            }
             
            //校验通过
            //$("form[name=companyInformationsForm]").formSerialize();
             
           // abp.ui.setBusy("form[name=companyInformationsForm]");
            //var _companyjson = $("form[name=companyInformationsForm]").formSerialize(); //将JSON对象转化为JSON字符  
            //var _companyobj = JSON.parse(_companyjson); //由JSON字符串转换为JSON对象  
            //console.log(_$companyInformationForm);
            //console.log(_$companyInformationForm.formSerialize())
            console.log(_option);
            //console.log(_companyobj);
            _companyService.updateCompanyInfo({
                companyEditDto: _option
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                ////关闭窗体
                //_modalManager.close();
                ////信息保存成功后调用事件，刷新列表
                //abp.event.trigger('app.createOrEditCompanyModalSaved');
            }).always(function () {
                abp.ui.clearBusy("form[name=companyInformationsForm]");;
            });
        });
        //getCompanys();


    });
})();
