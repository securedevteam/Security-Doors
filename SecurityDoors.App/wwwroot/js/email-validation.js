function emailValidation() {
    var re = /^[\w-\.]+@@[\w-]+\.[a-z]{2,4}$/i;
    var myEmail = document.getElementById('email').value;
    var valid = re.test(myEmail);

    if (valid) {
        document.getElementById('submit').disabled = false;
        output = '';
    }
    else {
        document.getElementById('submit').setAttribute('disabled', 'disabled');
        output = 'Адрес электронной почты введен неправильно!';
    }

    document.getElementById('message').innerHTML = output;

    return valid;
}