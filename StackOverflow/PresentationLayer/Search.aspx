<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="StackOverflow.PresentationLayer.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/Search.js?v=1" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="question-body mt-5 d-flex flex-column justify-content-start align-items-center">
        <div class="card p-4 text-center">
            <h2>Questions containing "<span class="searchQuery"></span>"</h2>
        </div>
        <hr>
        <table class="question-tableSearch p-3" style="width: 90%">
            
        </table>
    </div>
</asp:Content>
