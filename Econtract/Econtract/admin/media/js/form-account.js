var FormAccount = function () {

    var _add = function () {

        var form1 = $('.account-form');
        var error1 = $('.alert-error', form1);

        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-inline', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                txtName: {
                    required: true
                }
            },
            messages: {
                txtName: {
                    required: '名称不能为空.'
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

    var _edit = function (json) {

        _add();

        jQuery('#AccountRoleList .group-checkable').change(function () {
            var set = jQuery('#AccountRoleList input[name=role]');
            var checked = jQuery(this).is(":checked");
            jQuery(set).each(function () {
                if (checked) {
                    $(this).attr("checked", true);
                } else {
                    $(this).attr("checked", false);
                }
            });
            jQuery.uniform.update(set);
        });

        var strs = new Array(); //定义一数组
        strs = json.split(','); //字符分割      
        for (i = 0; i < strs.length ; i++) {
            $("#AccountRoleList input[name=role][value='" + strs[i] + "']").attr("checked", true);
        }
        jQuery.uniform.update('#AccountRoleList input[name=role]');

    }

    return {
        //main function to initiate the module
        Add: function () {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _add();
            App.unblockUI(pageContent);
        },

        Edit: function (json) {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _edit(json);
            App.unblockUI(pageContent);            
        }

    };

}();