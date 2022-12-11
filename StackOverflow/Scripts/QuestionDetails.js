const data = JSON.parse(sessionStorage.getItem("Question"))
const title = document.querySelector('#title')
const Qusername = document.querySelector('#Qusername')
const Qtime = document.querySelector('#Qtime')
const questionBody = document.querySelector('.questionBody')
const TagsDiv = document.querySelector('#TagsDiv')
const answerTable = document.querySelector('.Answer-table')
const displayVoteCount = document.querySelector('.voteCountQuestion')
const answerCount = document.querySelector('.numOfAns')
const upVoteBtn = document.querySelector('.upVoteQuestion')
const downVoteBtn = document.querySelector('.downVoteQuestion')

let voteCountA;
let ApprovalBtn;
let ApprovalBtns
let AnsStatusValue;
let upadtedAnsCount;

// Question Values
let QuestionID = data.Id
let quesTitle = data.title;
let quesBody = data.body;
let createTime = data.createTime;
let voteCount = data.voteCount;
let ansCount = data.ansCount;
let username = data.username;
let userid = data.userId;
let tags = data.Tags;
let tagCount = tags.length;

// Updating Question Values
title.innerText = quesTitle
Qusername.innerText = username
Qtime.innerText = createTime
questionBody.innerText = quesBody
displayVoteCount.innerText = voteCount
answerCount.innerHTML = ansCount
upVoteBtn.setAttribute('onclick',`upVoteQuestion(${QuestionID})`)
downVoteBtn.setAttribute('onclick',`downVoteQuestion(${QuestionID})`)

// Creating Tags Div

const newDiv = document.createElement('div')
newDiv.classList.add('d-flex')
newDiv.classList.add('flex-row')
newDiv.classList.add('justify-content-start')
newDiv.classList.add('gap-3')

for (let i = 0; i< tagCount; i++){
    newDiv.innerHTML += `<div class="btn btn-outline-dark searchOnTags">${tags[i].Name}</div>`
}

TagsDiv.append(newDiv)

//AJAX call to check question status

$(document).ready(function () {
    $.ajax({
        type: 'POST',
        url: 'QuestionDetail.aspx/UserVoteStatusQ',
        data: "{quesid: " + QuestionID + "}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            console.log(data.d);
            QuestionVotesStatus(data.d);
        },
        error: function(error){
            console.log(error)
        }
    });
});

// Updating Question Vote Status

function QuestionVotesStatus(d){
    if (d === 1){
        upVoteBtn.classList.remove('text-dark')
        upVoteBtn.classList.add('text-primary')
        upVoteBtn.removeAttribute("onclick");
    } else if ( d === -1){
        downVoteBtn.classList.remove('text-dark')
        downVoteBtn.classList.add('text-danger')
        downVoteBtn.removeAttribute("onclick");
    }
}

//AJAX call to Get All the Answers

$(document).ready(function () {
    $.ajax({
        type: 'POST',
        url: 'QuestionDetail.aspx/GetAllAnswers',
        data: "{ID: " + QuestionID + "}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            displayAnswers(data)
            $.ajax({
                type: 'POST',
                url: 'QuestionDetail.aspx/CurrentUserID',
                dataType: 'json',
                contentType: 'application/json',
                async: false,
                success: function (dataa) {
                    if (dataa.d === userid){
                        if (upadtedAnsCount > 1){
                            ApprovalBtns = document.querySelectorAll('.approvalBtn')
                            ApprovalBtns.forEach(a => {
                                console.log(a.id)
                                let newID = a.id.substring(9);
                                console.log(newID);
                                if (a.classList.contains('d-none')){
                                    a.classList.remove('d-none')
                                    a.classList.add('bi-plus-square')
                                }
                                a.setAttribute('onclick',`AnswerApproval(${newID})`)
                            })
                        }else if (upadtedAnsCount === 1){
                            ApprovalBtns = document.querySelector('.approvalBtn')
                            let newid = ApprovalBtns.id.substring(9);
                            console.log(newid);
                            if (ApprovalBtns.classList.contains('d-none')){
                                ApprovalBtns.classList.remove('d-none')
                                ApprovalBtns.classList.add('bi-plus-square')
                            }
                            ApprovalBtns.setAttribute('onclick',`AnswerApproval(${newid})`)
                        }
                    }
                },
                error: function(error){
                    console.log(error)
                }
            });
        },
        error: function(error){
            console.log(error)
        }
    });
});

//function to add answers to the page

