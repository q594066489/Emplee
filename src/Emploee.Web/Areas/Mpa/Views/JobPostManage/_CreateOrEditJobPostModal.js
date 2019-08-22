




(function ($) {
    app.modals.CreateOrEditJobPostModal = function () {
        layui.config({
            base: "../libs/layuiExtend-master/layui/lay/mymodules/"
        }).use(['form', "jquery", "cascader", "form"], function () {
            var $ = layui.jquery;
            var cascader = layui.cascader;
            var datas = "";
            function getJson() {

                $.ajax({
                    type: 'Post',
                    url: '/Mpa/JobPostManage/GetPersonandIDcard',
                    async: false,//使用同步的方式,true为异步方式
                    dataType: "Json",
                    success: function (data) {

                        console.log(data);
                        datas = getJsonTree(data, 0);
                        console.log(datas);
                    }
                })
            }
            ///数据递归生成
            var getJsonTree = function (data, parentId) {
                var itemArr = [];
                for (var i = 0; i < data.length; i++) {
                    var node = data[i];
                    if (node.parentid == parentId) {
                        var newNode = {};
                        //newNode.id = node.id;
                        newNode.value = node.value;

                        newNode.label = node.label;
                        //newNode.url = node.url;
                        //newNode.icon = node.icon;
                        newNode.children = getJsonTree(data, node.value);
                        itemArr.push(newNode);
                    }
                }
                return itemArr;
            };
            getJson();


            var cas = cascader({
                elem: "#JobType",
                data: datas,
                showLastLevels: true,
                //value: ["B", "BB2", "BBB4"],
                // changeOnSelect: true,
                success: function (valData, labelData) {
                    console.log(valData, labelData);
                }
            });


            });

        var _modalManager;

        var _jobPostService = abp.services.app.jobPost;

		
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
        $("#removeIng").click(function () {
            alert(1);
        });
        
        //_modalManager.find('.save-button').click(function () {
        //    alert(1);
        //});
        //$(".save-button").click(function () {
        //    alert(1);
        //});
        this.save = function () {
            if (!_$jobPostInformationForm.valid()) {
                return;
            }
            //校验通过
            
            var jobPost = _$jobPostInformationForm.serializeFormToObject();
          //  console.log(jobPost);

            _modalManager.setBusy(true);

            _jobPostService.createOrUpdateJobPost({
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




//(function () {
//    $(function () {

         


//    });
//})();
