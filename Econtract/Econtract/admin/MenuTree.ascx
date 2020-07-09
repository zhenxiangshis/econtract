<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuTree.ascx.cs" Inherits="admin_MenuTree" %>
<%@ OutputCache Duration="1" VaryByParam="none" %>
<li class="start active ">
    <a href="main.aspx" menuid="0">
        <i class="icon-home"></i>
        <span class="title">控制面板</span>
        <span class="selected"></span>
    </a>
</li>
<%= getTreeHtml("0") %>