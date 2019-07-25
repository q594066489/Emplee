
(function ($) {
    app.modals.CreateOrEditJobUrgentModal = function () {

        var _modalManager;

        var _jobUrgentService = abp.services.app.jobUrgent;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$jobUrgentInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$jobUrgentInformationForm = _modalManager.getModal().find("form[name=jobUrgentInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 	 	 // 初始化 起始时间 的包含时分秒的日期控件
		   //包含时分秒的日期选择器             
            $("input[name=UrgentDate]").datetimepicker({
                autoclose: true,
                isRTL: false,
                format: "yyyy-mm-dd hh:ii",
                pickerPosition: ("bottom-left"),
				//默认为E文按钮要中文，自己去找语言包
				   todayBtn: true,
				     language: "zh-CN"
            });
	 


						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$jobUrgentInformationForm.valid()) {
                return;
            }
            //校验通过

            var jobUrgent = _$jobUrgentInformationForm.serializeFormToObject();
          //  console.log(jobUrgent);

            _modalManager.setBusy(true);

            _jobUrgentService.createOrUpdateJobUrgentAsync({
                jobUrgentEditDto: jobUrgent
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditJobUrgentModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   