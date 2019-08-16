
(function ($) {
    app.modals.CreateOrEditJobPostModal = function () {

        var _modalManager;

        var _jobPostService = abp.services.app.jobPost;

		 

        var _$jobPostInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$jobPostInformationForm = _modalManager.getModal().find("form[name=jobPostInformationsForm]");

        }
        
        this.save = function () {
            if (!_$jobPostInformationForm.valid()) {
                return;
            }
            //校验通过

            var jobPost = _$jobPostInformationForm.serializeFormToObject();
          //  console.log(jobPost);

            _modalManager.setBusy(true);

            _jobPostService.createOrUpdateJobPostAsync({
                jobPostEditDto: jobPost
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

   