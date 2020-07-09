<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="admin_main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="breadcrumb" runat="Server">
    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
    <h3 class="page-title">控制面板 <small>快速导航和统计</small>
    </h3>   
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="main.aspx">控制面板</a>
        </li>        
    </ul>
    <!-- END PAGE TITLE & BREADCRUMB-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">    
    <div id="dashboard">
        <% if (_roleId == "1"){  %>
        <!-- BEGIN DASHBOARD STATS -->
        <div class="row-fluid">
            <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                <div class="dashboard-stat blue">
                    <div class="visual">
                        <i class="icon-comments"></i>
                    </div>
                    <div class="details">
                        <div class="number">
                            <%=_newsNumber %>
                        </div>
                        <div class="desc">
                            新闻公告
                        </div>
                    </div>
                    <a class="more" href="Article_List.aspx">查看 <i class="m-icon-swapright m-icon-white"></i>
                    </a>
                </div>
            </div>
            <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                <div class="dashboard-stat green">
                    <div class="visual">
                        <i class="icon-user"></i>
                    </div>
                    <div class="details">
                        <div class="number"><%=_productsNumber %></div>
                        <div class="desc">学员</div>
                    </div>
                    <a class="more" href="/admin/Student/Student_List.aspx">查看 <i class="m-icon-swapright m-icon-white"></i>
                    </a>
                </div>
            </div>
            <div class="span3 responsive" data-tablet="span6  fix-offset" data-desktop="span3">
                <div class="dashboard-stat purple">
                    <div class="visual">
                        <i class="icon-book"></i>
                    </div>
                    <div class="details">
                        <div class="number"><%=_dataNumber %></div>
                        <div class="desc">专题</div>
                    </div>
                    <a class="more" href="Article_List.aspx">查看 <i class="m-icon-swapright m-icon-white"></i>
                    </a>
                </div>
            </div>
            <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                <div class="dashboard-stat yellow">
                    <div class="visual">
                        <i class="icon-bar-chart"></i>
                    </div>
                    <div class="details">
                        <div class="number"><%=_statNumber %></div>
                        <div class="desc">当天访问量</div>
                    </div>
                    <a class="more" href="Stat_Main.aspx">查看 <i class="m-icon-swapright m-icon-white"></i>
                    </a>
                </div>
            </div>
        </div>        
        <div class="clearfix"></div>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="media/js/app.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            App.init(); // initlayout and core plugins
        });
    </script>
</asp:Content>
