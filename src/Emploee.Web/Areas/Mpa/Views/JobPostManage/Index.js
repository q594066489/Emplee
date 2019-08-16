layui.config({
    base: "../libs/layuiExtend-master/layui/lay/mymodules/" 
}).use(['form', "jquery", "cascader", "form"], function () {
    var $ = layui.jquery;
    var cascader = layui.cascader;

    var data = [
        {
            value: 'A',
            label: 'a',
            children: [
                {
                    value: 'AA1',
                    label: 'aa1',
                },
                {
                    value: 'BB1',
                    label: 'bb1'
                }
            ]
        },
        {
            value: 'B',
            label: 'b',
            children: [
                {
                    value: 'AA2',
                    label: 'aa2',
                    children: [
                        {
                            value: 'AAA3',
                            label: 'aaa3',
                            children: [
                                {
                                    value: 'AAA3',
                                    label: 'aaa3',
                                    children: [
                                        {
                                            value: 'AAA3',
                                            label: 'aaa3',
                                        },
                                        {
                                            value: 'BBB3',
                                            label: 'bbb3'
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            value: 'BBB3',
                            label: 'bbb3'
                        }
                    ]
                },
                {
                    value: 'BB2',
                    label: 'bb2',
                    children: [
                        {
                            value: 'AAA4',
                            label: 'aaa4',
                        },
                        {
                            value: 'BBB4',
                            label: 'bbb4'
                        }
                    ]
                }
            ]
        },
        {
            value: 'C',
            label: 'c',
        }
    ]
    var cas = cascader({
        elem: "#a",
        data: data,
        // url: "/aa",
        // type: "post",
        // triggerType: "change",
        showLastLevels: true,
        // where: {
        //     a: "aaa"
        // },
        value: ["B", "BB2", "BBB4"],
        // changeOnSelect: true,
        success: function (valData, labelData) {
            console.log(valData, labelData);
        }
    });
    
    var reloadData = [
        {
            value: 'A',
            label: 'a',
            children: [
                {
                    value: 'AA1',
                    label: 'aa1',
                },
                {
                    value: 'BB1',
                    label: 'bb1'
                }
            ]
        }
    ]
    $(".layui-btn").on("click", function () {
        cas.reload({
            data: reloadData,
            value: ['A', 'BB1']
        })
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
                    field: 'salaryMin',
                    title: app.localize('SalaryMin'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
                },
                {
                    field: 'salaryMax',
                    title: app.localize('SalaryMax'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',
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
                },

                {
                    field: 'jobSelect',
                    title: app.localize('JobSelect'),
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
                    title: app.localize('isDelete'),
                    halign: 'center',
                    align: 'center',
                    width: '8%',

                },

                {
                    field: 'actions',
                    title: '操作',
                    align: 'center',
                    width: '10%',
                    formatter: function (value, row, index) {
                        var actions = '';
                        actions += ' <a class="edit" href="javascript:void(0)" title="' + app.localize('Edit') + '" style="margin-left: 10px;"><i class="fa fa-edit"></i></a>';
                        actions += ' <a class="remove" href="javascript:void(0)" title="' + app.localize('Delete') + '" style="margin-left: 10px;"><i class="fa fa-remove"></i></a>';
                        return actions;
                    },
                    events: {
                        'click .edit': function (e, value, row, index) {
                            _createOrEditModal.open({ size: '1800', id: row.id });
                        },
                        'click .remove': function (e, value, row, index) {
                            deleteCompany(row);
                        }
                    }
                }
            ]

    });

    //打开添加窗口SPA
    $('#CreateNewJobPostButton').click(function () {
        //可选生成的对话框大小{size:'lg'}or{size:'sm'}
        //需要到_createContainer方法中添加,_args.size
        _createOrEditModal.open();
    });




    //刷新表格信息
    $("#ButtonReload").click(function () {
        getJobPosts();
    });




    //模糊查询功能
    function getJobPosts(reload) {
        if (reload) {
            //_$companysTable.jtable('reload');
        } else {
            //_$companysTable.jtable('load', {
            //    filtertext: $('#CompanysTableFilter').val()
            //});
            _$jobPostsTable.bootstrapTable('removeAll').bootstrapTable('refresh');
        }
    }
    //
    //删除当前jobPost实体
    function deleteJobPost(jobPost) {
        abp.message.confirm(
            app.localize('JobPostDeleteWarningMessage', jobPost.companyId),
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
        getJobPosts(true);
    });

    getJobPosts();
});
 


//(function () {
//    $(function () {

//        var _$jobPostsTable = $('#JobPostsTable');
//        var _jobPostService = abp.services.app.jobPost;

//        var _permissions = {
//            create: abp.auth.hasPermission("Pages.JobPost.CreateJobPost"),
//            edit: abp.auth.hasPermission("Pages.JobPost.EditJobPost"),
//            'delete': abp.auth.hasPermission("Pages.JobPost.DeleteJobPost")

//        };


//        var _createOrEditModal = new app.ModalManager({
//            viewUrl: abp.appPath + 'Mpa/JobPostManage/CreateOrEditJobPostModal',
//            scriptUrl: abp.appPath + 'Areas/Mpa/Views/JobPostManage/_CreateOrEditJobPostModal.js',
//            modalClass: 'CreateOrEditJobPostModal'
//        });




//        _$jobPostsTable.bootstrapTable({
//            abpMethod: _jobPostService.getPagedJobPosts,
//            toolbar: '#toolbar', //工具按钮用哪个容器
//            queryParams: function (param) {
//                var abpParam = {

//                    FilterText: $('#txtFilterText').val(),
//                    Sorting: param.sort,
//                    skipCount: param.offset,
//                    maxResultCount: param.limit
//                };
//                return abpParam;
//            },
//            columns:

//                [
//                    {

//                        field: 'id',
//                        title: 'ID',
//                        halign: 'center',
//                        align: 'center',
//                        width: '3%',
//                        visible: false
//                    },
//                    {

//                        field: 'companyId',
//                        title: '企业编号',
//                        halign: 'center',
//                        align: 'center',
//                        width: '3%',
//                        visible: false
//                    },
//                    {
//                        field: 'jobName',
//                        title: app.localize('JobName'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                    },
//                    {
//                        field: 'salaryMin',
//                        title: app.localize('SalaryMin'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                    },
//                    {
//                        field: 'salaryMax',
//                        title: app.localize('SalaryMax'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                    },
//                    {
//                        field: 'education',
//                        title: app.localize('Education'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                    },
//                    {
//                        field: 'experience',
//                        title: app.localize('Experience'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                    },
//                    {
//                        field: 'jobAddress',
//                        title: app.localize('JobAddress'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                    },
//                    {
//                        field: 'skillRequire',
//                        title: app.localize('SkillRequire'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                    },

//                    {
//                        field: 'jobSelect',
//                        title: app.localize('JobSelect'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                    },
//                    {
//                        field: 'publishDate',
//                        title: app.localize('PublishDate'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',
//                        formatter: function (value, row, index) {
//                            return moment(value).format('L');
//                        }
//                    },

//                    {
//                        field: 'isDelete',
//                        title: app.localize('isDelete'),
//                        halign: 'center',
//                        align: 'center',
//                        width: '8%',

//                    },

//                    {
//                        field: 'actions',
//                        title: '操作',
//                        align: 'center',
//                        width: '10%',
//                        formatter: function (value, row, index) {
//                            var actions = '';
//                            actions += ' <a class="edit" href="javascript:void(0)" title="' + app.localize('Edit') + '" style="margin-left: 10px;"><i class="fa fa-edit"></i></a>';
//                            actions += ' <a class="remove" href="javascript:void(0)" title="' + app.localize('Delete') + '" style="margin-left: 10px;"><i class="fa fa-remove"></i></a>';
//                            return actions;
//                        },
//                        events: {
//                            'click .edit': function (e, value, row, index) {
//                                _createOrEditModal.open({ size: '1800', id: row.id });
//                            },
//                            'click .remove': function (e, value, row, index) {
//                                deleteCompany(row);
//                            }
//                        }
//                    }
//                ]

//        });

//        //打开添加窗口SPA
//        $('#CreateNewJobPostButton').click(function () {
//            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
//            //需要到_createContainer方法中添加,_args.size
//            _createOrEditModal.open();
//        });




//        //刷新表格信息
//        $("#ButtonReload").click(function () {
//            getJobPosts();
//        });




//        //模糊查询功能
//        function getJobPosts(reload) {
//            if (reload) {
//                //_$companysTable.jtable('reload');
//            } else {
//                //_$companysTable.jtable('load', {
//                //    filtertext: $('#CompanysTableFilter').val()
//                //});
//                _$jobPostsTable.bootstrapTable('removeAll').bootstrapTable('refresh');
//            }
//        }
//        //
//        //删除当前jobPost实体
//        function deleteJobPost(jobPost) {
//            abp.message.confirm(
//                app.localize('JobPostDeleteWarningMessage', jobPost.companyId),
//                function (isConfirmed) {
//                    if (isConfirmed) {
//                        _jobPostService.deleteJobPost({
//                            id: jobPost.id
//                        }).done(function () {
//                            getJobPosts(true);
//                            abp.notify.success(app.localize('SuccessfullyDeleted'));
//                        });
//                    }
//                }
//            );
//        }



//        //导出为excel文档
//        $('#ExportJobPostsToExcelButton').click(function () {
//            _jobPostService
//                .getJobPostsToExcel({})
//                .done(function (result) {
//                    app.downloadTempFile(result);
//                });
//        });
//        //搜索
//        $('#GetJobPostsButton').click(function (e) {
//            e.preventDefault();
//            getJobPosts();
//        });

//        //制作JobPost事件,用于请求变化后，刷新表格信息
//        abp.event.on('app.createOrEditJobPostModalSaved', function () {
//            getJobPosts(true);
//        });
        
//        getJobPosts();
        
//})();
//});