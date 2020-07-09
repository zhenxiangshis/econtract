<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Contract_List.aspx.cs" Inherits="qihang.admin.Student.Contract_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" href="/admin/media/css/DT_bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/jquery-ui-1.10.1.custom.min.css" />
    <script></script>
    <link href="/admin/media/js/uploader/webuploader.css" rel="stylesheet" />
    <style>
        .portlet.box .form-horizontal.form-bordered .control-group {
            margin-left: 0px;
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <h3 class="page-title">协议管理 
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="/admin/main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">协议管理</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>协议管理</div>
                    <div class="actions">
                        <a href="javascript:void(0)" class="btn green addcontract"><i class="icon-plus"></i>添加合同</a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div id="dialog_confirm" class="modal hide fade" tabindex="-1" role="dialog" aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                            <h3>您确定要删除这条数据吗?</h3>
                        </div>
                        <div class="modal-body">
                            <p>这些项目将被永久删除，并且无法恢复。你确定吗？</p>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">取消</button>
                            <button data-dismiss="modal" class="btn red" onclick="DataTables.GotoUrl()">删除</button>
                        </div>
                    </div>
                    <table class="table table-striped table-bordered table-hover table-full-width" id="StudentList">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>合同名称</th>
                                <th>上传时间</th>
                                <th>签署时间</th>
                                <th style="width: 300px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ContractID")%></td>
                                        <td><%# Eval("Type")%></td>
                                        <td class=""><%# Eval("AddTime")%></td>
                                        <td><%# Eval("CreateTime")%></td>
                                        <td class="center marginmini">
                                            <%# SetDownload(Eval("ContractFile").ToString()) %>

                                            <a href="javascript:void(0);" data-url="<%# Eval("LinkUrl")%>" class="btn mini blue link"><i class="icon-share"></i>查看链接</a>
                                            <a href="Contract_Delete.aspx?id=<%# Eval("ContractID")%>" class="btn mini black"><i class="icon-trash"></i>删除</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <form id="form1" action="Contract_Add.aspx?sid=<%=model.StudentID%>" method="post" class="user-form form-horizontal form-bordered form-label-stripped" style="display: none;">
                        <div class="alert alert-error hide">
                            <button class="close" data-dismiss="alert"></button>
                            您有某种形式的错误。请检查下面。
                        </div>
                        <div class="control-group">
                            <label class="control-label">名称</label>
                            <div class="controls">
                                <input type="text" id="txtName" name="txtName" class="m-wrap medium" value="" placeholder="合同名称" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">合同模版</label>
                            <div class="controls">
                                <select class="m-wrap medium select2" name="listClass" id="listClass">
                                    <option value="">请选择</option>
                                    <option value="/upload/temp/合同模版.pdf">合同模版</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-actions">
                            <button type="submit" class="btn blue"><i class='icon-ok'></i>保存</button>
                            <a href="Accounts_UserAdmin.aspx" class="btn">取消</a>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>

    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="/admin/media/js/DT_bootstrap.js"></script>
    <script src="/admin/media/js/bootstrap-modal.js" type="text/javascript"></script>
    <script src="/admin/media/js/bootstrap-modalmanager.js" type="text/javascript"></script>

    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/table-dataTables.js"></script>
    <script src="/admin/media/js/layer/layer.js"></script>
    <script src="/admin/media/js/uploader/webuploader.min.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
            //DataTables.Studentlist();
            $(".addcontract").click(function () {
                layer.open({
                    type: 1,
                    title: "添加合同",
                    closeBtn: 2,
                    shadeClose: true,
                    btn: [],
                    area: ['40%'],
                    content: $(".user-form")
                })
            })
            $("#listClass").change(function () {
                var s = '<%=model.Name%>';
                var checkText = $("#listClass").find("option:selected").text(); //获取Select选择的text
                $("#txtName").val(s + checkText);
            })
            
            $(".link").click(function () {
                var url = $(this).data("url");
                layer.open({
                    type: 0,
                    title: "查看链接",
                    closeBtn: 2,
                    shadeClose: true,
                    //area: ['80%', '30%'],
                    content: '<%=model.Name%>，您需要签署服务协议，以保障您的合法权益，请点击下面的签署链接完成协议签署！（http://' + window.location.host + url + '）【起航教育】'
                })
            })
        });
    </script>
</asp:Content>
