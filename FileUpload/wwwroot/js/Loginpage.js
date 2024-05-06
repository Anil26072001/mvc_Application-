$(document).ready(function () {
    var isvalid = true;

    var idreferences = {
        loginform: "#LoginPage",
        emaildata: "#id-email",
        passworddata: "#password-id",
        errordata: "#error",
        errordata1: "#error1",
        emailicon: "#emailicon",
        passwordicon: "#passwordicon",
    };

    var emailregex = /^[a-z]{1}[a-z0-9]+@gmail.com$/;
    //var emailregex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    //var emailregex = `/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/i`;
    $(idreferences.emaildata).on("input", function () {
        var email_val = $(idreferences.emaildata).val();
        console.log(email_val);
        if (email_val == '') {
            $('#error').text('Please Enter Email').show();
            $(idreferences.emailicon).html('<i class="fas fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else if (!emailregex.test(email_val)) {
            $('#error').text('Please Enter valid Email').show();
            $(idreferences.emailicon).html('<i class="fas fa-exclamation-circle red"></i>').show();
            isvalid = false;
            return false;
        } else {
            $(idreferences.errordata).hide();
            $(idreferences.emailicon).html('<i class="fas fa-exclamation-circle"></i>').hide();
            return true;
        }
    });
    $(idreferences.passworddata).on("input", function () {
        var password_val = $(idreferences.passworddata).val();
        console.log(password_val);
        if (password_val == '') {
            $("#error1").text('Please Enter password').show();
            $('#passwordicon').html('<i class="fas fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        } else {
            $(idreferences.errordata1).hide();
            $(idreferences.passwordicon).html('<i class="fas fa-exclamation-circle"></i>').hide();
            isvalid = true;
            return true;
        }
    });

    $(idreferences.loginform).submit(function (e) {

        e.preventDefault();

        var email_val = $("#id-email").val();
        var password_val = $(idreferences.passworddata).val();
        console.log(password_val);
        if (email_val == '' && password_val != '') {
            $("#error").text('Please Enter Email').show();
            $(idreferences.emailicon).html('<i class="fas fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        if (password_val == '' && email_val !== '') {
            $('#error1').text('Please Enter password').show();
            $(idreferences.passwordicon).html('<i class="fas fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
     
        if (password_val == '' && email_val === '') {
            $(idreferences.errordata1).text('Please Enter password').show();
            $(idreferences.passwordicon).html('<i class="fas fa-exclamation-circle"></i>').show();
            $(idreferences.errordata).text('Please Enter Email').show();
            $(idreferences.emailicon).html('<i class="fas fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }

        if (isvalid) {
            alert("Login successfully")
            $("#LoginPage")[0].submit();
        }



    $(document).ready(function () {
          $('#forgotPasswordLink').click(function (e) {
                e.preventDefault(); // Prevent the default hyperlink behavior

                email = $(idreferences.emaildata).val()
                if (email !== null) {
                    // Send the email to the server
                    $.ajax({
                        url: '@Url.Action("ForgetPassword", "Account")',
                        method: 'POST',
                        data: { email: email },
                        success: function (response) {
                            // Handle the response from the server if needed
                            console.log(response);
                        },
                        error: function (xhr, status, error) {
                            // Handle errors if any
                            console.error(error);
                        }
                    });
                }
            });
        });
    
        
    });
});








