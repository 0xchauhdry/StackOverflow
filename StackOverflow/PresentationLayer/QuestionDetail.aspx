<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/Site.Master" AutoEventWireup="true" CodeBehind="QuestionDetail.aspx.cs" Inherits="StackOverflow.PresentationLayer.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/QuestionDetails.js?v=1" defer></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="question-body mt-5 d-flex flex-column justify-content-start align-items-center">
        <div class="card" style="width: 90%">
            <div class="card-body">
                <h2 class="card-title" id="title"></h2>
                <p class="float-end">posted by <span class="text-primary" id="Qusername"></span> on <span id="Qtime"></span></p>
            </div>
        </div>
        <div class="card d-flex flex-row" style="width: 90%">
            <div class="card-body d-flex flex-column justify-content-center align-items-center" style="width: 5%">
                <button type="button" class="bi bi-caret-up-fill text-dark upVoteQuestion"></button>
                <h3 class="voteCountQuestion">0</h3>
                <button type="button" class="bi bi-caret-down-fill text-dark downVoteQuestion"></button>
            </div>
            <div class="card-body" style="width: 85%">
                <div class="questionBody">
                </div>
                <hr>
                <div id="TagsDiv"></div>
            </div>
        </div>
        <div class="question-body d-flex flex-column justify-content-start align-items-center" style="width: 100%">
            <div class="card p-4 text-center">
                <h3><span class="numOfAns"></span> Answers</h3>
            </div>
            <table class="Answer-table p-3" style="width: 90%">
                <%--<tr>
                    <td>
                        <div class="card p-2 d-flex flex-row justify-content-start align-items-center">
                            <div class="card-body d-flex flex-column justify-content-center align-items-center gap-1" style="width: 5%">
                                <button class="bi bi-caret-up-fill text-dark"></button>
                                <h3>0</h3>
                                <button class="bi bi-caret-down-fill text-dark"></button>
                                <button class="bi bi-hand-thumbs-down-fill"></button>
                            </div>
                            <div class="card-body" style="width: 85%">
                                <div class="mb-2">Lorem ipsum dolor sit amet, ut vis utroque oporteat constituam, ludus tractatos eam an, eos eu nullam sanctus utroque. 
                                    Ubique abhorreant ius cu. Nostro denique vis ut. Affert gloriatur instructior sea ex. Et mel referrentur contentiones, eos ad putent verterem. 
                                    Ius ei dictas invidunt maiestatis, ei ius tale brute vocent, has patrioque euripidis et. Usu illud decore in.</div>
                                <div class="float-end">
                                    Answered at 9/23/2022 12:20 PM by <span class="text-primary">Nomi</span>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>--%>
            </table>
        </div>
        <hr />
        <div style="width: 90%">
            <h3>Your Answer:</h3>
            <asp:TextBox ClientIDMode="Static" runat="server" ID="textareaAnswer" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Answer ..."/>          
        </div>
        <div class="form-outline mb-4">
            <asp:Label ClientIDMode="Static" runat="server" ID="lblAnswer" CssClass="form-label text-danger" />
        </div>
        <hr />
        <asp:button runat="server" id="addAnswerBtn" CssClass="btn btn-primary btn-lg btn-block" type="submit" onclick="AddAnswer" Text="Add Answer"/>
        <hr />
    </div>  
</asp:Content>
