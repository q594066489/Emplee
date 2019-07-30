(function () {
    $(function () {

        var _$usersTable = $('#UsersTable');
        var _userService = abp.services.app.user;
        var _companyService = abp.services.app.company;
        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Users.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Users.Edit'),
            changePermissions: abp.auth.hasPermission('Pages.Administration.Users.ChangePermissions'),
            impersonation: abp.auth.hasPermission('Pages.Administration.Users.Impersonation'),
            'delete': abp.auth.hasPermission('Pages.Administration.Users.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/Users/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/Users/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditUserModal'
        });

        var _userPermissionsModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/Users/PermissionsModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/Users/_PermissionsModal.js',
            modalClass: 'UserPermissionsModal'
        });

        _$usersTable.jtable({

            title: app.localize('Users'),
            paging: true,
            sorting: true,
            multiSorting: true,
            actions: {
                listAction: {
                    //method: _companyService.getPagedCompanysAsync
                     method: _userService.getUsers
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    type: 'record-actions',
                    cssClass: 'btn btn-xs btn-primary blue',
                    text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                    items: [
                        {
                            text: app.localize('LoginAsThisUser'),
                            visible: function (data) {
                                return _permissions.impersonation && data.record.id !== abp.session.userId;
                            },
                            action: function (data) {
                                app.utils.removeCookie(abp.security.antiForgery.tokenCookieName);
                                abp.ajax({
                                    url: abp.appPath + 'Account/Impersonate',
                                    data: JSON.stringify({
                                        tenantId: abp.session.tenantId,
                                        userId: data.record.id
                                    })
                                });
                            }
                        }, {
                            text: app.localize('Edit'),
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                                _createOrEditModal.open({ id: data.record.id });
                            }
                        }, {
                            text: app.localize('Permissions'),
                            visible: function () {
                                return _permissions.changePermissions;
                            },
                            action: function (data) {
                                _userPermissionsModal.open({ id: data.record.id });
                            }
                        }, {
                            text: app.localize('Unlock'),
                            action: function (data) {
                                _userService.unlockUser({
                                    id: data.record.id
                                }).done(function () {
                                    abp.notify.success(app.localize('UnlockedTheUser', data.record.userName));
                                });
                            }
                        }, {
                            text: app.localize('Delete'),
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteUser(data.record);
                            }
                        }]
                },
                userName: {
                    title: app.localize('UserName'),
                    width: '9%',
                    initialSortingDirection: 'DESC'
                },
                name: {
                    title: app.localize('Name'),
                    width: '10%'
                },
                 
                roles: {
                    title: app.localize('Roles'),
                    width: '12%',
                    sorting: false,
                    display: function (data) {
                        var roleNames = '';

                        for (var j = 0; j < data.record.roles.length; j++) {
                            if (roleNames.length) {
                                roleNames = roleNames + ', ';
                            }

                            roleNames = roleNames + data.record.roles[j].roleName;
                        };

                        return roleNames;
                    }
                },
                emailAddress: {
                    title: app.localize('EmailAddress'),
                    width: '15%'
                },
                isEmailConfirmed: {
                    title: app.localize('EmailConfirm'),
                    width: '6%',
                    display: function (data) {
                        if (data.record.isEmailConfirmed) {
                            return '<span class="label label-success">' + app.localize('Yes') + '</span>';
                        } else {
                            return '<span class="label label-default">' + app.localize('No') + '</span>';
                        }
                    }
                },
                isActive: {
                    title: app.localize('Active'),
                    width: '6%',
                    display: function (data) {
                        if (data.record.isActive) {
                            return '<span class="label label-success">' + app.localize('Yes') + '</span>';
                        } else {
                            return '<span class="label label-default">' + app.localize('No') + '</span>';
                        }
                    }
                },
                lastLoginTime: {
                    title: app.localize('LastLoginTime'),
                    width: '7%',
                    display: function (data) {
                        if (data.record.lastLoginTime) {
                            return moment(data.record.lastLoginTime).format('L');
                        }

                        return '-';
                    }
                },
                creationTime: {
                    title: app.localize('CreationTime'),
                    width: '7%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }
        });

        function getUsers(reload) {
            if (reload) {
                _$usersTable.jtable('reload');
            } else {
                _$usersTable.jtable('load', {
                    filter: $('#UsersTableFilter').val(),
                    permission: $("#PermissionSelectionCombo").val(),
                    role: $("#RoleSelectionCombo").val()
                });
            }
        }

        function deleteUser(user) {
            if (user.userName == app.consts.userManagement.defaultAdminUserName) {
                abp.message.warn(app.localize("{0}UserCannotBeDeleted", app.consts.userManagement.defaultAdminUserName));
                return;
            }

            abp.message.confirm(
                app.localize('UserDeleteWarningMessage', user.userName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _userService.deleteUser({
                            id: user.id
                        }).done(function () {
                            getUsers(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }

        $('#ShowAdvancedFiltersSpan').click(function () {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });

        $('#HideAdvancedFiltersSpan').click(function () {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });

        $('#CreateNewUserButton').click(function () {
            _createOrEditModal.open();
        });

        $('#ExportUsersToExcelButton').click(function () {
            _userService
                .getUsersToExcel({})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        $('#GetUsersButton, #RefreshUserListButton').click(function (e) {
            e.preventDefault();
            getUsers();
        });

        abp.event.on('app.createOrEditUserModalSaved', function () {
            getUsers(true);
        });
        var SampleUnitInfo = {

            $table: $('#UsersTable2'),
            $tableContainer: $('#Vocs_SampleUnitInfosTableContainer'),
             $emptyInfo: $('#Vocs_SampleUnitInfosEmptyInfo'),
            //$addUserToOuButton: $('#CreateNewVocs_SampleUnitInfoButton'),
            //$selectedOuRightTitle: $('#SelectedOuRightTitle'),

            showTable: function () {
                 SampleUnitInfo.$emptyInfo.hide();
                SampleUnitInfo.$table.show();
                 SampleUnitInfo.$tableContainer.show();
                //SampleUnitInfo.$addUserToOuButton.show();
                //SampleUnitInfo.$selectedOuRightTitle.text(': ' + FSourceClass.selectedOu.classsName).show();
            },

            hideTable: function () {
                //SampleUnitInfo.$selectedOuRightTitle.hide();
                //SampleUnitInfo.$addUserToOuButton.hide();
                SampleUnitInfo.$table.hide();
                 SampleUnitInfo.$tableContainer.hide();
                SampleUnitInfo.$emptyInfo.show();
            },
            load: function () {
                //if (!FSourceClass.selectedOu.id) {
                //    SampleUnitInfo.hideTable();
                //    return;
                //}
                SampleUnitInfo.showTable();
                //vocsInfo.$table.jtable('load', {
                //    filtertext: classification.selectedOu.classsId
                //});
                SampleUnitInfo.$table.bootstrapTable('removeAll').bootstrapTable('refresh');

            },

            openAddModal: function () {
                //var ouId = FSourceClass.selectedOu.classsId;
                //if (!ouId) {
                //    return;
                //}

                _createOrEditModal.open({
                    classid: ouId, size: 1200
                } );
            },


            //初始化bootstrapTable
            init: function () {
                SampleUnitInfo.$table.bootstrapTable({
                    abpMethod: _userService.getUsers,
                    toolbar: '#toolbar', //工具按钮用哪个容器
                    queryParams: function (param) {
                        var treeclassid = 0;
                         
                        var abpParam = {
                            FilterText: treeclassid,
                            Sorting: param.sort,
                            skipCount: param.offset,
                            maxResultCount: param.limit
                        };

                        return abpParam;
                    },
                    columns: [
                         
                        {
                            field: 'userName',
                            title: app.localize('userName'),
                            align: 'center',
                            width: '10%',
                        },
                        {
                            field: 'name',
                            title: app.localize('Name'),
                            halign: 'center',
                            width: '10%',
                        },
                        {
                            field: 'roles',
                            title: app.localize('Roles'),
                            align: 'center',
                            width: '10%',
                            formatter: function (value, item, index) {
                                var roleNames = '';

                                for (var j = 0; j < value.length; j++) {
                                    if (roleNames.length) {
                                        roleNames = roleNames + ', ';
                                    }

                                    roleNames = roleNames + value[j].roleName;
                                };

                                return roleNames;
                                if (value == 0) {
                                    return '正常';
                                }
                                else if (value == 1) {
                                    return '禁用';
                                }
                            }
                         
                        },
                        {
                            field: 'emailAddress',
                            title: app.localize('EmailAddress'),
                            align: 'center',
                            width: '10%',
                        },

                        //{
                        //    field: 'dischargeEFUnit',
                        //    title: app.localize('DischargeEFUnit'),
                        //    align: 'center',
                        //    width: '10%',
                        //},
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
                                    _createOrEditModal.open({ id: row.id });
                                },
                                'click .remove': function (e, value, row, index) {
                                    deleteVocs_FSourceClass(row);
                                }
                            }
                        }

                    ]
                });

                $('#CreateNewVocs_SampleUnitInfoButton').click(function (e) {
                    e.preventDefault();
                    SampleUnitInfo.openAddModal();
                });
                SampleUnitInfo.hideTable();
            }





        };


         
        getUsers();
        SampleUnitInfo.init();
        SampleUnitInfo.showTable();
        $('#UsersTableFilter').focus();
    });
})();