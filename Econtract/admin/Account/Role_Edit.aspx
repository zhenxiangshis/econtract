<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="Role_Edit.aspx.cs" Inherits="qihang.admin.Account.Role_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="Server">
    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
    <h3 class="page-title">角色修改 <small>修改后台用户的身份分类</small>
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="Accounts_RoleAdmin.aspx">角色管理</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">角色修改</a>
        </li>
    </ul>
    <!-- END PAGE TITLE & BREADCRUMB-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box purple">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-key"></i>角色修改</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <form id="form1" action="Role_Edit.aspx?id=<% =model.ID %>" method="post" class="account-form form-horizontal form-bordered form-label-stripped">
                        <div class="alert alert-error hide">
                            <button class="close" data-dismiss="alert"></button>
                            您有某种形式的错误。请检查下面。
                        </div>
                        <h3 class="form-section">基本信息</h3>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">名称</label>
                                    <div class="controls">
                                        <input type="text" id="txtName" name="txtName" class="m-wrap medium" value="<%=model.Name %>" />
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                        <h3 class="form-section">权限信息</h3>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <table class="table table-striped table-bordered table-hover" id="AccountRoleList">
                                    <thead>
                                        <tr>
                                            <th style="width: 30px;">
                                                <input type="checkbox" class="group-checkable" /></th>
                                            <th style="width: 30px;">编号</th>
                                            <th style="width: 30px;">图标</th>
                                            <th>名称</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%= BiudTree() %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="form-actions">
                            <button type="submit" class="btn purple"><i class='icon-ok'></i> 保存</button>
                            <a href="Role_List.aspx" class="btn">取消</a>
                        </div>
                    </form>
                    <!-- END FORM-->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="Server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/additional-methods.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/form-account.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
            FormAccount.Edit('<%= model.Json%>');
        });
    </script>
</asp:Content>

