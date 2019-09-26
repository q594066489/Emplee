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
        elem: "#a",
        data: datas,
        // url: "/aa",
        // type: "post",
        // triggerType: "change",
        showLastLevels: true,
        // where: {
        //     a: "aaa"
        // },
        //value: ["B", "BB2", "BBB4"],
        // changeOnSelect: true,
        success: function (valData, labelData) {
            console.log(valData, labelData);
        }
    });




    var _$jobPostsTable = $('#JobPostsTable');
    var _jobPostService = abp.services.app.jobPost;

    var _permissions = {
        create: abp.auth.hasPermission("Pages.JobPost.CreateJobPost"),
        edit: abp.auth.hasPermission("Pages.JobPost.EditJobPost"),
        'delete': abp.auth.hasPermission("Pages.JobPost.DeleteJobPost")

    };


    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Mpa/JobPostManage/CreateOrEditJobPostModal',
        scriptUrl: abp.appPath + 'Areas/Mpa/Views/JobPostManage/_CreateOrEditJobPostModal.js',
        modalClass: 'CreateOrEditJobPostModal'
    });
    var _createOrEditUrgentModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Mpa/JobUrgentManage/CreateOrEditJobUrgentModal',
        scriptUrl: abp.appPath + 'Areas/Mpa/Views/JobUrgentManage/_CreateOrEditJobUrgentModal.js',
        modalClass: 'CreateOrEditJobUrgentModal'
    });



    _$jobPostsTable.bootstrapTable({
        abpMethod: _jobPostService.getPagedJobPosts,
        toolbar: '#toolbar', //工具按钮用哪个容器
        queryParams: function (param) {
            var abpParam = {

                FilterText: $('#txtFilterText').val(),
                Sorting: param.sort,
                skipCount: param.offset,
                maxResultCount: param.limit
            };
            return abpParam;
        },
        columns:

            [
                {

                    field: 'id',
                    title: 'ID',
                    halign: 'center',
                    align: 'center',
                    width: '3%',
                    visible: false
                },
                {

                    field: 'companyId',
                    title: '企业编号',
                    halign: 'center',
                    align: 'center',
                    width: '3%',
                    visible: false
                },
                {
                    field: 'jobName',
                    title: app.localize('JobName'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                },
                {
                    field: 'SalaryMin',
                    title: '薪资',
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    formatter: function (value, row, index) {

                        return row.salaryMin + "-" + row.salaryMax + "K";
                    }
                },
                 
                {
                    field: 'education',
                    title: app.localize('Education'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                },
                {
                    field: 'experience',
                    title: app.localize('Experience'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                },
                {
                    field: 'jobAddress',
                    title: app.localize('JobAddress'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                },
                {
                    field: 'skillRequire',
                    title: app.localize('SkillRequire'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    visible: false
                },
                 
                {
                    field: 'jobType',
                    title:  "职位类型",
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                }, 
                {
                    field: 'publishDate',
                    title: app.localize('PublishDate'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    formatter: function (value, row, index) {
                        return moment(value).format('L');
                    }
                },

                {
                    field: 'isDelete',
                    title: '状态',
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                    formatter: function (value, row, index) {
                        if (value == '1') {
                            return "<span class=\"label label-danger\"> 停招</span>";
                            
                        }
                        else {
                            return "<span class=\"label label-success\"> 招聘</span>";
                        }
                       
                    }
                },

                {
                    field: 'actions',
                    title: '操作',
                    align: 'center',
                    width: '10%',
                    formatter: function (value, row, index) {
                        var actions = '';
                        actions += ' <a class="add" href="javascript:void(0)" title="' + app.localize('Edit') + '" style="margin-left: 10px;"><i class="fa fa-edit">加急</i></a>';
                        actions += ' <a class="edit" href="javascript:void(0)" title="' + app.localize('Edit') + '" style="margin-left: 10px;"><i class="fa fa-edit">编辑</i></a>';
                        actions += ' <a class="remove" href="javascript:void(0)" title="' + app.localize('Delete') + '" style="margin-left: 10px;"><i class="fa fa-remove">删除</i></a>';
                        return actions;
                    },
                    events: {
                        'click .add': function (e, value, row, index) {
                            _createOrEditUrgentModal.open({ size: '1800'  });
                        },
                        'click .edit': function (e, value, row, index) {
                            _createOrEditModal.open({ size: '1800', id: row.id });
                        },
                        'click .remove': function (e, value, row, index) {
                            deleteJobPost(row);
                        }
                    }
                }
            ]

    });

    //打开添加窗口SPA
    $('#CreateNewJobPostButton').click(function () {
        //可选生成的对话框大小{size:'lg'}or{size:'sm'}
        //需要到_createContainer方法中添加,_args.size
        _createOrEditModal.open({ size: '1800' });
    });
    //刷新表格信息
    $("#ButtonReload").click(function () {
        getJobPosts();
    });




    //模糊查询功能
    function getJobPosts(reload) {

        _$jobPostsTable.bootstrapTable('removeAll').bootstrapTable('refresh');

    }
    //
    //删除当前jobPost实体
    function deleteJobPost(jobPost) {
        abp.message.confirm(
            app.localize('JobPostDeleteWarningMessage', jobPost.jobName),
            function (isConfirmed) {
                if (isConfirmed) {
                    _jobPostService.deleteJobPost({
                        id: jobPost.id
                    }).done(function () {
                        getJobPosts(true);
                        abp.notify.success(app.localize('SuccessfullyDeleted'));
                    });
                }
            }
        );
    }



    //导出为excel文档
    $('#ExportJobPostsToExcelButton').click(function () {
        _jobPostService
            .getJobPostsToExcel({})
            .done(function (result) {
                app.downloadTempFile(result);
            });
    });
    //搜索
    $('#GetJobPostsButton').click(function (e) {
        e.preventDefault();
        getJobPosts();
    });

    //制作JobPost事件,用于请求变化后，刷新表格信息
    abp.event.on('app.createOrEditJobPostModalSaved', function () {
        getJobPosts();
    });

    getJobPosts();

});



