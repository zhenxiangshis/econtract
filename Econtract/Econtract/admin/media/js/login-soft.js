var Login = function() {
	return {
		//main function to initiate the module
	    init: function () {
	        $.cookie('page_sidebar_menu', '0', { path: '/' });

			$('.login-form').validate({
				errorElement: 'label', //default input error message container
				errorClass: 'help-inline', // default input error message class
				focusInvalid: false, // do not focus the last invalid input
				rules: {
					txtUsername: {
						required: true
					},
					txtPass: {
						required: true
					}
				},
				messages: {
					txtUsername: {
						required: "用户名不能为空."
					},
					txtPass: {
						required: "密码不能为空."
					}
				},
				invalidHandler: function(event, validator) { //display error alert on form submit   
					$('.alert-error', $('.login-form')).show();
				},
				highlight: function(element) { // hightlight error inputs
					$(element)
						.closest('.control-group').addClass('error'); // set error class to the control group
				},
				success: function(label) {
					label.closest('.control-group').removeClass('error');
					label.remove();
				},
				errorPlacement: function(error, element) {
					error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
				}
			});

			$('body').keypress(function (e) {
			    if (e.which == 13) {
			        //alert("回车");
			        if ($('.login-form').validate().form()) {
			            $('.login-form').submit();
			        }
			        return false;
			    }
			});

			$.backstretch([
				"media/image/bg/1.jpg",
				"media/image/bg/2.jpg",
				"media/image/bg/3.jpg",
				"media/image/bg/4.jpg"
			], {
				fade: 1000,
				duration: 8000
			});
			if (err != ''){
				$('#login_err').html(err);
				$('.alert-error').show();
			}

		}
	};
}();