<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeBehind="Menu_TreeAdd.aspx.cs" Inherits="qihang.admin.Menu.Menu_TreeAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/jquery-ui-1.10.1.custom.min.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/bootstrap-modal.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/chosen.css" />
    <style type="text/css">
        ul.unstyled > li { cursor: pointer; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
    <h3 class="page-title">菜单添加 <small>添加管理后台的左侧菜单</small>
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
            <a href="javascript:;">菜单添加</a>
        </li>
    </ul>
    <!-- END PAGE TITLE & BREADCRUMB-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box green ">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-sitemap"></i>菜单添加</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <form id="form1" action="Menu_TreeAdd.aspx" method="post" class="menu-form form-horizontal form-bordered form-label-stripped">
                        <div class="alert alert-error hide">
                            <button class="close" data-dismiss="alert"></button>
                            您有某种形式的错误。请检查下面。
                        </div>
                        <div class="control-group">
                            <label class="control-label">名称</label>
                            <div class="controls">
                                <input type="text" id="txtName" name="txtName" class="m-wrap medium" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">父类</label>
                            <div class="controls">
                                <div class="select2-wrapper">
                                    <select class="m-wrap large select2_category" name="listTarget" id="listTarget">
                                        <%= BiudTree() %>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">排序号</label>
                            <div class="controls">
                                <input type="text" id="txtId" name="txtId" class="m-wrap small tooltips" data-original-title="该父类下子节点的排列顺序号" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">链接路径</label>
                            <div class="controls">
                                <input type="text" id="txtUrl" name="txtUrl" class="m-wrap span6" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">图标</label>
                            <div class="controls">
                                <i class="" id="iicon"></i>
                                <a class="btn blue" data-toggle="modal" href="#iconText">浏览</a>
                                <input type="hidden" id="hicon" name="hicon" value="" />
                            </div>
                        </div>
                        <div class="form-actions">
                            <button type="submit" class="btn blue"><i class='icon-ok'></i> 保存</button>
                            <a href="Menu_Treelist.aspx" class="btn">取消</a>
                        </div>
                    </form>
                    <!-- END FORM-->
                </div>
            </div>
        </div>
    </div>
    <div id="iconText" class="modal hide fade container" tabindex="-1">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
            <h3>点击小图标选择</h3>
        </div>
        <div class="modal-body">
            <div class="row-fluid">
                <div class="span2">
                    <ul class="unstyled">
                        <li><i class="icon-adjust"></i>adjust</li>
                        <li><i class="icon-asterisk"></i>asterisk</li>
                        <li><i class="icon-ban-circle"></i>ban-circle</li>
                        <li><i class="icon-bar-chart"></i>bar-chart</li>
                        <li><i class="icon-barcode"></i>barcode</li>
                        <li><i class="icon-beaker"></i>beaker</li>
                        <li><i class="icon-bell"></i>bell</li>
                        <li><i class="icon-bolt"></i>bolt</li>
                        <li><i class="icon-book"></i>book</li>
                        <li><i class="icon-bookmark"></i>bookmark</li>
                        <li><i class="icon-bookmark-empty"></i>bookmark-empty</li>
                        <li><i class="icon-briefcase"></i>briefcase</li>
                        <li><i class="icon-bullhorn"></i>bullhorn</li>
                        <li><i class="icon-calendar"></i>calendar</li>
                        <li><i class="icon-camera"></i>camera</li>
                        <li><i class="icon-camera-retro"></i>camera-retro</li>
                        <li><i class="icon-certificate"></i>certificate</li>
                        <li><i class="icon-check"></i>check</li>
                        <li><i class="icon-check-empty"></i>check-empty</li>
                        <li><i class="icon-cloud"></i>cloud</li>
                        <li><i class="icon-cog"></i>cog</li>
                        <li><i class="icon-cogs"></i>cogs</li>
                    </ul>
                </div>
                <div class="span2">
                    <ul class="unstyled">
                        <li><i class="icon-comment-alt"></i>comment-alt</li>
                        <li><i class="icon-comments"></i>comments</li>
                        <li><i class="icon-comments-alt"></i>comments-alt</li>
                        <li><i class="icon-credit-card"></i>credit-card</li>
                        <li><i class="icon-dashboard"></i>dashboard</li>
                        <li><i class="icon-download"></i>download</li>
                        <li><i class="icon-download-alt"></i>download-alt</li>
                        <li><i class="icon-edit"></i>edit</li>
                        <li><i class="icon-envelope"></i>envelope</li>
                        <li><i class="icon-envelope-alt"></i>envelope-alt</li>
                        <li><i class="icon-exclamation-sign"></i>exclamation-sign</li>
                        <li><i class="icon-external-link"></i>external-link</li>
                        <li><i class="icon-eye-close"></i>eye-close</li>
                        <li><i class="icon-eye-open"></i>eye-open</li>
                        <li><i class="icon-facetime-video"></i>facetime-video</li>
                        <li><i class="icon-film"></i>film</li>
                        <li><i class="icon-filter"></i>filter</li>
                        <li><i class="icon-fire"></i>fire</li>
                        <li><i class="icon-flag"></i>flag</li>
                        <li><i class="icon-folder-close"></i>folder-close</li>
                        <li><i class="icon-folder-open"></i>folder-open</li>
                    </ul>
                </div>
                <div class="span2">
                    <ul class="unstyled">
                        <li><i class="icon-globe"></i>globe</li>
                        <li><i class="icon-group"></i>group</li>
                        <li><i class="icon-hdd"></i>hdd</li>
                        <li><i class="icon-headphones"></i>headphones</li>
                        <li><i class="icon-heart"></i>heart</li>
                        <li><i class="icon-heart-empty"></i>heart-empty</li>
                        <li><i class="icon-home"></i>home</li>
                        <li><i class="icon-inbox"></i>inbox</li>
                        <li><i class="icon-info-sign"></i>info-sign</li>
                        <li><i class="icon-key"></i>key</li>
                        <li><i class="icon-leaf"></i>leaf</li>
                        <li><i class="icon-legal"></i>legal</li>
                        <li><i class="icon-lemon"></i>lemon</li>
                        <li><i class="icon-lock"></i>lock</li>
                        <li><i class="icon-unlock"></i>unlock</li>
                        <li><i class="icon-magic"></i>magic</li>
                        <li><i class="icon-magnet"></i>magnet</li>
                        <li><i class="icon-map-marker"></i>map-marker</li>
                        <li><i class="icon-minus"></i>minus</li>
                        <li><i class="icon-minus-sign"></i>minus-sign</li>
                        <li><i class="icon-money"></i>money</li>
                        <li><i class="icon-move"></i>move</li>
                    </ul>
                </div>
                <div class="span2">
                    <ul class="unstyled">
                        <li><i class="icon-off"></i>off</li>
                        <li><i class="icon-ok"></i>ok</li>
                        <li><i class="icon-ok-circle"></i>ok-circle</li>
                        <li><i class="icon-ok-sign"></i>ok-sign</li>
                        <li><i class="icon-pencil"></i>pencil</li>
                        <li><i class="icon-picture"></i>picture</li>
                        <li><i class="icon-plane"></i>plane</li>
                        <li><i class="icon-plus"></i>plus</li>
                        <li><i class="icon-plus-sign"></i>plus-sign</li>
                        <li><i class="icon-print"></i>print</li>
                        <li><i class="icon-pushpin"></i>pushpin</li>
                        <li><i class="icon-qrcode"></i>qrcode</li>
                        <li><i class="icon-question-sign"></i>question-sign</li>
                        <li><i class="icon-random"></i>random</li>
                        <li><i class="icon-refresh"></i>refresh</li>
                        <li><i class="icon-remove"></i>remove</li>
                        <li><i class="icon-remove-circle"></i>remove-circle</li>
                        <li><i class="icon-remove-sign"></i>remove-sign</li>
                        <li><i class="icon-reorder"></i>reorder</li>
                        <li><i class="icon-resize-horizontal"></i>resize-horizontal</li>
                    </ul>
                </div>
                <div class="span2">
                    <ul class="unstyled">
                        <li><i class="icon-rss"></i>rss</li>
                        <li><i class="icon-screenshot"></i>screenshot</li>
                        <li><i class="icon-search"></i>search</li>
                        <li><i class="icon-share"></i>share</li>
                        <li><i class="icon-share-alt"></i>share-alt</li>
                        <li><i class="icon-shopping-cart"></i>shopping-cart</li>
                        <li><i class="icon-signal"></i>signal</li>
                        <li><i class="icon-signin"></i>signin</li>
                        <li><i class="icon-signout"></i>signout</li>
                        <li><i class="icon-sitemap"></i>sitemap</li>
                        <li><i class="icon-sort"></i>sort</li>
                        <li><i class="icon-sort-down"></i>sort-down</li>
                        <li><i class="icon-sort-up"></i>sort-up</li>
                        <li><i class="icon-star"></i>star</li>
                        <li><i class="icon-star-empty"></i>star-empty</li>
                        <li><i class="icon-star-half"></i>star-half</li>
                        <li><i class="icon-tag"></i>tag</li>
                        <li><i class="icon-tags"></i>tags</li>
                        <li><i class="icon-tasks"></i>tasks</li>
                        <li><i class="icon-thumbs-down"></i>thumbs-down</li>
                        <li><i class="icon-thumbs-up"></i>thumbs-up</li>
                        <li><i class="icon-time"></i>time</li>
                    </ul>
                </div>
                <div class="span2">
                    <ul class="unstyled">
                        <li><i class="icon-trash"></i>trash</li>
                        <li><i class="icon-trophy"></i>trophy</li>
                        <li><i class="icon-truck"></i>truck</li>
                        <li><i class="icon-umbrella"></i>umbrella</li>
                        <li><i class="icon-upload"></i>upload</li>
                        <li><i class="icon-upload-alt"></i>upload-alt</li>
                        <li><i class="icon-user"></i>user</li>
                        <li><i class="icon-user-md"></i>user-md</li>
                        <li><i class="icon-volume-off"></i>volume-off</li>
                        <li><i class="icon-volume-down"></i>volume-down</li>
                        <li><i class="icon-volume-up"></i>volume-up</li>
                        <li><i class="icon-warning-sign"></i>warning-sign</li>
                        <li><i class="icon-wrench"></i>wrench</li>
                        <li><i class="icon-zoom-in"></i>zoom-in</li>
                        <li><i class="icon-zoom-out"></i>zoom-out</li>
                        <li><i class="icon-gift"></i>gift</li>
                        <li><i class="icon-glass"></i>glass</li>
                        <li><i class="icon-comment"></i>comment</li>
                        <li><i class="icon-resize-vertical"></i>resize-vertical</li>
                        <li><i class="icon-retweet"></i>retweet</li>
                        <li><i class="icon-road"></i>road</li>
                        <li><i class="icon-music"></i>music</li>
                        <li><i class="icon-tint"></i>tint</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button type="button" data-dismiss="modal" class="btn">取消</button>
            <button type="button" class="btn blue" id="iconadd">确定</button>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/additional-methods.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script src="/admin/media/js/bootstrap-modal.js" type="text/javascript"></script>
    <script src="/admin/media/js/bootstrap-modalmanager.js" type="text/javascript"></script>
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/form-menu.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
            FormMenu.Add();
        });
    </script>
</asp:Content>
