const questionTable = document.querySelector('.question-table');
let data = [];

$(document).ready(function () {
    $.ajax({
        type: 'POST',
        url: 'Default.aspx/ShowAllQuestions',
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            displayQuestions(data)
        },
        error: function(error){
            console.log(error)
        }
    });
});

function displayQuestions(d){
    data = d.d
    console.log(data)
    for (i = 0; i < data.length; i++){
        const div = document.createElement('tr')

        let newdata = data[i]
        let id = newdata.Id
        let quesTitle = newdata.title;
        let quesBody = newdata.body.substr(0,100);
        let createTime = newdata.createTime;
        let voteCount = newdata.voteCount;
        let ansCount = newdata.ansCount;
        let username = newdata.username;
        let tags = newdata.Tags;
        let tagCount = tags.length;
        
        const dummyDiv = document.createElement('div')
        const newDiv = document.createElement('div')
        newDiv.classList.add('d-flex')
        newDiv.classList.add('flex-row')
        newDiv.classList.add('justify-content-start')
        newDiv.classList.add('gap-3')

        for (let i = 0; i< tagCount; i++){
            newDiv.innerHTML += `<div class="btn btn-outline-dark searchOnTags">${tags[i].Name}</div>`
        }

        dummyDiv.append(newDiv)

        div.innerHTML = 
        `<td>
            <div class="card p-2 d-flex flex-row justify-content-start align-items-center">
                <div class="card-body" style="width: 10%">
                    <strong><p> <span>${voteCount}</span> Votes </p></strong>
                    <strong><p> <span>${ansCount}</span> Answers </p></strong>
                </div>
                <div class="card-body" style="width: 80%">
                    <h3 class="card-title" id="${id}" onclick="ShowQuestionDetail(${i})">${quesTitle}</h3>
                    <div class="mb-2">${quesBody} ...</div>
                    ${dummyDiv.innerHTML}
                    <div class="float-end">
                        by <span class="text-primary">${username}</span> on ${createTime}
                    </div>
                </div>
            </div>
        </td>`
        questionTable.appendChild(div)
    }
}

function ShowQuestionDetail(i){
    sessionStorage.setItem("Question", JSON.stringify(data[i]))
    window.location.href=`QuestionDetail.aspx?QuestionID=${data[i].Id}`
}