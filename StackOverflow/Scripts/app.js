// const guest = document.querySelector('.guest')
// const loggedin = document.querySelector('.loggedin')
const searchBtn = document.querySelector('#searchBtn');
const lblSearch = document.querySelector('#lblSearch');
let searchOnTags = document.querySelector('.searchOnTags');

// const params = new Proxy(new URLSearchParams(window.location.search), {
//     get: (searchParams, prop) => searchParams.get(prop),
// });
// let value = params.vlogin;

// if (value == 1){
//     guest.style.display = 'none';
//     loggedin.style.display = 'block';
// }

searchBtn.addEventListener('click', function () {
    let search = lblSearch.value;
    window.location.href = `Search.aspx?Search=${search}`
})

window.addEventListener('DOMContentLoaded', ()=>{
    searchOnTags = document.querySelectorAll('.searchOnTags');
    searchOnTags.forEach(element => {
        element.addEventListener('click', function () {
            let search = element.innerHTML;
            window.location.href = `Search.aspx?Search=${search}`
        })
    });
})