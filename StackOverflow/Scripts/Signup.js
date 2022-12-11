const username = document.querySelector('#Username'),
      email = document.querySelector('#Email'),
      signupBtn = document.querySelector('#signupBtn'),
      password = document.querySelector('#Password'),
      Oname = document.querySelector('#Name'),
      confirmPass = document.querySelector('#confirmPassword'),
      togglePassword = document.querySelector('#togglePassword'),
      toggleConPassword = document.querySelector('#toggleConPassword');

let valEmail,
    valName,
    valUName,
    valPass,
    valConPass;


email.addEventListener('blur',function () {
    let inputText=email.value;
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if(!inputText.match(mailformat))
    {
        this.style.background = 'red';
        $(this).tooltip({title: "Invalid Email"});
        valEmail = false;
    } else {
        this.style.background = 'white';
        $(this).tooltip("dispose");
        valEmail = true;
    }
})

username.addEventListener('blur',function () {
    let inputText=this.value;
    var unameFormat = /^[a-zA-Z0-9]+$/;
    if(!inputText.match(unameFormat))
    {
        this.style.background = 'red';
        $(this).tooltip({title: "Invalid Username"});
        valUName = false;
    } else {
        this.style.background = 'white';
        $(this).tooltip("dispose");
        valUName = true;
    }
})

Oname.addEventListener('blur',function () {
    let inputText=this.value;
    var unameFormat = /^[a-zA-Z_]+$/;
    if(!inputText.match(unameFormat))
    {
        this.style.background = 'red';
        $(this).tooltip({title: "Name can't have anything other than alphabets"});
        valName = false
    } else {
        this.style.background = 'white';
        $(this).tooltip("dispose");
        valName = true
    }
})

password.addEventListener('blur',function () {
    let inputText=this.value;
    var passFormat = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,15}$/;
    if(!inputText.match(passFormat))
    {
        this.style.background = 'red';
        $(this).tooltip({title: "Password must be 8-15 characters and must have at least one letter, one number and one special character"});
        valPass = false
    } else {
        this.style.background = 'white';
        $(this).tooltip("dispose");
        valPass = true
    }
})

confirmPass.addEventListener('blur',function () {
    if(password.value !== confirmPass.value)
    {
        this.style.background = 'red';
        $(this).tooltip({title: "Password doesn't match"});
        valConPass = false
    } else {
        this.style.background = 'white';
        $(this).tooltip("dispose");
        valConPass = true
    }
})

togglePassword.addEventListener('click', function () {
    // toggle the type attribute
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
    password.setAttribute('type', type);
    // toggle the eye slash icon
    this.classList.toggle('fa-eye-slash');
});
toggleConPassword.addEventListener('click', function () {
    // toggle the type attribute
    const type = confirmPass.getAttribute('type') === 'password' ? 'text' : 'password';
    confirmPass.setAttribute('type', type);
    // toggle the eye slash icon
    this.classList.toggle('fa-eye-slash');
});

function CheckValidations() {
    if (username.value === '' || email.value === '' || Oname.value === '' || password.value === '' || confirmPass.value === '' ){
        alert ("Please fill all the fields")
        return false;
    } else if ( valEmail === false || valName === false || valUName === false || valPass === false || valConPass === false){
        alert ("Please resolve all the errors before Signing Up")
        return false;
    } else return true;
}