function displayAnswers(d){
    ddata = d.d
    console.log(ddata)
    answerCount.innerHTML = ddata.length
    upadtedAnsCount = ddata.length
    for (i = 0; i < ddata.length; i++){
        const tr = document.createElement('tr')
        let newdata = ddata[i]
        let Id = newdata.Id;
        let ansBody = newdata.body;
        let createTime = newdata.creatTime;
        let voteCount = newdata.voteCount;
        let username = newdata.username;
        let ansStatus = newdata.AnswerStatus;

        tr.innerHTML = 
        `<td>
            <div class="card p-2 d-flex flex-row justify-content-start align-items-center">
                <div class="card-body d-flex flex-column justify-content-center align-items-center gap-1" style="width: 5%">
                    <button type="button" class="bi bi-caret-up-fill text-dark Vote upVote" id="up-${Id}" onclick="upVoteAnswer(${Id},${QuestionID})"></button>
                    <h3 class="answerVoteCount" id = "voteCount-${Id}">${voteCount}</h3>
                    <button type="button" class="bi bi-caret-down-fill text-dark Vote downVote" id="down-${Id}" onclick="downVoteAnswer(${Id},${QuestionID})"></button>
                    <button type="button" class="bi d-none approvalBtn" id="approval-${Id}"></button>
                </div>
                <div class="card-body" style="width: 85%">
                    <div class="mb-2">${ansBody}</div>
                    <div class="float-end">
                        Answered at ${createTime} by <span class="text-primary">${username}</span>
                    </div>
                </div>
            </div>
        </td>`
        answerTable.appendChild(tr)

        //AJAX call to check Answer Vote Status of the logged in user

        $.ajax({
            type: 'POST',
            url: 'QuestionDetail.aspx/UserVoteStatusA',
            data: "{ansid: " + Id + "}",
            dataType: 'json',
            contentType: 'application/json',
            async: false,
            success: function (data) {
                console.log(data.d);
                AnswerVotesStatus(data.d,Id);
            },
            error: function(error){
                console.log(error)
            }
        });

        if (ansStatus === 1){
            ApprovalBtn = document.querySelector(`#approval-${Id}`)
            ApprovalBtn.classList.remove('d-none')
            ApprovalBtn.classList.add('bi-hand-thumbs-up-fill')
            ApprovalBtn.classList.add('text-primary')
        }else if (ansStatus === -1){
            ApprovalBtn = document.querySelector(`#approval-${Id}`)
            ApprovalBtn.classList.remove('d-none')
            ApprovalBtn.classList.add('bi-hand-thumbs-down-fill')
            ApprovalBtn.classList.add('text-danger')
        }
    }
}

// Updating Question Vote Status

function AnswerVotesStatus(d,Id){
    if (d === 1){
        let upVoteABtn = document.querySelector(`#up-${Id}`)
        upVoteABtn.classList.remove('text-dark')
        upVoteABtn.classList.add('text-primary')
        upVoteABtn.removeAttribute("onclick");
    } else if ( d === -1){
        let downVoteABtn = document.querySelector(`#down-${Id}`)
        downVoteABtn.classList.remove('text-dark')
        downVoteABtn.classList.add('text-danger')
        downVoteABtn.removeAttribute("onclick");
    }
}


function upVoteAnswer(i,j){
    $.ajax({
        type: 'POST',
        url: 'QuestionDetail.aspx/UpVoteAnswer',
        data: "{AnsID: " + i + ", QuesID: " + j + "}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            if (data.d !== "Nothing"){
                alert("Please Login to Vote")
            } else {
                upVoteABtn = document.querySelector(`#up-${i}`)
                upVoteABtn.classList.remove('text-dark')
                upVoteABtn.classList.add('text-primary')
                upVoteABtn.removeAttribute("onclick");
                downVoteABtn = document.querySelector(`#down-${i}`)
                voteCountA = document.querySelector(`#voteCount-${i}`)
                if (downVoteABtn.classList.contains('text-danger')){
                    downVoteABtn.classList.remove('text-danger')
                    downVoteABtn.classList.add('text-dark')
                    downVoteABtn.setAttribute("onclick",`downVoteAnswer(${i},${j})`);
                    voteCountA.innerText = parseInt(voteCountA.innerText) + 2;
                } else {
                    voteCountA.innerText = parseInt(voteCountA.innerText) + 1;
                }
            }
        },
        error: function(error){
            console.log(error)
        }
    });
}

