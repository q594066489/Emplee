
(function ($) {
    app.modals.CreateOrEditCompanyModal = function () {

        var _modalManager;

        var _companyService = abp.services.app.company;

		//$(".maxlength-handler").maxlength({
  //          limitReachedClass: "label label-danger",
  //          alwaysShow: true,
  //          threshold: 5,
  //          placement: 'bottom'
  //      });

        var _$companyInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$companyInformationForm = _modalManager.getModal().find("form[name=companyInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	      
  //实例化图片上传功能
  $("#BussinessLicenseuploader").ltmUploader({
                  pick: {
                    id: "#fileBussinessLicense",
                    multiple: false
                },
                auto: false,          
                server: "/libs/ueditor1_4_3_3_utf8/net/controller.ashx?action=uploadimage",
                fileVal: "upfile",
                //文件类型
                //singleImg 单图
                //multipleImg 多图
                fileType: "singleImg",
                //配置生成缩略图的选项。
                fileSingleSizeLimit: 1 * 1024 * 1024,
                thumb: {
                    width: 350,
                    height: 350,
                    // 图片质量，只有type为`image/jpeg`的时候才有效。
                    quality: 100,
                    // 是否允许放大，如果想要生成小图的时候不失真，此选项应该设置为false.
                    allowMagnify: true,
                    // 是否允许裁剪。
                    crop: false,
                    // 为空的话则保留原有图片格式。
                    // 否则强制转换成指定的类型。
                    // type: 'image/jpeg'

                },              
				  //回调方法
                callback: function (data) {
			//	console.log(data);
                }
                
            });
			//删除原图
			  $("#DeleteBussinessLicense").click(function () {
                //删除hidden中的value值
                $("#BussinessLicenseuploader").find("input[type=hidden]").val(null);
               $("#BussinessLicenseuploader").find(".uploader-list").find("div").eq(0).remove();
           
                $(this).remove();
              //  console.log(this);
            });


				   


						
			 
			   	 	 	 // 初始化 注册时间 的包含时分秒的日期控件
		   //包含时分秒的日期选择器             
            $("input[name=RegisterDate]").datetimepicker({
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
            if (!_$companyInformationForm.valid()) {
                return;
            }
            //校验通过

            var company = _$companyInformationForm.serializeFormToObject();
          //  console.log(company);

            _modalManager.setBusy(true);

            _companyService.createOrUpdateCompanyAsync({
                companyEditDto: company
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditCompanyModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   