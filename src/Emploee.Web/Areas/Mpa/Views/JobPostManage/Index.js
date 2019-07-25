


(function () {
    $(function () {

        var _$jobPostsTable = $('#JobPostsTable');
        var _jobPostService = abp.services.app.jobPost;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.JobPost.CreateJobPost"),
            edit: abp.auth.hasPermission("Pages.JobPost.EditJobPost"),
            'delete': abp.auth.hasPermission("Pages.JobPost.DeleteJobPost")

        };


      var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/JobPostManage/CreateOrEditJobPostModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/JobPostManage/_CreateOrEditJobPostModal.es5.min.js',
            modalClass: 'CreateOrEditJobPostModal'
        });

    



        _$jobPostsTable.jtable({

            title: app.localize('JobPost'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    method: _jobPostService.getPagedJobPostsAsync
        }
            },

        fields: {
           
            actions: {
                title: app.localize('Actions'),
                width: '10%',
                sorting: false,
                display: function (data) {
                    var $span = $('<span></span>');
                    //编辑
                    if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
 _createOrEditModal.open({ id: data.record.id });                            });
                    }
                    //删除
                    if (_permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                deleteJobPost(data.record);
                            });
                    }
                    //添加
                    if (_permissions.create) {
                        $("<button class='btn btn-default  btn-xs'  title='" + app.localize("CreateJobPost") + "' ><i class='fa fa-plus'></i></button>")
                            .appendTo($span)
                            .click(function () {
							 _createOrEditModal.open();				                  

                            });
                    }

                    return $span;
            }
        },
		//此处开始循环数据

	 

          id: {           
                 key: true,
                list: false
         }, 	  

companyId: {
            title: app.localize('CompanyId'),
            width: '10%'
         },     
	  

jobName: {
            title: app.localize('JobName'),
            width: '10%'
         },     
	  

salaryMin: {
            title: app.localize('SalaryMin'),
            width: '10%'
         },     
	  

salaryMax: {
            title: app.localize('SalaryMax'),
            width: '10%'
         },     
	  

education: {
            title: app.localize('Education'),
            width: '10%'
         },     
	  

experience: {
            title: app.localize('Experience'),
            width: '10%'
         },     
	  

jobAddress: {
            title: app.localize('JobAddress'),
            width: '10%'
         },     
	  

skillRequire: {
            title: app.localize('SkillRequire'),
            width: '10%'
         },     
	  

jobDetail: {
            title: app.localize('JobDetail'),
            width: '10%'
         },     
	  

jobSelect: {
            title: app.localize('JobSelect'),
            width: '10%'
         },     
	  

jobType: {
            title: app.localize('JobType'),
            width: '10%'
         },     
	  

publishDate: {
            title: app.localize('PublishDate'),
            width: '10%'
         },     
	  
 

isDelete: {
            title: app.localize('isDelete'),
            width: '10%',     
display: function (data) {

                        if (data.record.isDelete) {
                            return "<span class=\"label label-success\"> 是</span>";
                        }

                        return "<span class=\"label label-danger\"> 否</span>";

                    }
         },     


	 
            }

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
        _$jobPostsTable.jtable('reload');
    } else {
        _$jobPostsTable.jtable('load', {
            filtertext: $('#JobPostsTableFilter').val()
        });
    }
}
//
//删除当前jobPost实体
function deleteJobPost(jobPost) {   
    abp.message.confirm(
        app.localize('JobPostDeleteWarningMessage', jobPost. companyId),
            function (isConfirmed) {
                if (isConfirmed) {
                    _jobPostService.deleteJobPostAsync({
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
})();
