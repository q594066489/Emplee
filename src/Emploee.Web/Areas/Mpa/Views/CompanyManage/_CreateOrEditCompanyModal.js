
(function ($) {
    app.modals.CreateOrEditCompanyModal = function () {

        var _modalManager;

        var _companyService = abp.services.app.company;

 

        var _$companyInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$companyInformationForm = _modalManager.getModal().find("form[name=companyInformationsForm]");
              
			 
	  
        }
         
        document.onkeydown = function (e) {
            if (e.keyCode == 13 && e.ctrlKey) {
                // 这里实现换行
                $("#CompanyIntroduce").value += "\n";
            } else if (e.keyCode == 13) {
                // 避免回车键换行
                e.preventDefault();
                // 下面写你的发送消息的代码
            }
        }

         
        //this.save = function () {
        //    if (!_$companyInformationForm.valid()) {
        //        return;
        //    }
        //    //校验通过

        //    var company = _$companyInformationForm.serializeFormToObject();
        //  //  console.log(company);

        //    _modalManager.setBusy(true);

        //    _companyService.createOrUpdateCompany({
        //        companyEditDto: company
        //    }).done(function () {
        //        //提示信息
        //        abp.notify.info(app.localize('SavedSuccessfully'));
        //        //关闭窗体
        //        _modalManager.close();
        //        //信息保存成功后调用事件，刷新列表
        //        abp.event.trigger('app.createOrEditCompanyModalSaved');
        //    }).always(function () {
        //        _modalManager.setBusy(false);
        //    });
        //}
    }
})(jQuery);

   