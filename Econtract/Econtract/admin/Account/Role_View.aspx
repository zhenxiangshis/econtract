<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="Role_View.aspx.cs" Inherits="qihang.admin.Account.Role_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="Server">
    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
    <h3 class="page-title">角色详情 <small>后台用户的身份分类详情</small>
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
            <a href="javascript:;">角色详情</a>
        </li>
    </ul>
    <!-- END PAGE TITLE & BREADCRUMB-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-key"></i>角色详情</div>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal form-view">
                        <h3>角色详情 - <%= model.Name%> </h3>
                        <!-- BEGIN FORM-->
                        <h3 class="form-section">基本信息</h3>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">名称</label>
                                    <div class="controls">
                                        <span class="text"><%= model.Name%></span>
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
                                            <th style="width: 30px;">编号</th>
                                            <th style="width: 30px;">图标</th>
                                            <th>名称</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%= BiudTree(model.ID) %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="form-actions">
                            <a href="Role_Edit.aspx?id=<%=model.ID %>" class="btn purple"><i class='icon-pencil'></i> 修改</a>
                            <a href="Role_List.aspx" class="btn">取消</a>
                        </div>
                        <!-- END FORM-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="Server">
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/form-account.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
        });
    </script>
</asp:Content>


