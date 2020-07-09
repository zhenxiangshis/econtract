<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Job_Add.aspx.cs" Inherits="qihang.admin.Job.Job_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/chosen.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <h3 class="page-title">学员添加 
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="Student_List.aspx">学员管理</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">学员添加</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box green ">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>任务添加</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <form id="form1" action="Job_Add.aspx" method="post" class="user-form form-horizontal ">
                        <div class="alert alert-error hide">
                            <button class="close" data-dismiss="alert"></button>
                            您有某种形式的错误。请检查下面。
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">群组</label>
                                    <div class="controls">
                                        <input type="text" id="txtGroupName" name="txtGroupName" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">任务名称</label>
                                    <div class="controls">
                                        <input type="text" id="txtJobName" name="txtJobName" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">触发器名称</label>
                                    <div class="controls">
                                        <input type="text" id="txtTriggerName" name="txtTriggerName" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">执行时间</label>
                                    <div class="controls">
                                        <input type="text" id="txtCron" name="txtCron" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">执行功能/Url</label>
                                    <div class="controls">
                                        <input type="text" id="txtUrl" name="txtUrl" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">描述</label>
                                    <div class="controls">
                                        <input type="text" id="txtDes" name="txtDes" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        
                        <div class="form-actions">
                            <button type="submit" class="btn blue"><i class='icon-ok'></i>保存</button>
                            <a href="Job_List.aspx" class="btn">取消</a>
                        </div>
                    </form>
                    <!-- END FORM-->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/additional-methods.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/form-student.js"></script>
    <script src="/admin/media/js/layer/layer.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
            //FormUser.Add();
        });
    </script>
</asp:Content>
