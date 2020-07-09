var FormSences = function () {

    var _add = function () {

        var form1 = $('.ebook-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtTitle: {
                    required: true
                },
                txtGoUrl: {
                    required: true
                },
                //listType: {
                //    required: true
                //},
                //listTarget: {
                //    required: true
                //},
                txtAddTime: {
                    required: true
                },
            },
            messages: {
                txtTitle: {
                    required: '文件名不能为空'
                },
                txtGoUrl: {
                    required: '文件路径不能为空'
                },
                //listType: {
                //    required: '文件类别不能为空'
                //},
                //listTarget: {
                //    required: '用户级别不能为空'
                //},
                txtAddTime: {
                    required: '发表时间不能为空'
                },
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("name") == "optTrue") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter("#optTrue_error");
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

    }

    var _edit = function () {
        _add();
        //$('#listEbooktype').val(rid).select2({
        //    placeholder: "请选择",
        //    allowClear: true
        //});
    }
    var _edit2 = function (rid) {
        var form1 = $('.ebook-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtTitle: {
                    required: true
                },
                txtGoUrl: {
                    required: true
                },
                //listType: {
                //    required: true
                //},
                //listTarget: {
                //    required: true
                //},
                txtAddTime: {
                    required: true
                },
            },
            messages: {
                txtTitle: {
                    required: '文件名不能为空'
                },
                txtGoUrl: {
                    required: '文件路径不能为空'
                },
                //listType: {
                //    required: '文件类别不能为空'
                //},
                //listTarget: {
                //    required: '用户级别不能为空'
                //},
                txtAddTime: {
                    required: '发表时间不能为空'
                },
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("name") == "optTrue") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter("#optTrue_error");
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
        //$('#listTarget').val(rid).select2({
        //    placeholder: "请选择",
        //    allowClear: true
        //});
    }
    var _webadd = function () {

        var form1 = $('.ebookweb-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtTitle: {
                    required: true
                },
                listClassID: {
                    required: true,
                    number: true
                },
                txtAddTime: {
                    required: true
                }
            },
            messages: {
                txtTitle: {
                    required: '标题不能为空'
                },
                listClassID: {
                    required: '分类不能为空',
                    number: '格式错误'
                },
                txtAddTime: {
                    required: '发表时间不能为空'
                }
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("name") == "optTrue") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter("#optTrue_error");
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

        $('#listClassID').select2({
            placeholder: "请选择",
            allowClear: true
        });

    }

    var _addClass = function () {

        var form1 = $('.addclass-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtClassName: {
                    required: true
                }
            },
            messages: {
                txtClassName: {
                    required: '分类名称不能为空'
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

        $('#listClassID').select2({
            placeholder: "请选择",
            allowClear: true
        });


    }

    var _editClass = function (p, d) {

        var form1 = $('.addclass-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtClassName: {
                    required: true
                }
            },
            messages: {
                txtClassName: {
                    required: '分类名称不能为空'
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

        $('#listClassID').val(p).select2({
            placeholder: "请选择",
            allowClear: true
        });

    }
    var _webedit = function (rid) {

        var form1 = $('.ebookweb-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtTitle: {
                    required: true
                },
                listClassID: {
                    required: true,
                    number: true
                },
                txtAddTime: {
                    required: true
                }
            },
            messages: {
                txtTitle: {
                    required: '标题不能为空'
                },
                listClassID: {
                    required: '分类不能为空',
                    number: '格式错误'
                },
                txtAddTime: {
                    required: '发表时间不能为空'
                }
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("name") == "optTrue") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter("#optTrue_error");
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

        $('#listEbooktype').val(rid).select2({
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
            _edit();
            App.unblockUI(pageContent);
        },
        Edit2: function (rid) {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _edit2(rid);
            App.unblockUI(pageContent);
        },
        WebAdd: function () {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _webadd();
            App.unblockUI(pageContent);
        },
        WebEidt: function (pif) {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _webedit(pif);
            App.unblockUI(pageContent);
        },
        AddClass: function () {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _addClass();
            App.unblockUI(pageContent);
        },
        EditClass: function (p, d) {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _editClass(p, d);
            App.unblockUI(pageContent);
        }

    };

}();