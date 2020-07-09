var DataTables = function () {

    var DataTableDefault = {
        id: '0',
        view: '#',
        edit: '#',
        del: '#',
        furl: '{0}?id={1}',
        furlv: '{0}?id={1}&action={2}&v={3}',
        url: ''
    };

    var _Treelist = function () {

        $.extend(DataTableDefault, {
            view: 'Menu_TreeView.aspx',
            edit: 'Menu_TreeEdit.aspx',
            del: 'Menu_TreeDelete.aspx'
        });

        var oTable = $('#MenuTreelist').dataTable({
            "aoColumns": [
                { "asSorting": ["asc", "desc"] },
                { "bSortable": false },
                { "asSorting": ["asc", "desc"] },
                { "bSortable": false },
                { "bSortable": false },
                { "bSortable": false },
                { "bSortable": false }
            ],
            "aaSorting": []
        });

        jQuery('#MenuTreelist_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
        jQuery('#MenuTreelist_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
        //   jQuery('#MenuTreelist_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

        $('#MenuTreelist_column_toggler input[type="checkbox"]').change(function () {
            /* Get the DataTables object again - this is not a recreation, just a get of the object */
            var iCol = parseInt($(this).attr("data-column"));
            var bVis = oTable.fnSettings().aoColumns[iCol].bVisible;
            oTable.fnSetColumnVis(iCol, (bVis ? false : true));
        });

    }

    var _AccountRoleList = function () {
        $.extend(DataTableDefault, {
            view: 'Role_View.aspx',
            edit: 'Role_Edit.aspx',
            del: 'Role_Delete.aspx'
        });

        var oTable = $('#AccountRoleList').dataTable({
            "aoColumns": [
                { "asSorting": ["asc", "desc"] },
                { "bSortable": false },
                { "bSortable": false }
            ],
            "aaSorting": [[0, 'asc']]
        });

        jQuery('#AccountRoleList_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
        jQuery('#AccountRoleList_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
        // jQuery('#AccountRoleList_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown
    }

    var _AccountUserlist = function () {
        $.extend(DataTableDefault, {
            view: 'User_View.aspx',
            edit: 'User_Edit.aspx',
            del: 'User_Delete.aspx'
        });

        var oTable = $('#AccountUserList').dataTable({
            "aoColumns": [
                { "asSorting": ["asc", "desc"] },
                { "bSortable": false },
                { "bSortable": false },
                { "asSorting": ["asc", "desc"] },
                { "bSortable": false },
                { "bSortable": false },
                { "bSortable": false },
                { "bSortable": false }
            ],
            "aaSorting": [[0, 'asc']]
        });

        jQuery('#AccountUserList_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
        jQuery('#AccountUserList_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
        // jQuery('#AccountUserList_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

        $('#AccountUserList_column_toggler input[type="checkbox"]').change(function () {
            var iCol = parseInt($(this).attr("data-column"));
            var bVis = oTable.fnSettings().aoColumns[iCol].bVisible;
            oTable.fnSetColumnVis(iCol, (bVis ? false : true));
        });
    }

    var _ArticleClassList = function () {

        $.extend(DataTableDefault, {
            view: 'Article_ClassView.aspx',
            edit: 'Article_ClassEdit.aspx',
            del: 'Article_ClassDelete.aspx'
        });

        var oTable = $('#ArticleClassList').dataTable({
            "aoColumns": [
                { "asSorting": false },
                { "bSortable": false },
                { "bSortable": false },
                { "bSortable": false }
            ],
            "aaSorting": []
        });

        jQuery('#ArticleClassList_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
        jQuery('#ArticleClassList_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
        // jQuery('#ArticleClassList_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

    }

    var _ArticleList = function () {

        $.extend(DataTableDefault, {
            view: 'Article_View.aspx',
            edit: 'Article_Edit.aspx',
            del: 'Article_Delete.aspx',
            list: 'Article_List.aspx'
        });

        var oTable = $('#ArticleList').dataTable({
            "sAjaxSource": "api/Article.ashx",
            "aoColumns": [
            { "bSortable": false },
            { "asSorting": ["asc", "desc"] },
            { "bSortable": false },
            { "asSorting": ["asc", "desc"] },
            { "bSortable": false },
            { "bSortable": false },
            { "bSortable": false }
            ],
            "aaSorting": [[3, 'desc']],
            "bProcessing": true,
            "bServerSide": true,
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $('td:eq(0)', nRow).html('<input type="checkbox" class="checkboxes" value="' + aData[1] + '" />');
                $('td:eq(1)', nRow).html(aData[1]);
                $('td:eq(2)', nRow).html('<a href="' + aData[0] + '" target="_blank">' + aData[2] + '</a><font color="#0000ff">[' + aData[4] + ']</font>');
                $('td:eq(3)', nRow).html(aData[3]);
                $('td:eq(4)', nRow).html("<a href=\"Article_Comment.aspx?id=" + aData[1] + "\" class=\"btn mini blue\"><i class=\"icon-comments-alt\"></i> 评论</a><button onclick=\"DataTables.TableAction('" + aData[1] + "','e')\" class=\"btn mini purple\"><i class=\"icon-edit\"></i> 修改</button> <button onclick=\"DataTables.TableAction('" + aData[1] + "','d')\" class=\"btn mini black\"><i class=\"icon-trash\"></i> 删除</button>").addClass('center marginmini');
                $('td:eq(5)', nRow).html("<button onclick=\"DataTables.TableAction('" + aData[1] + "','Top','" + (aData[5] == 1 ? "0" : "1") + "','" + aData[7] + "')\" class=\"btn mini " + (aData[5] == 1 ? "red" : "black") + "\"><i class=\"icon-pushpin\"></i> " + (aData[5] == 1 ? "取消" : "置顶") + "</button>").addClass('center marginmini');
                $('td:eq(6)', nRow).html("<button onclick=\"DataTables.TableAction('" + aData[1] + "','Vouch','" + (aData[6] == 1 ? "0" : "1") + "','" + aData[7] + "')\" class=\"btn mini " + (aData[6] == 1 ? "red" : "black") + "\"><i class=\"icon-thumbs-up\"></i> " + (aData[6] == 1 ? "取消" : "推荐") + "</button>").addClass('center marginmini');
                return nRow;
            }
        });

        jQuery('#ArticleList_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
        jQuery('#ArticleList_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
        //jQuery('#ProductList_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

        jQuery('#ArticleList .group-checkable').change(function () {
            var set = jQuery(this).attr("data-set");
            var checked = jQuery(this).is(":checked");
            jQuery(set).each(function () {
                if (checked) {
                    $(this).attr("checked", true);
                } else {
                    $(this).attr("checked", false);
                }
            });
            jQuery.uniform.update(set);
        });

        $('#delAll').click(function () {
            var _d = [];
            $('#ArticleList .checkboxes').each(function () {
                if ($(this).is(":checked")) {
                    _d.push($(this).val());
                }
            });
            window.location.href = Format(DataTableDefault.furlv, DataTableDefault.list, DataTableDefault.id, "del", _d.join(','));
        });
        $('#editAll').click(function () {
            var _d = [];
            $('#ArticleList .checkboxes').each(function () {
                if ($(this).is(":checked")) {
                    _d.push($(this).val());
                }
            });
            window.location.href = Format(DataTableDefault.furlv, DataTableDefault.list, DataTableDefault.id, "edit", _d.join(','));
        });


        jQuery('#listClassID').change(function () {
            $.cookie('Article_List', $(this).val(), { expires: 1000, path: '/' });
            location.reload();
        });


    }

    var _Studentlist = function () {
        $.extend(DataTableDefault, {
            view: 'Accounts_UserView.aspx',
            edit: 'Student_Edit.aspx',
            del: 'Student_Delete.aspx'
        });

        var oTable = $('#StudentList').dataTable({
            "aoColumns": [
                { "asSorting": ["asc", "desc"] },
                { "bSortable": false },
                { "bSortable": false },
                { "bSortable": false },
                { "bSortable": false },
                { "bSortable": false },
                { "asSorting": ["asc", "desc"] }
            ],
            "aaSorting": [[0, 'asc']]
        });

        jQuery('#StudentList_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
        jQuery('#StudentList_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
        // jQuery('#AccountUserList_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

        $('#StudentList_column_toggler input[type="checkbox"]').change(function () {
            var iCol = parseInt($(this).attr("data-column"));
            var bVis = oTable.fnSettings().aoColumns[iCol].bVisible;
            oTable.fnSetColumnVis(iCol, (bVis ? false : true));
        });
    }
    var _ActiveUserList = function () {

        var oTable = $('#StudentList').dataTable({
            "sAjaxSource": "/admin/api/activeuser.ashx",
            "sAjaxDataProp": "data",
            "aoColumns": [
                { "bSortable": false, mData: 'userinfo' },
                { "bSortable": false, mData: 'classid' },
                { "bSortable": false, mData: 'options' },
                { "bSortable": false, mData: 'Addtime' },
                { "bSortable": false, mData: 'id' },
                { "bSortable": false, mData: 'id' },
                { "bSortable": false, mData: 'id' },
            //{ "asSorting": ["asc", "desc"] },
            //{ "bSortable": false },
            // { "bSortable": false },
            //{ "bSortable": false },
            //{ "asSorting": ["asc", "desc"] }
            ],
            "aaSorting": [[0, 'desc']],
            "bProcessing": true,
            "bServerSide": true,
            "fnRowCallback": function (nRow, aData, iDisplayIndex) {
                $('td:eq(0)', nRow).html(JSON.parse(aData.userinfo).name);
                $('td:eq(1)', nRow).html(JSON.parse(aData.userinfo).phone);
                $('td:eq(2)', nRow).html(JSON.parse(aData.options).v1_1.substr(1));
                $('td:eq(3)', nRow).html(aData.Addtime);
                $('td:eq(4)', nRow).html('<a href="\javascrip:void(0);\" class="btn green">已通过</a>');
                $('td:eq(5)', nRow).html("<input type=\"text\" value=\"23\"style=\"background: transparent;border: 0;width:40px;\" />");
                $('td:eq(6)', nRow).html("<input type=\"text\" value=\"2小时\" style=\"background: transparent;border: 0;width:80px;\"/>");
                return nRow;
            }
        });

        jQuery('#StudentList_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
        jQuery('#StudentList_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
        // jQuery('#AccountUserList_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown


    }


    var Format = function (source, params) {
        if (arguments.length == 1)
            return function () {
                var args = $.makeArray(arguments);
                args.unshift(source);
                return $.format.apply(this, args);
            };
        if (arguments.length > 2 && params.constructor != Array) {
            params = $.makeArray(arguments).slice(1);
        }
        if (params.constructor != Array) {
            params = [params];
        }
        $.each(params, function (i, n) {
            source = source.replace(new RegExp("\\{" + i + "\\}", "g"), n);
        });
        return source;
    }

    return {
        TableAction: function (i, a, v, p) {
            $.extend(DataTableDefault, { id: i });
            switch (a) {
                case "v":
                    window.location.href = Format(DataTableDefault.furl, DataTableDefault.view, DataTableDefault.id);
                    break;
                case "e":
                    window.location.href = Format(DataTableDefault.furl, DataTableDefault.edit, DataTableDefault.id);
                    break;
                case "d":
                    $('#dialog_confirm').modal({
                        keyboard: false
                    });
                    var _url = Format(DataTableDefault.furl, DataTableDefault.del, DataTableDefault.id);
                    $.extend(DataTableDefault, { url: _url });
                    break;
                default:
                    if (p != null) {
                        window.location.href = Format(DataTableDefault.furlv, DataTableDefault.list, DataTableDefault.id, a, v + "&ClassID=" + p);
                    }
                    else {
                        window.location.href = Format(DataTableDefault.furlv, DataTableDefault.list, DataTableDefault.id, a, v);
                    }
                    break;
            }
        },
        GotoUrl: function () {
            window.location.href = DataTableDefault.url;
        },
        daTableBlockUI: function (f) {
            if (!jQuery().dataTable) {
                return;
            }
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            eval(f);
            _Treelist();
            App.unblockUI(pageContent);
        },
        //main function to initiate the module
        Treelist: function () {
            if (!jQuery().dataTable) {
                return;
            }
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _Treelist();
            App.unblockUI(pageContent);
        },
        AccountRoleList: function () {
            if (!jQuery().dataTable) {
                return;
            }
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _AccountRoleList();
            App.unblockUI(pageContent);
        },
        AccountUserlist: function () {
            if (!jQuery().dataTable) {
                return;
            }
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _AccountUserlist();
            App.unblockUI(pageContent);
        },
        ArticleClassList: function () {
            if (!jQuery().dataTable) {
                return;
            }
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _ArticleClassList();
            App.unblockUI(pageContent);
        },
        ArticleList: function () {
            if (!jQuery().dataTable) {
                return;
            }
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _ArticleList();
            App.unblockUI(pageContent);
        },
        StudentList: function () {
            if (!jQuery().dataTable) {
                return;
            }
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _Studentlist();
            App.unblockUI(pageContent);
        },
        ActiveUserList: function () {
            if (!jQuery().dataTable) {
                return;
            }
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _ActiveUserList();
            App.unblockUI(pageContent);
        },
    };

}();