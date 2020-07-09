var FormUser = function () {

    var _add = function () {

        var form1 = $('.user-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtUserName: {
                    required: true
                },
                txtPhone: {
                    required: true
                },
                txtIDCard: {
                    required: true,
                },
                txtMoney: {
                    required: true,
                },
                //listClass: {
                //    required: true
                //},
                
            },
            messages: {
                txtUserName: {
                    required: '姓名不能为空'
                },
                txtPhone: {
                    required: '手机号不能为空'
                },
                txtIDCard: {
                    required: '身份证不能为空'
                },
                txtMoney: {
                    required: '付款金额不能为空',
                },
                //listClass: {
                //    required: '班型不能为空'
                //}
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("name") == "optSex") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter("#optSex_error");
                } else {
                    error.insertAfter(element); // for other inputs, just perform default behavoir
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

        $('#listClass').select2({
            placeholder: "请选择",
            allowClear: true
        });

    }

    var _edit = function (rid) {

        var form1 = $('.user-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtUserName: {
                    required: true
                },
                txtPhone: {
                    required: true
                },
                //txtIDCard: {
                //    required: true,
                //},
                //listClass: {
                //    required: true
                //},
            },
            messages: {
                txtUserName: {
                    required: '姓名不能为空'
                },
                txtPhone: {
                    required: '手机号不能为空'
                },
                //txtIDCard: {
                //    required: '身份证不能为空'
                //},
                //listClass: {
                //    required: '班型不能为空'
                //}
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("name") == "optSex") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter("#optSex_error");
                } else {
                    error.insertAfter(element); // for other inputs, just perform default behavoir
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
        
        $('#listClass').val(rid).select2({
            placeholder: "请选择",
            allowClear: true
        });

    }


    return {
        //main function to initiate the module
        Add: function () {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _add();
            App.unblockUI(pageContent);
        },

        Edit: function (rid) {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _edit(rid);
            App.unblockUI(pageContent);
        },

    };

}();