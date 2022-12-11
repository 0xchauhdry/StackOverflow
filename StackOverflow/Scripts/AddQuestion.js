const title = document.querySelector('#title'),
      Desc = document.querySelector('#textarea'),
      Tags = document.querySelector('#Tags');

let allTags = document.querySelectorAll('.tm-tag');
let valTitle,
    valDesc,
    availableTags = [];

title.addEventListener('blur',function () {
    let inputText=this.value;
    len = inputText.length
    if(len < 10 || len > 100)
    {
        this.style.background = 'red';
        $(this).tooltip({title: "Title Must be b/w 10-100 characters"});
        valTitle = false
    } else {
        this.style.background = 'white';
        $(this).tooltip("dispose");
        valTitle = true
    }
})

Desc.addEventListener('blur',function () {
    let inputText=this.value;
    len = inputText.length
    if(len < 50)
    {
        this.style.borderColor = 'red';
        $(this).tooltip({title: "Description Must be atleast 50 characters"});
        valDesc = false
    } else {
        this.style.borderColor = '#ced4da';
        $(this).tooltip("dispose");
        valDesc = true
    }
})

function ValidateQuestion(){
    allTags = document.querySelectorAll('.tm-tag');
    if (title.value === ''){
        alert ("Title Can't be Empty")
        return false;
    } else if (Desc.value === ''){
        alert ("Description Can't be Empty")
        return false;
    } else if (allTags.length === 0){
        alert ("Select Atleast One Tag")
        return false;
    } else if (valTitle === false || valDesc === false){
        alert ("Please resolve all the errors before Adding Question")
        return false;
    } else {
        return true;
    }
}

Tags.addEventListener('keyup', function(){
    let search = Tags.value;
    $.ajax({
        type: 'POST',
        url: 'PostQuestion.aspx/SearchTag',
        data: "{search: '" + search + "'}",
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            GetList(data)
        },
        error: function(error){
            console.log(error)
        }
    });
})

function GetList(data){
    availableTags = [];
    Data = data.d;
    for (i = 0; i < Data.length; i++){
        availableTags.push(Data[i].Name)
    }
    $('#Tags').autocomplete({
        source: availableTags,
        autoFocus:true
    });
}

$(document).ready(function () {
    $('.tm-input').tagsManager({
        output: '#fieldTags'
    });
});

