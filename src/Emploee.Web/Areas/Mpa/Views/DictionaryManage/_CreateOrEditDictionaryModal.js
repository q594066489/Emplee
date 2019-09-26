
(function ($) {
    app.modals.CreateOrEditDictionaryModal = function () {

        var _modalManager;

        var _DictionaryService = abp.services.app.Dictionary;

		 

        var _$DictionaryInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$DictionaryInformationForm = _modalManager.getModal().find("form[name=DictionaryInformationsForm]");
        }
        
        this.save = function () {
            if (!_$DictionaryInformationForm.valid()) {
                return;
            }
            //校验通过

            var Dictionary = _$DictionaryInformationForm.serializeFormToObject();
          //  console.log(Dictionary);

            _modalManager.setBusy(true);

            _DictionaryService.createOrUpdateDictionary({
                DictionaryEditDto: Dictionary
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditDictionaryModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   