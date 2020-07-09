var FormMenu = function () {

    var _add = function () {

        // use select2 dropdown instead of chosen as select2 works fine with bootstrap on responsive layouts.
        $('.select2_category').select2({
            placeholder: "选择一个选项",
            allowClear: true
        });
        // 图标选择
        $('#iconadd').click(function () {
            var _icon = $('#iconText li.label-success i').attr('class');
            $("#hicon").val(_icon);
            $('#iicon').removeClass().addClass(_icon);
            $('#iconText').modal('toggle')
        });
        // 图标选中样式
        jQuery('#iconText').on('click', 'ul.unstyled > li', function (e) {
            $('ul.unstyled > li', '#iconText').removeClass('label-success');
            $(this).addClass('label-success');
        });            
            
        var form1 = $('.menu-form');
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
                listTarget: {
                    required: true
                },
                txtId: {
                    required: true,
                    number: true
                }
            },
            messages: {
                txtName: {
                    required: '名称不能为空.'
                },
                listTarget: {
                    required: '父类不能为空.'
                },
                txtId: {
                    required: '排序号不能为空.',
                    number: '排序号必须数数字.'
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
                if ($('.menu-form').validate().form()) {
                    form.submit();
                    //return true;
                }
                return false;
            }
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
        Edit: function () {
            var pageContent = $('.page-content');
            App.blockUI(pageContent, true);
            _add();
            App.unblockUI(pageContent);
        },

    };

}();