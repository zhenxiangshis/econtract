var FormStat = function () {

    var _add = function () {

        var form1 = $('.sUrl-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtName: {
                    required: true
                },
                txtSum: {
                    required: true,
                    number: true
                },
                txtUrl: {
                    required: true
                }
            },
            messages: {
                txtName: {
                    required: '名称不能为空'
                },
                txtSum: {
                    required: '访问量不能为空',
                    number: '访问量必须为数字'
                },
                txtUrl: {
                    required: '链接路径不能为空'
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit    
                error1.show();
                App.scrollTo(error1, -200);
            },

            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.help-inline').removeClass('ok'); // display OK icon
                $(element)
                    .closest('.control-group').removeClass('success').addClass('error'); // set error class to the control group
            },

            unhighlight: function (element) { // revert the change dony by hightlight
                $(element)
                    .closest('.control-group').removeClass('error'); // set error class to the control group
            },

            success: function (label) {
                label
                    .addClass('valid').addClass('help-inline ok') // mark the current input as valid and display OK icon
                .closest('.control-group').removeClass('error').addClass('success'); // set success class to the control group
            },

            submitHandler: function (form) {
                if (form1.validate().form()) {
                    form.submit();
                }
                return false;
            }
        });

    }   


    return {
        //main function to initiate the module
        AddUrl: function () {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _add();
            App.unblockUI(pageContent);
        },

        Edit: function () {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _add();
            App.unblockUI(pageContent);
        }
    };

}();