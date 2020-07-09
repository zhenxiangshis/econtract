<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Job_List.aspx.cs" Inherits="qihang.admin.Job.Job_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" href="/admin/media/css/DT_bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/jquery-ui-1.10.1.custom.min.css" />
    <script></script>
    <style>
        .portlet.box .form-horizontal.form-bordered .control-group {
            margin-left: 0px;
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <h3 class="page-title">任务管理 
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="/admin/main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">任务管理</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>任务管理</div>
                    <div class="actions">
                        <a href="javascript:void(0)" class="btn green addcontract"><i class="icon-plus"></i>添加合同</a>
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
                    <table class="table table-striped table-bordered table-hover table-full-width" id="StudentList">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>任务名称</th>
                                <th>任务状态</th>
                                <th>下次执行时间</th>
                                <th style="width: 400px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("id")%></td>
                                        <td><%# Eval("jobname")%></td>
                                        <td class=""><%# SetState (Eval("TriggerState").ToString())%> </td>
                                        <td><%# Eval("NextTime")%></td>
                                        <td class="center marginmini">
                                            <a href="Job_Edit.aspx?id=<%# Eval("id")%>" class="btn mini purple"><i class="icon-edit"></i>修改</a>
                                            <%# SetAction(Eval("TriggerState").ToString(),Convert.ToInt32(Eval("id").ToString())) %>
                                            <a href="Contract_Delete.aspx?id=<%# Eval("id")%>" class="btn mini black"><i class="icon-trash"></i>删除</a>
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
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>

    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="/admin/media/js/DT_bootstrap.js"></script>
    <script src="/admin/media/js/bootstrap-modal.js" type="text/javascript"></script>
    <script src="/admin/media/js/bootstrap-modalmanager.js" type="text/javascript"></script>

    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/table-dataTables.js"></script>
    <script src="/admin/media/js/layer/layer.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
            //DataTables.Studentlist();

        });
    </script>
</asp:Content>
