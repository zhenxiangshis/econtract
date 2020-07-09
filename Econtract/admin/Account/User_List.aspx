<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="User_List.aspx.cs" Inherits="qihang.admin.Account.User_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" href="/admin/media/css/DT_bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/jquery-ui-1.10.1.custom.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" Runat="Server">
    <h3 class="page-title">用户管理 <small>后台操作人员管理</small>
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">用户管理</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>用户管理</div>
                    <div class="actions">
                        <a href="User_Add.aspx" class="btn green"><i class="icon-plus"></i>添加用户</a>
                        <div class="btn-group">
                            <a class="btn" href="#" data-toggle="dropdown">显示列
										<i class="icon-angle-down"></i>
                            </a>
                            <div id="AccountUserList_column_toggler" class="dropdown-menu hold-on-click dropdown-checkboxes pull-right">
                                <label>
                                    <input type="checkbox" checked data-column="0">编号</label>
                                <label>
                                    <input type="checkbox" checked data-column="1">用户名</label>
                                <label>
                                    <input type="checkbox" checked data-column="2">真实姓名</label>
                                <label>
                                    <input type="checkbox" checked data-column="3">角色</label>
                                <label>
                                    <input type="checkbox" checked data-column="4">性别</label>
                                <label>
                                    <input type="checkbox" checked data-column="5">联系电话</label>
                                <label>
                                    <input type="checkbox" checked data-column="6">电子邮件</label>
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
                    <table class="table table-striped table-bordered table-hover table-full-width" id="AccountUserList">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>用户名</th>
                                <th>真实姓名</th>
                                <th>角色</th>
                                <th>性别</th>
                                <th>联系电话</th>
                                <th>电子邮件</th>
                                <th style="width: 200px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# DataBinder.Eval(Container.DataItem, "[UserID]")%></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "[UserName]")%></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "[TrueName]")%></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "[Description]")%></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "[Sex]")%></td>
                                        <td class="center"><i class="<%# DataBinder.Eval(Container.DataItem, "[Phone]")%>"></i></td>
                                        <td><%# DataBinder.Eval(Container.DataItem, "[Email]")%></td>
                                        <td class="center marginmini">
                                            <button onclick="DataTables.TableAction('<%# DataBinder.Eval(Container.DataItem, "[UserID]")%>','v')" class="btn mini blue"><i class="icon-share"></i> 详情</button>
                                            <button onclick="DataTables.TableAction('<%# DataBinder.Eval(Container.DataItem, "[UserID]")%>','e')" class="btn mini purple"><i class="icon-edit"></i> 修改</button>
                                            <button onclick="DataTables.TableAction('<%# DataBinder.Eval(Container.DataItem, "[UserID]")%>','d')" class="btn mini black"><i class="icon-trash"></i> 删除</button>
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
<asp:Content ID="Content4" ContentPlaceHolderID="script" Runat="Server">
    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="/admin/media/js/DT_bootstrap.js"></script>
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/table-dataTables.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
            DataTables.AccountUserlist();
        });
    </script>
</asp:Content>

