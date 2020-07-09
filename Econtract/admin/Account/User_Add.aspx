<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="User_Add.aspx.cs" Inherits="qihang.admin.Account.User_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/chosen.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="Server">
    <h3 class="page-title">用户添加 <small>添加后台操作人员</small>
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
            <a href="javascript:;">用户添加</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box green ">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>用户添加</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <form id="form1" action="User_Add.aspx" method="post" class="user-form form-horizontal form-bordered form-label-stripped">
                        <div class="alert alert-error hide">
                            <button class="close" data-dismiss="alert"></button>
                            您有某种形式的错误。请检查下面。
                        </div>
                        <div class="control-group">
                            <label class="control-label">用户名</label>
                            <div class="controls">
                                <input type="text" id="txtUserName" name="txtUserName" class="m-wrap medium" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">密码</label>
                            <div class="controls">
                                <input type="password" id="txtPassword" name="txtPassword" class="m-wrap medium" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">密码验证</label>
                            <div class="controls">
                                <input type="password" id="txtPassword1" name="txtPassword1" class="m-wrap medium" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">真实姓名</label>
                            <div class="controls">
                                <input type="text" id="txtTrueName" name="txtTrueName" class="m-wrap medium" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">用户性别</label>
                            <div class="controls">
                                <label class="radio">
                                    <input type="radio" name="optSex" value="男" />
                                    男
                                </label>
                                <label class="radio">
                                    <input type="radio" name="optSex" value="女" />
                                    女
                                </label>
                                <div id="optSex_error"></div>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">联系电话</label>
                            <div class="controls">
                                <input type="text" id="Text1" name="txtPhone" class="m-wrap large" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">电子邮箱</label>
                            <div class="controls">
                                <input type="text" id="Text2" name="txtEmail" class="m-wrap large" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">角色</label>
                            <div class="controls">
                                <select class="m-wrap medium select2" name="listTarget" id="listTarget">
                                    <%= BindUser() %>
                                </select>
                            </div>
                        </div>
                        <div class="form-actions">
                            <button type="submit" class="btn blue"><i class='icon-ok'></i>保存</button>
                            <a href="Accounts_UserAdmin.aspx" class="btn">取消</a>
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
    <script src="/admin/media/js/form-user.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
            FormUser.Add();
        });
    </script>
</asp:Content>


