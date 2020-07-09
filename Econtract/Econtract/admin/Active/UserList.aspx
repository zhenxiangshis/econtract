<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="qihang.admin.Active.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" href="/admin/media/css/DT_bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/jquery-ui-1.10.1.custom.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <h3 class="page-title">学员管理 
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">学员管理</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
      <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>学员管理</div>
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
                                <th>姓名</th>
                                <th>电话</th>
                                <th>申请内容</th>
                                <th>时间</th>
                                <th width="100px">申请结果</th>
                                <th width="100px">剩余名额</th>
                                <th width="100px">名额截止时间</th>
                            </tr>
                        </thead>
                        <tbody>
                            
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
            DataTables.ActiveUserList();
        });
    </script>
</asp:Content>
