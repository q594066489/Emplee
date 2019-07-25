
(function ($) {
    app.modals.CreateOrEditJobPostModal = function () {

        var _modalManager;

        var _jobPostService = abp.services.app.jobPost;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$jobPostInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$jobPostInformationForm = _modalManager.getModal().find("form[name=jobPostInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 	 	 // 初始化 发布时间 的包含时分秒的日期控件
		   //包含时分秒的日期选择器             
            $("input[name=PublishDate]").datetimepicker({
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

   