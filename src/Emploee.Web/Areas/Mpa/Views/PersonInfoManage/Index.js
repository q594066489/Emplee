


(function () {
    $(function () {

        var _$personInfosTable = $('#PersonInfosTable');
        var _personInfoService = abp.services.app.personInfo;
        console.log(_personInfoService);
        var _permissions = {
            create: abp.auth.hasPermission("Pages.PersonInfo.CreatePersonInfo"),
            edit: abp.auth.hasPermission("Pages.PersonInfo.EditPersonInfo"),
            'delete': abp.auth.hasPermission("Pages.PersonInfo.DeletePersonInfo")

        };


        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/PersonInfoManage/CreateOrEditPersonInfoModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/PersonInfoManage/_CreateOrEditPersonInfoModal.js',
            modalClass: 'CreateOrEditPersonInfoModal'
        });




        _$personInfosTable.jtable({

            title: app.localize('PersonInfo'),
            paging: true,
            sorting: true,
            //  multiSorting: true,
            actions: {
                listAction: {
                    
                    method: _personInfoService.getPagedPersonInfos
                    //method: _personInfoService.getPagedPersonInfosAsync
                }
            },

            fields: {

                actions: {
                    title: app.localize('Actions'),
                    width: '10%',
                    sorting: false,

                },
                //此处开始循环数据



                id: {
                    key: true,
                    list: false
                },

                name: {
                    title: app.localize('Name'),
                    width: '10%'
                },


                age: {
                    title: app.localize('Age'),
                    width: '10%'
                },


                 

            }

        });
         

        //打开添加窗口SPA
        $('#CreateNewPersonInfoButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open();
        });




        //刷新表格信息
        $("#ButtonReload").click(function () {
            getPersonInfos();
        });




        //模糊查询功能
        function getPersonInfos(reload) {
            if (reload) {
                _$personInfosTable.jtable('reload');
            } else {
                _$personInfosTable.jtable('load', {
                    filtertext: $('#PersonInfosTableFilter').val()
                });
            }
        }
        //
        //删除当前personInfo实体
        function deletePersonInfo(personInfo) {
            abp.message.confirm(
                app.localize('PersonInfoDeleteWarningMessage', personInfo.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _personInfoService.deletePersonInfoAsync({
                            id: personInfo.id
                        }).done(function () {
                            getPersonInfos(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }



        //导出为excel文档
        $('#ExportPersonInfosToExcelButton').click(function () {
            _personInfoService
                .getPersonInfosToExcel({})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });
        //搜索
        $('#GetPersonInfosButton').click(function (e) {
            e.preventDefault();
            getPersonInfos();
        });

        //制作PersonInfo事件,用于请求变化后，刷新表格信息
        abp.event.on('app.createOrEditPersonInfoModalSaved', function () {
            getPersonInfos(true);
        });

        getPersonInfos();


    });
})();
