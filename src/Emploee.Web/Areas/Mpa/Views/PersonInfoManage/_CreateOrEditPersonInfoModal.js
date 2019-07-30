
(function ($) {
    app.modals.CreateOrEditPersonInfoModal = function () {

        var _modalManager;

        var _personInfoService = abp.services.app.personInfo;


        var _$personInfoInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$personInfoInformationForm = _modalManager.getModal().find("form[name=personInfoInformationsForm]");

						
        }
        
        this.save = function () {
            if (!_$personInfoInformationForm.valid()) {
                return;
            }
            //校验通过

            var personInfo = _$personInfoInformationForm.serializeFormToObject();
          //  console.log(personInfo);

            _modalManager.setBusy(true);

            _personInfoService.createOrUpdatePersonInfoAsync({
                personInfoEditDto: personInfo
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditPersonInfoModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   