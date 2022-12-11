const username = document.querySelector('#usernameLogin'),
      password = document.querySelector('#passwordLogin'),
      loginBtn = document.querySelector('#loginBtn'),
      togglePassword = document.querySelector('#togglePassword');

let valUName;

togglePassword.addEventListener('click', function () {
    // toggle the type attribute
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
    password.setAttribute('type', type);
    // toggle the eye slash icon
    this.classList.toggle('fa-eye-slash');
});

username.addEventListener('blur',function () {
    let inputText=this.value;
    var unameFormat = /^[a-zA-Z0-9]+$/;
    if(!inputText.match(unameFormat))
    {
        this.style.background = 'red';
        $(this).tooltip({title: "Username can't contain any special character"});
        valUName = false;
    } else {
        this.style.background = 'white';
        $(this).tooltip("dispose");
        valUName = true;
    }
})

function ValidateLogin(){
    if (username.value === '' || username.value === null){
        alert ("Username Can't be Empty")
        return false;
    } else if (password.value === ''){
        alert ("Password Can't be Empty")
        return false;
    } else if (valUName === false){
        alert ("Please resolve all the errors before Signing Up")
        return false;
    }else return true;
}