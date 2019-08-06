
(function ($) {
    app.modals.ImportOpeManages = function () {
        app.modals.ImportOpeManages
        var _modalManager;
        var _companyService = abp.services.app.company;
        var _uploadUrl = null;

        $("#test-upload").fileinput({
            uploadUrl: '/Mpa/CompanyManage/UpLoadfileinput',//上传的地址
            uploadAsync: true,              //异步上传
            theme: "explorer-fa",                               // 主题
            language: "zh",                 //设置语言
            showCaption: true,              //是否显示标题
            showUpload: true,               //是否显示上传按钮
            showRemove: true,               //是否显示移除按钮
            showPreview: true,             //是否显示预览按钮
            browseClass: "btn btn-primary", //按钮样式 
            dropZoneEnabled: false,         //是否显示拖拽区域
            allowedFileExtensions: ["jpg", "pdf"], //接收的文件后缀
            minFileCount: 1,                                        // 最小上传数量
            maxFileCount: 1,                        //最大上传文件数限制
            previewFileIcon: '<i class="glyphicon glyphicon-file"></i>',
            allowedPreviewTypes: null,
            previewFileIconSettings: {
                'docx': '<i class="glyphicon glyphicon-file"></i>',
                'xlsx': '<i class="glyphicon glyphicon-file"></i>',
                'pptx': '<i class="glyphicon glyphicon-file"></i>',
                'jpg': '<i class="glyphicon glyphicon-picture"></i>',
                'pdf': '<i class="glyphicon glyphicon-file"></i>',
                'zip': '<i class="glyphicon glyphicon-file"></i>',
            },
            uploadExtraData: {  //上传的时候，增加的附加参数
                folder: '数据导入文件', guid: $("#AttachGUID").val()
            }
        }) //文件上传完成后的事件
            .on('fileuploaded', function (event, data, previewId, index) {
                response = data.response
                var res = data.response; //返回结果

                _uploadUrl = response.result.attmentPath;
                console.log(response.result.attmentPath);
                abp.notify.info('上传成功！');
            });

        this.init = function (modalManager) {
            _modalManager = modalManager;
        }


        this.save = function () {
            if (_uploadUrl == null) {
                alert("请上传文件！")
                return;
            }
            _modalManager.setBusy(true);

            _companyService.importData(
                _uploadUrl
            ).done(function () {

                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditDormitory_OperateModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);
