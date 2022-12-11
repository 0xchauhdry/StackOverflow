<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StackOverflow.PresentationLayer.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/AllQuestions.js?v=1" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="question-body mt-5 d-flex flex-column justify-content-start align-items-center">
        <div class="card p-4 text-center">
            <h2>All Questions</h2>
        </div>
        <hr>
        <table class="question-table p-3" style="width: 90%">
            <%--<tr>
                <td>
                    <div class="card p-2 d-flex flex-row justify-content-start align-items-center">
                        <div class="card-body" style="width: 10%">
                            <strong><p> <span>0</span> Votes </p></strong>
                            <strong><p> <span>0</span> Answers </p></strong>
                        </div>
                        <div class="card-body" style="width: 80%">
                            <h3 class="card-title">Question Title will go here</h3>
                            <div class="mb-2">Lorem ipsum dolor sit amet, ut vis utroque oporteat constituam, ludus tractatos eam an, eos eu nullam sanctus utroque. 
                                Ubique abhorreant ius cu. Nostro denique vis ut. Affert gloriatur instructior sea ex. Et mel referrentur contentiones, eos ad putent verterem. 
                                Ius ei dictas invidunt maiestatis, ei ius tale brute vocent, has patrioque euripidis et. Usu illud decore in.</div>
                            <div class="d-flex flex-row justify-content-start gap-3">
                                <div class="btn btn-outline-dark">java</div>
                                <div class="btn btn-outline-dark">java</div>
                                <div class="btn btn-outline-dark">java</div>
                            </div>
                            <div class="float-end">
                                by <span class="text-primary">Nomi</span> on 9/23/2022 12:20 PM
                            </div>
                        </div>
                    </div>
                </td>
            </tr>--%>
        </table>
    </div>
</asp:Content>
