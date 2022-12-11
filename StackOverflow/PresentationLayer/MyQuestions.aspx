<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/Site.Master" AutoEventWireup="true" CodeBehind="MyQuestions.aspx.cs" Inherits="StackOverflow.PresentationLayer.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/MyQuestions.js?v=1" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="my-question-body mt-5 d-flex flex-column justify-content-start align-items-center">
        <div class="card p-4 text-center">
            <h2> My Questions </h2>
        </div>
        <hr>
        <table class="myQuestion-table p-3" style="width: 90%">
            
        </table>
    </div>
</asp:Content>