function downVoteAnswer(i,j){
    $.ajax({
        type: 'POST',
        url: 'QuestionDetail.aspx/DownVoteAnswer',
        data: "{AnsID: " + i + ", QuesID: " + j + "}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            if (data.d !== "Nothing"){
                alert("Please Login to Vote")
            } else {
                downVoteABtn = document.querySelector(`#down-${i}`)
                downVoteABtn.classList.remove('text-dark')
                downVoteABtn.classList.add('text-danger')
                downVoteABtn.removeAttribute("onclick");
                upVoteABtn = document.querySelector(`#up-${i}`)
                voteCountA = document.querySelector(`#voteCount-${i}`)
                if (upVoteABtn.classList.contains('text-primary')){
                    upVoteABtn.classList.remove('text-primary')
                    upVoteABtn.classList.add('text-dark')
                    upVoteABtn.setAttribute("onclick",`upVoteAnswer(${i},${j})`);
                    voteCountA.innerText = parseInt(voteCountA.innerText) - 2;
                } else {
                    voteCountA.innerText = parseInt(voteCountA.innerText) - 1;
                }
            }
        },
        error: function(error){
            console.log(error)
        }
    });
}
function upVoteQuestion(i){
    $.ajax({
        type: 'POST',
        url: 'QuestionDetail.aspx/UpVoteQuestion',
        data: "{QuesID: " + i + "}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            if (data.d !== "Nothing"){
                console.log(data.d)
                alert("Please Login to Vote")
            } else {
                upVoteBtn.classList.remove('text-dark')
                upVoteBtn.classList.add('text-primary')
                upVoteBtn.removeAttribute("onclick")
                if (downVoteBtn.classList.contains('text-danger')){
                    downVoteBtn.classList.remove('text-danger')
                    downVoteBtn.classList.add('text-dark')
                    downVoteBtn.setAttribute("onclick",`downVoteQuestion(${i})`);
                    displayVoteCount.innerText = parseInt(displayVoteCount.innerText) + 2;
                } else {
                    displayVoteCount.innerText = parseInt(displayVoteCount.innerText) + 1;
                }
            }
        },
        error: function(error){
            console.log(error)
        }
    });
}

function downVoteQuestion(i){
    $.ajax({
        type: 'POST',
        url: 'QuestionDetail.aspx/DownVoteQuestion',
        data: "{QuesID: " + i + "}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            if (data.d !== "Nothing"){
                alert("Please Login to Vote")
            } else {
                downVoteBtn.classList.remove('text-dark')
                downVoteBtn.classList.add('text-danger')
                downVoteBtn.removeAttribute("onclick");
                if (upVoteBtn.classList.contains('text-primary')){
                    upVoteBtn.classList.remove('text-primary')
                    upVoteBtn.classList.add('text-dark')
                    upVoteBtn.setAttribute("onclick",`upVoteQuestion(${i})`);
                    displayVoteCount.innerText = parseInt(displayVoteCount.innerText) - 2;
                } else {
                    displayVoteCount.innerText = parseInt(displayVoteCount.innerText) - 1;
                }
            }
        },
        error: function(error){
            console.log(error)
        }
    });
}

function AnswerApproval(i){
    let thatDiv = document.querySelector(`#approval-${i}`)
    if (thatDiv.classList.contains('bi-plus-square')){
        thatDiv.classList.remove('bi-plus-square')
        thatDiv.classList.add('bi-hand-thumbs-up-fill')
        thatDiv.classList.add('text-primary')
        AnsStatusValue = 1
    }else if (thatDiv.classList.contains('bi-hand-thumbs-up-fill')){
        thatDiv.classList.remove('bi-hand-thumbs-up-fill')
        thatDiv.classList.remove('text-primary')
        thatDiv.classList.add('bi-hand-thumbs-down-fill')
        thatDiv.classList.add('text-danger')
        AnsStatusValue = -1
    }else {
        thatDiv.classList.remove('bi-hand-thumbs-down-fill')
        thatDiv.classList.remove('text-danger')
        thatDiv.classList.add('bi-hand-thumbs-up-fill')
        thatDiv.classList.add('text-primary')
        AnsStatusValue = -1
    }
    $.ajax({
        type: 'POST',
        url: 'QuestionDetail.aspx/UpdateAnswerStatus',
        data: "{AnsID: " + i + ", value: " + AnsStatusValue + "}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function () {
            console.log('Yay')
        },
        error: function(error){
            console.log(error)
        }
    });
}