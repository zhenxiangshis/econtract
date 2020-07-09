var FormArticle = function () {

   
    var _add = function () {

        var form1 = $('.addnews-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                listProID: {
                    required: true
                },
                listClassID: {
                    required: true
                },
                txtTitle: {
                    required: true
                },
                txtImportace:{
                    number:true
                }
            },
            messages: {
                listProID: {
                    required: '产品不能为空'
                },
                listClassID: {
                    required: '分类不能为空'
                },
                txtTitle: {
                    required: '标题不能为空'
                },
                txtImportace: {
                    number:'显示顺序必须是数字'
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

        $('#listProID').select2({
            placeholder: "请选择",
            allowClear: true
        });
        $('#listClassID').select2({
            placeholder: "请选择",
            allowClear: true
        });

    }

    var _edit = function (cid,pid) {

        var form1 = $('.addnews-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                listProID: {
                    required: true
                },
                listClassID: {
                    required: true
                },
                txtTitle: {
                    required: true
                },
                txtImportace: {
                    number: true
                }
            },
            messages: {
                
                listProID: {
                    required: '产品不能为空'
                },
                listClassID: {
                    required: '分类不能为空'
                },
                txtTitle: {
                    required: '标题不能为空'
                },
                txtImportace: {
                    number: '显示顺序必须是数字'
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
        $('#listProID').val(pid).select2({
            placeholder: "请选择",
            allowClear: true
        });
        $('#listClassID').val(cid).select2({
            placeholder: "请选择",
            allowClear: true,

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

        $('#listDemoID').select2({
            placeholder: "请选择",
            allowClear: true
        });

    }

    var _editClass = function (p,d) {

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

        $('#listDemoID').val(d).select2({
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
        Edit: function (cid,pid) {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _edit(cid, pid);
            App.unblockUI(pageContent);
        },
        AddClass: function () {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _addClass();
            App.unblockUI(pageContent);
        },
        EditClass: function (p,d) {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _editClass(p,d);
            App.unblockUI(pageContent);
        }
    };

}();