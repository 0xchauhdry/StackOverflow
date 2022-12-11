const questionTableSearch = document.querySelector('.question-tableSearch');
let searchQuery = document.querySelector('.searchQuery');
const paramSearch = new Proxy(new URLSearchParams(window.location.search), {
    get: (searchParams, prop) => searchParams.get(prop),
});
let search = paramSearch.Search;
searchQuery.innerHTML = search
console.log(search)

let dataSearch = [];

$(document).ready(function() {
    $.ajax({
        type: 'POST',
        url: 'Search.aspx/SearchQuestions',
        data: "{search: '" + search + "'}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            displayQuestionss(data)
        },
        error: function(error){
            console.log(error)
        }
    });
});

function displayQuestionss(d){
    dataSearch = d.d
    console.log(dataSearch)
    for (i = 0; i < dataSearch.length; i++){
        const div = document.createElement('tr')

        let newdata = dataSearch[i]
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
        questionTableSearch.appendChild(div)
    }
}

function ShowQuestionDetail(i){
    sessionStorage.setItem("Question", JSON.stringify(dataSearch[i]))
    window.location.href=`QuestionDetail.aspx?QuestionID=${dataSearch[i].Id}`
}