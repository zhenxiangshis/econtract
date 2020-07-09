<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Student_Edit.aspx.cs" Inherits="qihang.admin.Student.Student_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/admin/media/css/select2_metro.css" />
    <link rel="stylesheet" type="text/css" href="/admin/media/css/chosen.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <h3 class="page-title">学员信息修改 
    </h3>
    <ul class="breadcrumb">
        <li>
            <i class="icon-home"></i>
            <a href="/admin/main.aspx">控制面板</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="Student_List.aspx">学员管理</a>
            <i class="icon-angle-right"></i>
        </li>
        <li>
            <a href="javascript:;">学员信息修改</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box green ">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-user"></i>学员添加</div>
                    <div class="actions">
                        <a href="javascript:void(0)" class="btn blue autofill"><i class="icon-plus"></i>智能填充</a>
                        <a href="javascript:void(0)" class="btn red autofill2"><i class="icon-plus"></i>CRM填充</a>
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <form id="form1" action="Student_Edit.aspx?id=<%=model.StudentID %>" method="post" class="user-form form-horizontal ">
                        <div class="alert alert-error hide">
                            <button class="close" data-dismiss="alert"></button>
                            您有某种形式的错误。请检查下面。
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">姓名</label>
                                    <div class="controls">
                                        <input type="text" id="txtUserName" name="txtUserName" class="m-wrap medium" value="<%=model.Name %>" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">联系电话</label>
                                    <div class="controls">
                                        <input type="text" id="txtPhone" name="txtPhone" class="m-wrap medium" value="<%=model.Phone %>"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">学历</label>
                                    <div class="controls">
                                        <input type="text" id="txtEducation" name="txtEducation" class="m-wrap medium" value="<%=model.Education %>"/>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">学历形式</label>
                                    <div class="controls">
                                        <input type="text" id="txtEduType" name="txtEduType" class="m-wrap medium" value="<%=model.EduType %>"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">专业</label>
                                    <div class="controls">
                                        <input type="text" id="txtMajor" name="txtMajor" class="m-wrap medium" value="<%=model.Major %>"/>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">毕业时间</label>
                                    <div class="controls">
                                        <input type="text" id="txtGraTime" name="txtGraTime" class="m-wrap medium" value="<%=model.GraduationTime %>"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="control-group">
                                    <label class="control-label">邮寄地址</label>
                                    <div class="controls">
                                        <input type="text" id="txtAddress" name="txtAddress" class="m-wrap  span6" value="<%=model.Address %>"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">Email</label>
                                    <div class="controls">
                                        <input type="text" id="txtEmail" name="txtEmail" class="m-wrap large" value="<%=model.Email %>"/>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">QQ</label>
                                    <div class="controls">
                                        <input type="text" id="txtQQ" name="txtQQ" class="m-wrap large" value="<%=model.QQ %>"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">紧急联系人</label>
                                    <div class="controls">
                                        <input type="text" id="txtLinkName" name="txtLinkName" class="m-wrap large" value="<%=model.LinkName %>"/>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">紧急联系人电话</label>
                                    <div class="controls">
                                        <input type="text" id="txtLinkPhone" name="txtLinkPhone" class="m-wrap large" value="<%=model.LinkPhone %>"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">身份证号</label>
                            <div class="controls">
                                <input type="text" id="txtIDCard" name="txtIDCard" class="m-wrap large" value="<%=model.IDCard %>"/>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">付款金额</label>
                                    <div class="controls">
                                        <input type="text" id="txtMoney" name="txtMoney" class="m-wrap large" value="<%=model.Money %>" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">支付方式</label>
                                    <div class="controls">
                                        <select class="m-wrap medium select2" name="txtPayMethod" id="txtPayMethod" >
                                            <option value="微信">微信</option>
                                            <option value="支付宝">支付宝</option>
                                            <option value="淘宝">淘宝</option>
                                            <option value="转账">转账</option>
                                            <option value="储蓄卡分期">储蓄卡分期</option>
                                            <option value="其他">其他</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">班型</label>
                            <div class="controls">
                                <select class="m-wrap medium select2" name="listClass" id="listClass">
                                    <option value="系统精讲班">系统精讲班</option>
                                    <option value="高效抢分班">高效抢分班</option>
                                    <option value="VIP尊享通关班">VIP尊享通关班</option>
                                    <option value="导学精讲班">导学精讲班</option>
                                    <option value="全科领航班">全科领航班</option>
                                    <option value="VIP签约通关班">VIP签约通关班</option>
                                    <option value="京师密训通关班">京师密训通关班</option>
                                    <option value="BIM高级工程师">BIM高级工程师</option>
                                    <option value="其他">其他</option>
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
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/admin/media/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/additional-methods.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="/admin/media/js/select2.min.js"></script>
    <script src="/admin/media/js/app.js"></script>
    <script src="/admin/media/js/form-student.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            App.init();
            FormUser.Edit(<%=model.ClassName%>);
        });
    </script>
</asp:Content>
