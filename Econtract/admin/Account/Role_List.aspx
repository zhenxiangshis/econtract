<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="Role_List.aspx.cs" Inherits="qihang.admin.Account.Role_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" href="/admin/media/css/DT_bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/jquery-ui-1.10.1.custom.min.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/bootstrap-modal.css" />
    <style type="text/css">
        .account-form { margin: 0px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="Server">
    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
    <h3 class="page-title">角色管理 <small>后台用户的身份分类</small>
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">角色管理</a>
        </li>
    </ul>
    <!-- END PAGE TITLE & BREADCRUMB-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-key"></i>角色管理</div>
                    <div class="actions">
                        <a data-toggle="modal" href="#Role_Add" class="btn green"><i class="icon-plus"></i>添加角色</a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div id="dialog_confirm" class="modal hide fade" tabindex="-1" aria-hidden="true">
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
                    <div id="Role_Add" class="modal hide fade" tabindex="-1" data-focus-on="input:first">
                        <!-- BEGIN FORM-->
                        <form id="form1" action="Role_List.aspx?action=add" method="post" class="account-form">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                                <h3>角色添加</h3>
                            </div>
                            <div class="modal-body">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="alert alert-error hide">
                                            <button class="close" data-dismiss="alert"></button>
                                            您有某种形式的错误。请检查下面。
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">名称</label>
                                            <div class="controls">
                                                <input type="text" id="txtName" name="txtName" class="m-wrap span12" />
                                            </div>
                                        </div>
                                        <!-- END FORM-->
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" data-dismiss="modal" class="btn">取消</button>
                                <button type="submit" class="btn green">确定</button>
                            </div>
                        </form>
                    </div>
                    <table class="table table-striped table-bordered table-hover table-full-width" id="AccountRoleList">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>名称</th>
                                <th style="width: 200px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# DataBinder.Eval(Container.DataItem, "[RoleID]")%></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "[Description]")%></td>
                                        <td class="center marginmini">
                                            <button onclick="DataTables.TableAction('<%# DataBinder.Eval(Container.DataItem, "[RoleID]")%>','v')" class="btn mini blue"><i class="icon-share"></i> 详情</button>
                                            <button onclick="DataTables.TableAction('<%# DataBinder.Eval(Container.DataItem, "[RoleID]")%>','e')" class="btn mini purple"><i class="icon-edit"></i> 修改</button>
                                            <button onclick="DataTables.TableAction('<%# DataBinder.Eval(Container.DataItem, "[RoleID]")%>','d')" class="btn mini black"><i class="icon-trash"></i> 删除</button>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="Server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="/admin/media/js/DT_bootstrap.js"></script>
    <script src="/admin/media/js/bootstrap-modal.js" type="text/javascript"></script>
    <script src="/admin/media/js/bootstrap-modalmanager.js" type="text/javascript"></script>
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/table-dataTables.js"></script>
    <script src="/admin/media/js/form-account.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
            DataTables.AccountRoleList();
            FormAccount.Add();
        });
    </script>
</asp:Content>


