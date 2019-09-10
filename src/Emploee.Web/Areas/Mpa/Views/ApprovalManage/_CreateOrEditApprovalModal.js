
(function ($) {
    app.modals.CreateOrEditApprovalModal = function () {

        var _modalManager;

        var _approvalService = abp.services.app.approval;

		 

        var _$approvalInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$approvalInformationForm = _modalManager.getModal().find("form[name=approvalInformationsForm]");
             
			   	 	 	 // 初始化 注册时间 的包含时分秒的日期控件
		   //包含时分秒的日期选择器             
    //        $("input[name=RegisterDate]").datetimepicker({
    //            autoclose: true,
    //            isRTL: false,
    //            format: "yyyy-mm-dd  ",
    //            pickerPosition: ("bottom-left"),
				////默认为E文按钮要中文，自己去找语言包
				//   todayBtn: true,
				//     language: "zh-CN"
    //        });
            $('div[name=divRegisterDate]').datetimepicker({
                language: 'zh-CN',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                minView: 2,
                forceParse: 0,
                
            });
	  
			   	 	 	 // 初始化 交款时间 的包含时分秒的日期控件
		   //包含时分秒的日期选择器             
    //        $("input[name=PayTime]").datetimepicker({
    //            autoclose: true,
    //            isRTL: false,
    //            format: "yyyy-mm-dd  ",
    //            pickerPosition: ("bottom-left"),
				////默认为E文按钮要中文，自己去找语言包
				//   todayBtn: true,
				//     language: "zh-CN"
    //        });
	 


						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$approvalInformationForm.valid()) {
                return;
            }
            //校验通过

            var approval = _$approvalInformationForm.serializeFormToObject();
          //  console.log(approval);

            _modalManager.setBusy(true);

            _approvalService.createOrUpdateApprovalAsync({
                approvalEditDto: approval
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditApprovalModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   