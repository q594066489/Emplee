layui.use(['element', 'layer', 'jquery'], function () {
    var $ = layui.$ //重点处
    var element = layui.element;
    var layer = layui.layer;
    
    var _jobPersonService = abp.services.app.jobPerson;
    console.log(_jobPostService);
    //监听折叠
    element.on('collapse(test)', function (data) {
        layer.msg('展开状态：' + data.show);
    });
    $('#factory').click(function () {
        
        _jobPersonService.createFactory({
            companyId: $('#CompanyId').val(),
            jobId: $('#JobId').val() 
             

        }).done(function (res) {
            
            
        });
    })


});
 



