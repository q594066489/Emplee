var CurrentPage = function () {

    jQuery.validator.addMethod("customUsername", function (value, element) {
        if (value === $('input[name="EmailAddress"]').val()) {
            return true;
        }

        return !$.validator.methods.email.apply(this, arguments);
    }, abp.localization.localize("RegisterFormUserNameInvalidMessage"));

    var _passwordComplexityHelper = new app.PasswordComplexityHelper();

    var handleRegister = function () {

        $('.register-form').validate({
            rules: {
                PasswordRepeat: {
                    equalTo: "#RegisterPassword"
                },
                UserName: {
                    required: true,
                    customUsername: true
                }
            },

            submitHandler: function (form) {
                form.submit();
            }
        });

        var $element = $('#RegisterPassword');
        _passwordComplexityHelper.setPasswordComplexityRules($element, window.passwordComplexitySetting);
    }
    $('input[type=radio][name=RoleSelect]').change(function () {
        if (this.value == '企业用户') {
            //alert("Allot Thai Gayo Bhai");
            $('#personInfoTitle').text("企业信息"); 

            $('#registerName').attr('placeholder','企业名称'); 
        }
        else if (this.value == '求职用户') {
            //alert("Transfer Thai Gayo");
            $('#personInfoTitle').text("个人信息");
            $('#registerName').attr('placeholder', '姓名'); 
        }

    });
    return {
        init: function () {
            handleRegister();
        }
    };
    
}();