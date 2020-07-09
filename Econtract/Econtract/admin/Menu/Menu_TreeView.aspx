<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="Menu_TreeView.aspx.cs" Inherits="qihang.admin.Menu.Menu_TreeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="Server">
    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
    <h3 class="page-title">菜单详情 <small>管理后台的左侧菜单详情</small>
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="Menu_Treelist.aspx">菜单管理</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">菜单详情</a>
        </li>
    </ul>
    <!-- END PAGE TITLE & BREADCRUMB-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-sitemap"></i>菜单详情</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal form-view">
                        <h3>查看菜单详情 - <%= model.text%> </h3>
                        <h3 class="form-section">详细信息</h3>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">编号:</label>
                                    <div class="controls">
                                        <span class="text"><%= model._id%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">名称:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.text%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">父类:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.pname%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">排序号:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.order%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">图标:</label>
                                    <div class="controls">
                                        <span class="text"><i class="<%= model.icon%>"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12 ">
                                <div class="control-group">
                                    <label class="control-label">链接路径:</label>
                                    <div class="controls">
                                        <span class="text"><%= model.url%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <a href="Menu_TreeEdit.aspx?id=<%=model._id %>" class="btn purple"><i class="icon-pencil"></i> 修改</a>
                            <a href="Menu_Treelist.aspx" class="btn">返回</a>
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="Server">
    <script src="media/js/app.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
        });
    </script>
</asp:Content>
