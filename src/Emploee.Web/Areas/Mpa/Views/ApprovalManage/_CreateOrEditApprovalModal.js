
(function ($) {
    app.modals.CreateOrEditApprovalModal = function () {

        var _modalManager;

        var _approvalService = abp.services.app.approval;

		 

        var _$approvalInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$approvalInformationForm = _modalManager.getModal().find("form[name=approvalInformationsForm]");
           
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
            $('div[name=divPayTime]').datetimepicker({
                language: 'zh-CN',
                weekStart: 1,
                todayBtn: 1,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                minView: 2,
                forceParse: 0,

            });
	   
        }
        
        this.save = function () {
            _$approvalInformationForm.validate({

                rules: {
                    CoopTime: {
                        required: true,
                        min: 1,
                        digits: true
                    },
                    Weight: {
                        required: true,
                        min: 1,
                        digits: true
                    },
                    PayAmount: {
                        required: true,
                        min: 1,
                        digits: true
                    } 
                     
                },
                messages: {
                    CoopTime: {
                        required: "请输入内容",
                        min: "不能为0",
                        digits:"请输入数字"
                    },
                    Weight: {
                        required: "请输入内容",
                        min: "不能为0",
                        digits: "请输入数字"
                    },
                    PayAmount: {
                        required: "请输入内容",
                        min: "不能为0",
                        digits: "请输入数字"
                    }  
                }
            });
            if (!_$approvalInformationForm.valid()) {
                alert(0);
                return;
            }
            //校验通过
            alert(1);
            var approval = _$approvalInformationForm.serializeFormToObject();
           

            //_modalManager.setBusy(true);

            //_approvalService.createOrUpdateApproval({
            //    approvalEditDto: approval
            //}).done(function () {
            //    //提示信息
            //    abp.notify.info(app.localize('SavedSuccessfully'));
            //    //关闭窗体
            //    _modalManager.close();
            //    //信息保存成功后调用事件，刷新列表
            //    abp.event.trigger('app.createOrEditApprovalModalSaved');
            //}).always(function () {
            //    _modalManager.setBusy(false);
            //});
        }
    }
})(jQuery);

   