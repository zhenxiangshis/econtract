<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="Menu_TreeList.aspx.cs" Inherits="qihang.admin.Menu.Menu_TreeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" href="/admin/media/css/DT_bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/jquery-ui-1.10.1.custom.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
     <h3 class="page-title">菜单管理 <small>管理后台的左侧菜单</small>
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">菜单管理</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-sitemap"></i>菜单列表</div>
                    <div class="actions">
                        <a href="Menu_TreeAdd.aspx" class="btn green"><i class="icon-plus"></i>添加菜单</a>
                        <div class="btn-group">
                            <a class="btn" href="#" data-toggle="dropdown">显示列
										<i class="icon-angle-down"></i>
                            </a>
                            <div id="MenuTreelist_column_toggler" class="dropdown-menu hold-on-click dropdown-checkboxes pull-right">
                                <label>
                                    <input type="checkbox" checked data-column="0">编号</label>
                                <label>
                                    <input type="checkbox" checked data-column="1">父级编号</label>
                                <label>
                                    <input type="checkbox" checked data-column="2">排序</label>
                                <label>
                                    <input type="checkbox" checked data-column="3">名称</label>
                                <label>
                                    <input type="checkbox" checked data-column="4">小图</label>
                                <label>
                                    <input type="checkbox" checked data-column="5">连接</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div id="dialog_confirm" class="modal hide fade" tabindex="-1" role="dialog" aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                            <h3>您确定要删除这条数据吗?</h3>
                        </div>
                        <div class="modal-body">
                            <p>这些项目将被永久删除，并且无法恢复。你确定吗？</p>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">取消</button>
                            <button data-dismiss="modal" class="btn red" onclick="DataTables.GotoUrl()">删除</button>
                        </div>

                    </div>
                    <table class="table table-striped table-bordered table-hover table-full-width" id="MenuTreelist">
                        <thead>
                            <tr>
                                <th style="width: 40px;">编号</th>
                                <th style="width: 80px;">父级编号</th>
                                <th style="width: 40px;">排序</th>
                                <th>名称</th>
                                <th style="width: 40px;">小图</th>
                                <th>连接</th>
                                <th style="width: 200px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%=BiudTree() %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="/admin/media/js/DT_bootstrap.js"></script>
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/table-dataTables.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
            DataTables.Treelist();
        });
    </script>
</asp:Content>
