
layui.use(['jquery', 'flow'], function () {  //如果只加载一个模块，可以不填数组。如：layui.use('form')
    var $ = layui.$ //重点处
    var flow = layui.flow;
    var _jobPostService = abp.services.app.jobPost;  
    var thispage = 1;
    flow.load({
        elem: '#flowContain' //指定列表容器
        , done: function (page, next) { //到达临界点（默认滚动触发），触发下一页
            var lis = [];
            
            alert(page);
            //以jQuery的Ajax请求为例，请求下一页数据（注意：page是从2开始返回）
            _jobPostService.getPositionForHome({ page: page }).done(function (res) {
                console.log(res)

                next(lis.join(''), page < res.totalCount)
            });
            
            //$.get('/api/list?page=' + page, function (res) {
            //    //假设你的列表返回在data集合中
            //    layui.each(res.data, function (index, item) {
            //        lis.push('<li>' + item.title + '</li>');
            //    });

            //    //执行下一页渲染，第二参数为：满足“加载更多”的条件，即后面仍有分页
            //    //pages为Ajax返回的总页数，只有当前页小于总页数的情况下，才会继续出现加载更多
            //    next(lis.join(''), page < res.pages);
            //});
        }
    });
    $("#reloadbtn").click(function () {

         
        
        $("#flowContain").remove();
        $("#layInfo").append("<div class='margin - bottom - 40' id='flowContain'></div>");
        
        layui.use('flow', function () {
            var flow = layui.flow;
            flow.load({
                elem: '#flowContain' //流加载容器
                 
                , done: function (page, next) { //执行下一页的回调
                    //模拟数据插入
                    var lis = [];

                    alert(page);
                    //以jQuery的Ajax请求为例，请求下一页数据（注意：page是从2开始返回）
                    _jobPostService.getPositionForHome({ page: page }).done(function (res) {
                        console.log(res)

                        next(lis.join(''), page < res.totalCount)
                    });
                }
            });

        });
        //thispage = 1;
    })

});



