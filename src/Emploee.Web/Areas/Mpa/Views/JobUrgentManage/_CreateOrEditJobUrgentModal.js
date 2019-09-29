
(function ($) {
    app.modals.CreateOrEditJobUrgentModal = function () {

        var _modalManager;

        var _jobUrgentService = abp.services.app.jobUrgent;
 

        var _$jobUrgentInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
            _$jobUrgentInformationForm = _modalManager.getModal().find("form[name=jobUrgentInformationsForm]");
            if ($('#Id').val() != null && $('#State').val()==2) {
                $('#UrgentTypeEdit').attr('disabled', 'disabled');
            }
			 
        }
        
        this.save = function () {
            if (!_$jobUrgentInformationForm.valid()) {
                return;
            }
            //校验通过

            var jobUrgent = _$jobUrgentInformationForm.serializeFormToObject();
          //  console.log(jobUrgent);

            _modalManager.setBusy(true);

            _jobUrgentService.createOrUpdateJobUrgent({
                jobUrgentEditDto: jobUrgent
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditJobPostModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   