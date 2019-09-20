
layui.use([  'upload','jquery'], function () {  //如果只加载一个模块，可以不填数组。如：layui.use('form')
    var $ = layui.$ //重点处
     var upload = layui.upload; //获取upload模块
    var _personInfoService = abp.services.app.personInfo;
    var _uploadUrl = null;
    //执行实例
    //指定允许上传的文件类型
    upload.render({
        elem: '#test3'
        , url: '/PersonInfoManage/UpLoadfileinput'
        , accept: 'file' //普通文件
        , number: 1//文件数量
        , exts: 'pdf|doc|docx'
        , size: 10240//大小10MB
        , progress: function (n) {
            var percent = n + '%' //获取进度百分比
            element.progress('demo', percent); //可配合 layui 进度条元素使用
        }
        , done: function (res) {
            console.log(res);
            alert('success');
            _uploadUrl = res.result.attmentPath;
            _personInfoService.importData(
                _uploadUrl
            ).done(function () {

                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                $("#Resume").val(_uploadUrl);
            }) ;
        }
        , error: function (index, upload) {
            //当上传失败时，你可以生成一个“重新上传”的按钮，点击该按钮时，执行 upload() 方法即可实现重新上传
            alert('fault');
        }
    });
     
});

 