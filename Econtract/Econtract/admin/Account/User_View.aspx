<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="User_View.aspx.cs" Inherits="qihang.admin.Account.User_View" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" Runat="Server">
    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
    <h3 class="page-title">用户详情 <small>后台操作人员详情</small>
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="Accounts_UserAdmin.aspx">用户管理</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">用户详情</a>
        </li>
    </ul>
    <!-- END PAGE TITLE & BREADCRUMB-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>用户详情</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal form-view">
                        <h3>查看用户详情 - <%= model.TrueName%> </h3>
                        <h3 class="form-section">详细信息</h3>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">编号:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.UserID%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">用户名:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.UserName%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">真实姓名:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.TrueName%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">用户性别:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.Sex%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">联系电话:</label>
                                    <div class="controls">
                                        <span class="text"><i class="<%= model.Phone%>"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">电子邮箱:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.Email%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">角色:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.Description%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <a href="User_Edit.aspx?id=<%=model.UserID %>" class="btn purple"><i class="icon-pencil"></i> 修改</a>
                            <a href="User_List.aspx" class="btn">返回</a>
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" Runat="Server">
    <script src="/admin/media/js/app.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
        });
    </script>
</asp:Content>

