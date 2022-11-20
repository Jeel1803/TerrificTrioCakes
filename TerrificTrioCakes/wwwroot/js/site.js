//Contact Us
function contactUs() {
    let name = document.forms["contact"]["name"].value;
    let email = document.forms["contact"]["email"].value;
    let message = document.forms["contact"]["phone"].value;
    let message = document.forms["contact"]["message"].value;
    let subject = document.forms["contact"]["subject"].value;

    if (name == "" && email == "" && phone=="" && message == "" && subject == "") {
        alert("No information Entered")
    }
    else {
        alert("Querey Submitted")
    }
}

window.onscroll = () => {
    searchBtn.classList.remove('fa-times');
    searchBar.classList.remove('active');
    menu.classList.remove('fa-times');
    navbar.classList.remove('active');
    loginForm.classList.remove('active');
}

menu.addEventListener('click', () => {
    menu.classList.toggle('fa-times');
    navbar.classList.toggle('active');
});

searchBtn.addEventListener('click', () => {
    searchBtn.classList.toggle('fa-times');
    searchBar.classList.toggle('active');
});

formBtn.addEventListener('click', () => {
    loginForm.classList.add('active');
});

formClose.addEventListener('click', () => {
    loginForm.classList.remove('active');
});
