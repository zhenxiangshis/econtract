<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="User_EditInfo.aspx.cs" Inherits="qihang.admin.Account.User_EditInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link href="/admin/media/css/bootstrap-fileupload.css" rel="stylesheet" type="text/css" />
    <link href="/admin/media/css/profile.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
    <h3 class="page-title">账户资料 <small>当前人员的账户信息</small>
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">账户资料</a>
        </li>
    </ul>
    <!-- END PAGE TITLE & BREADCRUMB-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="span3">
                <ul class="ver-inline-menu tabbable margin-bottom-10">
                    <li class="active">
                        <a data-toggle="tab" href="User_EditInfo.aspx">
                            <i class="icon-cog"></i>
                            账户资料
                        </a>
                        <span class="after"></span>
                    </li>
                    <li class=""><a href="User_EditPass.aspx"><i class="icon-lock"></i>密码修改</a></li>
                </ul>
            </div>
            <div class="span9">
                <div class="tab-content">
                    <div style="height: auto;" id="accordion1-1" class="accordion collapse">
                        <form action="User_EditInfo.aspx" method="post" class="user-form">
                            <div class="alert alert-error hide">
                                <button class="close" data-dismiss="alert"></button>
                                您有某种形式的错误。请检查下面。
                            </div>
                            <label class="control-label">用户名</label>

                            <input type="text" id="txtUserName" name="txtUserName" class="m-wrap medium" value="<%= model.UserName%>" />

                            <label class="control-label">真实姓名</label>

                            <input type="text" id="txtTrueName" name="txtTrueName" class="m-wrap medium" value="<%= model.TrueName%>" />

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
                            <label class="control-label">联系电话</label>
                            <input type="text" id="Text1" name="txtPhone" class="m-wrap large" value="<%= model.Phone%>" />
                            <label class="control-label">电子邮箱</label>
                            <input type="text" id="Text2" name="txtEmail" class="m-wrap large" value="<%= model.Email%>" />
                            <label class="control-label">角色</label>
                            <div class="controls">
                                <select class="m-wrap medium " name="optRole" id="optRole">
                                    <%= BindUser() %>
                                </select>
                            </div>
                            <div class="submit-btn" style="margin-top: 20px;">
                                <button type="submit" class="btn blue"><i class='icon-ok'></i>保存</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <!--end span9-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>
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
