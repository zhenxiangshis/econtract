<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="User_EditPass.aspx.cs" Inherits="qihang.admin.Account.User_EditPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/chosen.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="span3">
                <ul class="ver-inline-menu tabbable margin-bottom-10">
                    <li class="">
                       <%-- <a href="User_EditInfo.aspx">
                            <i class="icon-cog"></i>
                            账户资料
                        </a>--%>

                        <span class="after"></span>
                    </li>
                    <li class="active"><a href="User_EditPass.aspx"><i class="icon-lock"></i>密码修改</a></li>
                </ul>
            </div>
            <div class="span9">
                <div class="form">
                    <div style="height: auto;" id="accordion3-3" class="accordion collapse">
                        <form action="User_EditPass.aspx" method="post" class="password-form ">
                            <div class="alert alert-error hide">
                                <button class="close" data-dismiss="alert"></button>
                                您有某种形式的错误。请检查下面。
                            </div>
                            <label class="control-label">原密码</label>
                            <input type="password" id="txtoPassword" name="txtoPassword" class="m-wrap medium" />
                            <label class="control-label">新密码</label>
                            <input type="password" id="txtnPassword" name="txtnPassword" class="m-wrap medium" />
                            <label class="control-label">新密码确认</label>
                            <input type="password" id="txtnPassword1" name="txtnPassword1" class="m-wrap medium" />
                            <div class="submit-btn">
                                <button type="submit" class="btn purple"><i class='icon-ok'></i> 修改</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <!--end span9-->
        </div></div>
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
            FormUser.Password();
        });
    </script>
</asp:Content>
