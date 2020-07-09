<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="User_Edit.aspx.cs" Inherits="qihang.admin.Account.User_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/jquery-ui-1.10.1.custom.min.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/chosen.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" Runat="Server">
    <h3 class="page-title">用户修改 <small>修改后台操作人员信息</small>
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
            <a href="javascript:;">用户修改</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box purple ">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>用户修改</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <form id="form1" action="User_Edit.aspx?id=<%=model.UserID %>" method="post" class="user-form form-horizontal form-bordered form-label-stripped">
                        <div class="alert alert-error hide">
                            <button class="close" data-dismiss="alert"></button>
                            您有某种形式的错误。请检查下面。
                        </div>
                        <div class="control-group">
                            <label class="control-label">用户名</label>
                            <div class="controls">
                                <input type="text" id="txtUserName" name="txtUserName" class="m-wrap medium" value="<%= model.UserName%>"/>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">真实姓名</label>
                            <div class="controls">
                                <input type="text" id="txtTrueName" name="txtTrueName" class="m-wrap medium" value="<%= model.TrueName%>" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">用户性别</label>
                            <div class="controls">
                                <label class="radio">
                                    <input type="radio" name="optSex" value="男" <%= model.Sex == "男" ? "checked" : "" %> />
                                    男
                                </label>
                                <label class="radio">
                                    <input type="radio" name="optSex" value="女" <%= model.Sex == "女" ? "checked" : "" %> />
                                    女
                                </label>
                                <div id="optSex_error"></div>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">联系电话</label>
                            <div class="controls">
                                <input type="text" id="Text1" name="txtPhone" class="m-wrap large" value="<%= model.Phone%>" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">电子邮箱</label>
                            <div class="controls">
                                <input type="text" id="Text2" name="txtEmail" class="m-wrap large" value="<%= model.Email%>" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">角色</label>
                            <div class="controls">
                                    <select class="m-wrap medium" name="optRole" id="optRole">
                                        <%= BindUser() %>
                                    </select>
                            </div>
                        </div>
                        <div class="form-actions">
                            <button type="submit" class="btn purple"><i class='icon-ok'></i>保存</button>
                            <a href="User_List.aspx" class="btn">取消</a>
                        </div>
                    </form>
                    <!-- END FORM-->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" Runat="Server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/additional-methods.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/form-user.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
            FormUser.Edit('<%=model.RoleID.ToString()%>');
        });
    </script>
</asp:Content>

