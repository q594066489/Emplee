


(function () {
    $(function () {
        //alert(11);
        var _$DictionarysTable = $('#DictionarysTable');
        var _DictionaryService = abp.services.app.dictionary;

        var _permissions = {
            create: abp.auth.hasPermission("Pages.Dictionary.CreateDictionary"),
            edit: abp.auth.hasPermission("Pages.Dictionary.EditDictionary"),
            'delete': abp.auth.hasPermission("Pages.Dictionary.DeleteDictionary")

        };


        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/DictionaryManage/CreateOrEditDictionaryModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/DictionaryManage/_CreateOrEditDictionaryModal.js',
            modalClass: 'CreateOrEditDictionaryModal'
        });


        $('#ImportBtn').click(function () {
            _import.open();
        });


         

        _$DictionarysTable.bootstrapTable({
            abpMethod: _DictionaryService.getPagedDictionarys,
            toolbar: '#toolbar', //工具按钮用哪个容器
            queryParams: function (param) {
                var abpParam = {
                    FilterText: $('#txtFilterText').val(),
                    ParentCode: $('#hidParentCode').val(),
                    Sorting: param.sort,
                    skipCount: param.offset,
                    maxResultCount: param.limit
                };
                return abpParam;
            },
            columns: [
                {
                    field: 'code',
                    title: app.localize('Code'),
                    halign: 'center',
                    width: '20%',
                },
                {
                    field: 'name',
                    title: app.localize('Name'),
                    align: 'center',
                    width: '20%'
                },
                {
                    field: 'value',
                    title: "值",
                    align: 'center',
                    width: '20%'
                },
                {
                    field: 'orderIndex',
                    title: "序号",
                    align: 'center',
                    width: '20%'
                },
                {
                    field: 'actions',
                    title: '操作',
                    align: 'center',
                    width: '20%',
                    formatter: function (value, row, index) {
                        var actions = '';
                        actions += '<a class="sub btn btn-circle btn-xs btn-outline blue" style="margin-left: 0 !important; margin-right: 0 !important;" href="javascript:void(0)" title="子分类"><i class="fa fa-sitemap"></i> 子分类</a>';
                        actions += '<a class="edit btn btn-circle btn-xs btn-outline blue" style="margin-left: 0 !important; margin-right: 0 !important;" href="javascript:void(0)" title="修改"><i class="fa fa-pencil"></i> 修改</a>';
                        actions += '<a class="remove btn btn-circle btn-xs btn-outline green" style="margin-left: 0 !important; margin-right: 0 !important;" href="javascript:void(0)" title="删除"><i class="fa fa-remove"></i> 删除</a>';
                        return actions;
                    },
                    events: {
                        'click .sub': function (e, value, row, index) {
                            document.location.href = abp.appPath + "Mpa/DictionaryManage?parentCode=" + row.code;
                        },
                        'click .edit': function (e, value, row, index) {
                            _createOrEditModal.open({ id: row.id });
                        },
                        'click .remove': function (e, value, row, index) {
                            deleteVocs_Dictionary(row);
                        }
                    }
                }
            ]
        });




        //打开添加窗口SPA
        $('#CreateNewDictionaryButton').click(function () {
            //可选生成的对话框大小{size:'lg'}or{size:'sm'}
            //需要到_createContainer方法中添加,_args.size
            _createOrEditModal.open({ parentCode: $('#hidParentCode').val() });
        });




        function getDictionarys() {
            _$DictionarysTable.bootstrapTable('removeAll').bootstrapTable('refresh');
        }
        //
        //删除当前Dictionary实体
        function deleteDictionary(Dictionary) {
            abp.message.confirm(
                app.localize('DictionaryDeleteWarningMessage', Dictionary.parentCode),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            _DictionaryService.deleteDictionaryAsync({
                                id: Dictionary.id
                            }).done(function () {
                                getDictionarys(true);
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                        }
                    }
                );
        }



        //导出为excel文档
        $('#ExportDictionarysToExcelButton').click(function () {
            _DictionaryService
                .getDictionarysToExcel({})
                    .done(function (result) {
                        app.downloadTempFile(result);
                    });
        });
        //搜索
        $('#GetDictionarysButton').click(function (e) {
            e.preventDefault();
            getDictionarys();
        });

        //制作Dictionary事件,用于请求变化后，刷新表格信息
        abp.event.on('app.createOrEditDictionaryModalSaved', function () {
            getDictionarys(true);
        });

        getDictionarys();


    });
})();
