<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Student_Add.aspx.cs" Inherits="qihang.admin.Student.Student_Add" %>

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
                    <div class="caption"><i class="icon-user"></i>学员添加</div>
                    <div class="actions">
                        <a href="javascript:void(0)" class="btn blue autofill"><i class="icon-plus"></i>智能填充</a>
                        <a href="javascript:void(0)" class="btn red autofill2"><i class="icon-plus"></i>CRM填充</a>
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <form id="form1" action="Student_Add.aspx" method="post" class="user-form form-horizontal ">
                        <div class="alert alert-error hide">
                            <button class="close" data-dismiss="alert"></button>
                            您有某种形式的错误。请检查下面。
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">姓名</label>
                                    <div class="controls">
                                        <input type="text" id="txtUserName" name="txtUserName" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">联系电话</label>
                                    <div class="controls">
                                        <input type="text" id="txtPhone" name="txtPhone" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">学历</label>
                                    <div class="controls">
                                        <input type="text" id="txtEducation" name="txtEducation" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">学历形式</label>
                                    <div class="controls">
                                        <input type="text" id="txtEduType" name="txtEduType" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">专业</label>
                                    <div class="controls">
                                        <input type="text" id="txtMajor" name="txtMajor" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">毕业时间</label>
                                    <div class="controls">
                                        <input type="text" id="txtGraTime" name="txtGraTime" class="m-wrap medium" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="control-group">
                                    <label class="control-label">邮寄地址</label>
                                    <div class="controls">
                                        <input type="text" id="txtAddress" name="txtAddress" class="m-wrap  span6" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">Email</label>
                                    <div class="controls">
                                        <input type="text" id="txtEmail" name="txtEmail" class="m-wrap large" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">QQ</label>
                                    <div class="controls">
                                        <input type="text" id="txtQQ" name="txtQQ" class="m-wrap large" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">紧急联系人</label>
                                    <div class="controls">
                                        <input type="text" id="txtLinkName" name="txtLinkName" class="m-wrap large" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">紧急联系人电话</label>
                                    <div class="controls">
                                        <input type="text" id="txtLinkPhone" name="txtLinkPhone" class="m-wrap large" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">身份证号</label>
                            <div class="controls">
                                <input type="text" id="txtIDCard" name="txtIDCard" class="m-wrap large" />
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">付款金额</label>
                                    <div class="controls">
                                        <input type="text" id="txtMoney" name="txtMoney" class="m-wrap large" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <label class="control-label">支付方式</label>
                                    <div class="controls">
                                        <select class="m-wrap medium select2" name="txtPayMethod" id="txtPayMethod">
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
                                    <%--<option value="特惠班">特惠班</option>
                                    <option value="基础班">基础班</option>
                                    <option value="保障班">保障班</option>
                                    <option value="无忧班">无忧班</option>
                                    <option value="总裁班">总裁班</option>--%>
                                    <%--<option value="企业委培保障班">企业委培保障班</option>
                                    <option value="全程无忧通关班">全程无忧通关班</option>
                                    <option value="名师内训取证班">名师内训取证班</option>
                                    <option value="名师护航总裁班">名师护航总裁班</option>--%>
                                    <option value="系统精讲班">系统精讲班</option>
                                    <option value="高效抢分班">高效抢分班</option>
                                    <option value="VIP尊享通关班">VIP尊享通关班</option>
                                    <option value="导学精讲班">导学精讲班</option>
                                    <option value="全科领航班">全科领航班</option>
                                    <option value="VIP签约通关班">VIP签约通关班</option>
                                    <option value="京师密训通关班">京师密训通关班</option>
                                    <option value="BIM高级工程师">BIM高级工程师</option>
                                    <%--<option value="BIM初级工程师">BIM初级工程师</option>
                                    <option value="BIM中级工程师">BIM中级工程师</option>--%>
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
                    <div class="control-group" style="display: none;" id="divcopy">
                        <div class="controls">
                            <label>复制学员报名表信息，每行一条</label>
                        </div>
                        <div class="controls">
                            <textarea name="copy" id="copy" class="m-wrap large" rows="15" placeholder="姓名：xxx&#10;性别：xx"></textarea>
                        </div>
                    </div>
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
            FormUser.Add();
            $(".autofill").click(function () {
                layer.open({
                    type: 1,
                    title: "智能填充",
                    content: $("#divcopy"),
                    btn: ["确定", "取消"],
                    btn1: function () {
                        var reg = new RegExp(" ", "g");//g,表示全部替换。
                        var reg2 = new RegExp("：", "g");//g,表示全部替换。
                        var _spilArr = ["姓名:", "性别:", "学历形式:", "专业:", "毕业时间:", "学历:", "出生日期:", "邮寄地址:", "身份证号码:", "手机号码:", "固定电话:", "Email:", "QQ号码:", "紧急联系人姓名:", "紧急联系人手机:"]
                        var s = $("#copy").val().replace(reg2, ":").replace(/\s+/g, '');
                        for (var i = 0; i < _spilArr.length; i++) {
                            var _str = _spilArr[i];
                            var ss = s.indexOf(_str);
                            s = s.replace(_str, "|" + _str);
                        }
                        //$.each(_spilArr, function (i, e) {
                        //    var _str = e;
                        //    var ss = s.indexOf(_str);
                        //    var store = s.replace(_str, "|" + _str);
                        //});

                        //var s = $("#copy").val().replace(/[\r\n]/g, "|");
                        var arr = s.split('|');

                        $.each(arr, function (i, e) {
                            var _c = e.trim().replace("：", ":").replace(/\s+/g, '');
                            if (_c.indexOf("姓名:") == 0) {
                                $("#txtUserName").val(_c.replace("姓名:", ""));
                            }
                            if (_c.indexOf("手机号码:") == 0) {
                                $("#txtPhone").val(_c.replace("手机号码:", ""));
                            }
                            if (_c.indexOf("学历形式:") == 0) {
                                $("#txtEduType").val(_c.replace("学历形式:", ""));
                            }
                            if (_c.indexOf("学历:") == 0) {
                                $("#txtEducation").val(_c.replace("学历:", ""));
                            }
                            if (_c.indexOf("毕业时间:") == 0) {
                                $("#txtGraTime").val(_c.replace("毕业时间:", ""));
                            }
                            if (_c.indexOf("专业:") == 0) {
                                $("#txtMajor").val(_c.replace("专业:", ""));
                            }
                            if (_c.indexOf("邮寄地址:") == 0) {
                                $("#txtAddress").val(_c.replace("邮寄地址:", ""));
                            }
                            if (_c.indexOf("身份证号码:") == 0) {
                                $("#txtIDCard").val(_c.replace("身份证号码:", ""));
                            }
                            if (_c.indexOf("Email:") == 0) {
                                $("#txtEmail").val(_c.replace("Email:", ""));
                            }
                            if (_c.indexOf("QQ号码:") == 0) {
                                $("#txtQQ").val(_c.replace("QQ号码:", ""));
                            }
                            if (_c.indexOf("紧急联系人姓名:") == 0) {
                                $("#txtLinkName").val(_c.replace("紧急联系人姓名:", ""));
                            }
                            if (_c.indexOf("紧急联系人手机:") == 0) {
                                $("#txtLinkPhone").val(_c.replace("紧急联系人手机:", ""));
                            }

                        })
                        layer.closeAll();
                    },
                    btn2: function () { }
                })
            })
            $(".autofill2").click(function () {
                layer.open({
                    type: 1,
                    title: "智能填充",
                    content: $("#divcopy"),
                    btn: ["确定", "取消"],
                    btn1: function () {
                        var reg = new RegExp(" ", "g");//g,表示全部替换。
                        var reg2 = new RegExp("：", "g");//g,表示全部替换。
                        var _spilArr = ["跟单时间", "工单创建人", "客户经理", "跟单类型", "客户姓名", "手机号码", "QQ号", "班级类型", "报名情况", "成交金额", "支付方式", "付款时间", "支付凭证", "实付金额", "身份证号", "邮寄地址", "备注"]
                        var s = $("#copy").val().replace(reg2, ":").replace(/\s+/g, '');
                        for (var i = 0; i < _spilArr.length; i++) {
                            var _str = _spilArr[i];
                            var ss = s.indexOf(_str);
                            s = s.replace(_str, "|" + _str);
                        }
                        //$.each(_spilArr, function (i, e) {
                        //    var _str = e;
                        //    var ss = s.indexOf(_str);
                        //    var store = s.replace(_str, "|" + _str);
                        //});

                        //var s = $("#copy").val().replace(/[\r\n]/g, "|");
                        var arr = s.split('|');

                        $.each(arr, function (i, e) {
                            var _c = e.trim().replace("：", ":").replace(/\s+/g, '');
                            if (_c.indexOf("客户姓名") == 0) {
                                $("#txtUserName").val(_c.replace("客户姓名", ""));
                            }
                            if (_c.indexOf("手机号码") == 0) {
                                var _str = _c.replace("手机号码", "");
                                $("#txtPhone").val(_str.substr(0, _str.indexOf("手机号码2")));
                            }
                            if (_c.indexOf("学历形式:") == 0) {
                                $("#txtEduType").val(_c.replace("学历形式:", ""));
                            }
                            if (_c.indexOf("学历") == 0) {
                                $("#txtEducation").val(_c.replace("学历", ""));
                            }
                            if (_c.indexOf("邮寄地址") == 0) {
                                $("#txtAddress").val(_c.replace("邮寄地址", ""));
                            }
                            if (_c.indexOf("身份证号") == 0) {
                                $("#txtIDCard").val(_c.replace("身份证号", ""));
                            }
                            if (_c.indexOf("QQ号") == 0) {
                                $("#txtQQ").val(_c.replace("QQ号", ""));
                            }
                            if (_c.indexOf("实付金额") == 0) {
                                $("#txtMoney").val(_c.replace("实付金额", ""));
                            }
                            if (_c.indexOf("支付方式") == 0) {
                                $("#txtPayMethod").val(_c.replace("支付方式", ""));
                            }
                        })
                        layer.closeAll();
                    },
                    btn2: function () { }
                })
            })
        });
    </script>
</asp:Content>
