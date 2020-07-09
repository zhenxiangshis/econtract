/**
Core script to handle the entire layout and base functions
**/
var App = function () {

    // IE mode
    var isRTL = false;
    var isIE8 = false;
    var isIE9 = false;
    var isIE10 = false;
    // 侧边栏宽度
    var sidebarWidth = 225;
    var sidebarCollapsedWidth = 35;

    var responsiveHandlers = [];

    // theme layout color set
    var layoutColorCodes = {
        'blue': '#4b8df8',
        'red': '#e02222',
        'green': '#35aa47',
        'purple': '#852b99',
        'grey': '#555555',
        'light-grey': '#fafafa',
        'yellow': '#ffb848'
    };
    // cookie 保存属性
    var _cookiEexpires = { expires: 1000, path: '/' };

    // 初始值设置
    var handleCookie = function () {

        // 侧边栏固定
        if ($.cookie('sidebar_toggler') == "true" && !body.hasClass('page-sidebar-closed')) {
            body.addClass("page-sidebar-closed");
        }
        // 主题
        layoutOption = $.cookie('layout_option');
        layoutOption != null ? $('.layout-option', panel).val(layoutOption) : "";
        headerOption = $.cookie('header_option');
        headerOption != null ? $('.header-option', panel).val(headerOption) : "";
        sidebarOption = $.cookie('sidebar_option');
        sidebarOption != null ? $('.sidebar-option', panel).val(sidebarOption) : "";
        footerOption = $.cookie('footer_option');
        footerOption != null ? $('.footer-option', panel).val(footerOption) : "";

        // 重置主题
        var panel = $('.color-panel');
        if (layoutOption === "boxed") {
            $("body").addClass("page-boxed");
            // set header
            $('.header > .navbar-inner > .container-fluid').removeClass("container-fluid").addClass("container");
            var cont = $('.header').after('<div class="container"></div>');
            // set content
            $('.page-container').appendTo('body > .container');
            // set footer
            if (footerOption === 'fixed' || sidebarOption === 'default') {
                $('.footer').html('<div class="container">' + $('.footer').html() + '</div>');
            } else {
                $('.footer').appendTo('body > .container');
            }
        }
        //header
        if (headerOption === 'fixed') {
            $("body").addClass("page-header-fixed");
            $(".header").removeClass("navbar-static-top").addClass("navbar-fixed-top");
        } else {
            $("body").removeClass("page-header-fixed");
            $(".header").removeClass("navbar-fixed-top").addClass("navbar-static-top");
        }
        //sidebar
        if (sidebarOption === 'fixed') {
            $("body").addClass("page-sidebar-fixed");
        } else {
            $("body").removeClass("page-sidebar-fixed");
        }
        //footer 
        if (footerOption === 'fixed') {
            $("body").addClass("page-footer-fixed");
        } else {
            $("body").removeClass("page-footer-fixed");
        }
        // 侧边栏
        var _menuid = $.cookie('page_sidebar_menu') != null ? $.cookie('page_sidebar_menu') : "0";
        var setMenu = function (i) {
            if (i != 0) {
                $('.start', '.page-sidebar').removeClass('active');
                $('.start').children('a').children('span.selected').remove();
                var menu = $('.page-sidebar a[menuid=' + i + ']');
                if (menu.attr('pmenuid') === "0") {
                    menu.children('.title').after('<span class="selected"></span>');
                }
                menu.parent().addClass('active');
                menu.children('.arrow').addClass('open');
                menu.attr('pmenuid') != 0 ? setMenu(menu.attr('pmenuid')) : '';
            } else {
                return;
            }
        }
        setMenu(_menuid);
    }
    // 浏览器判断
    var handleInit = function () {

        if ($('body').css('direction') === 'rtl') {
            isRTL = true;
        }

        isIE8 = !!navigator.userAgent.match(/MSIE 8.0/);
        isIE9 = !!navigator.userAgent.match(/MSIE 9.0/);
        isIE10 = !!navigator.userAgent.match(/MSIE 10/);

        if (isIE10) {
            jQuery('html').addClass('ie10'); // detect IE10 version
        }
    }
    // 
    var handleDesktopTabletContents = function () {
        // loops all page elements with "responsive" class and applies classes for tablet mode
        // For metornic  1280px or less set as tablet mode to display the content properly
        if ($(window).width() <= 1280 || $('body').hasClass('page-boxed')) {
            $(".responsive").each(function () {
                var forTablet = $(this).attr('data-tablet');
                var forDesktop = $(this).attr('data-desktop');
                if (forTablet) {
                    $(this).removeClass(forDesktop);
                    $(this).addClass(forTablet);
                }
            });
        }

        // loops all page elements with "responsive" class and applied classes for desktop mode
        // For metornic  higher 1280px set as desktop mode to display the content properly
        if ($(window).width() > 1280 && $('body').hasClass('page-boxed') === false) {
            $(".responsive").each(function () {
                var forTablet = $(this).attr('data-tablet');
                var forDesktop = $(this).attr('data-desktop');
                if (forTablet) {
                    $(this).removeClass(forTablet);
                    $(this).addClass(forDesktop);
                }
            });
        }
    }
    var handleSidebarState = function () {
        // 如果窗口宽度小于900移除侧边栏显示开关
        if ($(window).width() < 980) {
            $('body').removeClass("page-sidebar-closed");
        }
    }
    // 加载全局方法
    var runResponsiveHandlers = function () {
        // reinitialize other subscribed elements
        if (responsiveHandlers.length > 0) {
            for (var i in responsiveHandlers) {
                var each = responsiveHandlers[i];
                each.call();
            }
        }
    }
    // 重新绘制界面
    var handleResponsive = function () {
        handleTooltips();
        handleSidebarState();
        handleDesktopTabletContents();
        handleSidebarAndContentHeight();
        handleChoosenSelect();
        handleFixedSidebar();
        runResponsiveHandlers();
    }
    var handleResponsiveOnInit = function () {
        handleSidebarState();
        handleDesktopTabletContents();
        handleSidebarAndContentHeight();
    }
    // 窗口大小改变
    var handleResponsiveOnResize = function () {
        var resize;
        if (isIE8) {
            var currheight;
            $(window).resize(function () {
                if (currheight == document.documentElement.clientHeight) {
                    return; //quite event since only body resized not window.
                }
                if (resize) {
                    clearTimeout(resize);
                }
                resize = setTimeout(function () {
                    handleResponsive();
                }, 50); // wait 50ms until window resize finishes.                
                currheight = document.documentElement.clientHeight; // store last body client height
            });
        } else {
            $(window).resize(function () {
                if (resize) {
                    clearTimeout(resize);
                }
                resize = setTimeout(function () {
                    console.log('resize');
                    handleResponsive();
                }, 50); // wait 50ms until window resize finishes.
            });
        }
    }
    //* 核心处理器开始 *//
    // 设置空口可视区域
    var handleSidebarAndContentHeight = function () {
        var content = $('.page-content');
        var sidebar = $('.page-sidebar');
        var body = $('body');
        var height;

        if (body.hasClass("page-footer-fixed") === true && body.hasClass("page-sidebar-fixed") === false) {
            var available_height = $(window).height() - $('.footer').height();
            if (content.height() < available_height) {
                content.attr('style', 'min-height:' + available_height + 'px !important');
            }
        } else {
            if (body.hasClass('page-sidebar-fixed')) {
                height = _calculateFixedSidebarViewportHeight();
            } else {
                height = sidebar.height() + 20;
            }
            if (height >= content.height()) {
                content.attr('style', 'min-height:' + height + 'px !important');
            }
        }
    }
    // 设置导航菜单 2013-10-17 (cookie保存设置)
    var handleSidebarMenu = function () {

        jQuery('.page-sidebar').on('click', 'li > a', function (e) {
            if ($(this).next().hasClass('sub-menu') == false) {
                if ($('.btn-navbar').hasClass('collapsed') == false) {
                    $('.btn-navbar').click();
                }
                $.cookie('page_sidebar_menu', $(this).attr("menuid"), { path: '/' });
                return;
            }

            var parent = $(this).parent().parent();

            parent.children('li.open').children('a').children('.arrow').removeClass('open');
            parent.children('li.open').children('.sub-menu').slideUp(200);
            parent.children('li.open').removeClass('open');

            var sub = jQuery(this).next();
            if (sub.is(":visible")) {
                jQuery('.arrow', jQuery(this)).removeClass("open");
                jQuery(this).parent().removeClass("open");
                sub.slideUp(200, function () {
                    handleSidebarAndContentHeight();
                });
            } else {
                jQuery('.arrow', jQuery(this)).addClass("open");
                jQuery(this).parent().addClass("open");
                sub.slideDown(200, function () {
                    handleSidebarAndContentHeight();
                });
            }
            e.preventDefault();
        });
    }
    // 获取可是区域高度
    var _calculateFixedSidebarViewportHeight = function () {
        var sidebarHeight = $(window).height() - $('.header').height() + 1;
        if ($('body').hasClass("page-footer-fixed")) {
            sidebarHeight = sidebarHeight - $('.footer').height();
        }

        return sidebarHeight;
    }
    // 侧边栏菜单
    var handleFixedSidebar = function () {
        var menu = $('.page-sidebar-menu');

        if (menu.parent('.slimScrollDiv').size() === 1) { // destroy existing instance before updating the height
            menu.slimScroll({
                destroy: true
            });
            menu.removeAttr('style');
            $('.page-sidebar').removeAttr('style');
        }

        if ($('.page-sidebar-fixed').size() === 0) {
            handleSidebarAndContentHeight();
            return;
        }

        if ($(window).width() >= 980) {
            var sidebarHeight = _calculateFixedSidebarViewportHeight();

            menu.slimScroll({
                size: '7px',
                color: '#a1b2bd',
                opacity: .3,
                position: isRTL ? 'left' : ($('.page-sidebar-on-right').size() === 1 ? 'left' : 'right'),
                height: sidebarHeight,
                allowPageScroll: false,
                disableFadeOut: false
            });
            handleSidebarAndContentHeight();
        }
    }
    // 侧边栏固定特效 2013-10-17 (cookie保存设置)
    var handleFixedSidebarHoverable = function () {
        var body = $('body');

        if (body.hasClass('page-sidebar-fixed') === false) {
            return;
        }

        $('.page-sidebar').off('mouseenter').on('mouseenter', function () {

            if ((body.hasClass('page-sidebar-closed') === false || body.hasClass('page-sidebar-fixed') === false) || $(this).hasClass('page-sidebar-hovering')) {
                return;
            }

            body.removeClass('page-sidebar-closed').addClass('page-sidebar-hover-on');
            $(this).addClass('page-sidebar-hovering');
            $(this).animate({
                width: sidebarWidth
            }, 400, '', function () {
                $(this).removeClass('page-sidebar-hovering');
            });
        });

        $('.page-sidebar').off('mouseleave').on('mouseleave', function () {

            if ((body.hasClass('page-sidebar-hover-on') === false || body.hasClass('page-sidebar-fixed') === false) || $(this).hasClass('page-sidebar-hovering')) {
                return;
            }

            $(this).addClass('page-sidebar-hovering');
            $(this).animate({
                width: sidebarCollapsedWidth
            }, 400, '', function () {
                $('body').addClass('page-sidebar-closed').removeClass('page-sidebar-hover-on');
                $(this).removeClass('page-sidebar-hovering');
            });
        });
    }
    // 侧边栏切换
    var handleSidebarToggler = function () {
        // handle sidebar show/hide
        $('.page-sidebar').on('click', '.sidebar-toggler', function (e) {
            var body = $('body');
            var sidebar = $('.page-sidebar');

            if ((body.hasClass("page-sidebar-hover-on") && body.hasClass('page-sidebar-fixed')) || sidebar.hasClass('page-sidebar-hovering')) {
                body.removeClass('page-sidebar-hover-on');
                sidebar.css('width', '').hide().show();
                e.stopPropagation();
                runResponsiveHandlers();
                return;
            }

            $(".sidebar-search", sidebar).removeClass("open");

            if (body.hasClass("page-sidebar-closed")) {
                body.removeClass("page-sidebar-closed");
                if (body.hasClass('page-sidebar-fixed')) {
                    sidebar.css('width', '');
                }
                $.cookie('sidebar_toggler', "false", _cookiEexpires);
            } else {
                body.addClass("page-sidebar-closed");
                $.cookie('sidebar_toggler', "true", _cookiEexpires);
            }
            runResponsiveHandlers();
        });
    }
    // 返回顶部
    var handleGoTop = function () {
        /* set variables locally for increased performance */
        jQuery('.footer').on('click', '.go-top', function (e) {
            App.scrollTo();
            e.preventDefault();
        });
    }
    // 区域快快捷工具方法
    var handlePortletTools = function () {
        jQuery('body').on('click', '.portlet .tools a.remove', function (e) {
            e.preventDefault();
            var removable = jQuery(this).parents(".portlet");
            if (removable.next().hasClass('portlet') || removable.prev().hasClass('portlet')) {
                jQuery(this).parents(".portlet").remove();
            } else {
                jQuery(this).parents(".portlet").parent().remove();
            }
        });

        jQuery('body').on('click', '.portlet .tools a.reload', function (e) {
            e.preventDefault();
            var el = jQuery(this).parents(".portlet");
            App.blockUI(el);
            window.setTimeout(function () {
                App.unblockUI(el);
            }, 1000);
        });

        jQuery('body').on('click', '.portlet .tools .collapse, .portlet .tools .expand', function (e) {
            e.preventDefault();
            var el = jQuery(this).closest(".portlet").children(".portlet-body");
            if (jQuery(this).hasClass("collapse")) {
                jQuery(this).removeClass("collapse").addClass("expand");
                el.slideUp(200);
            } else {
                jQuery(this).removeClass("expand").addClass("collapse");
                el.slideDown(200);
            }
        });
    }
    // 表单美化
    var handleUniform = function () {
        if (!jQuery().uniform) {
            return;
        }
        var test = $("input[type=checkbox]:not(.toggle), input[type=radio]:not(.toggle, .star)");
        if (test.size() > 0) {
            test.each(function () {
                if ($(this).parents(".checker").size() == 0) {
                    $(this).show();
                    $(this).uniform();
                }
            });
        }
    }
    // 选项卡切换
    var handleTabs = function () {

        //修复显示区域
        var fixTabHeight = function (tab) {
            $(tab).each(function () {
                var content = $($($(this).attr("href")));
                var tab = $(this).parent().parent();
                if (tab.height() > content.height()) {
                    content.css('min-height', tab.height());
                }
            });
        }

        // fix tab content on tab shown
        $('body').on('shown', '.nav.nav-tabs.tabs-left a[data-toggle="tab"], .nav.nav-tabs.tabs-right a[data-toggle="tab"]', function () {
            fixTabHeight($(this));
        });

        $('body').on('shown', '.nav.nav-tabs', function () {
            handleSidebarAndContentHeight();
        });

        //fix tab contents for left/right tabs
        fixTabHeight('.nav.nav-tabs.tabs-left > li.active > a[data-toggle="tab"], .nav.nav-tabs.tabs-right > li.active > a[data-toggle="tab"]');

        //activate tab if tab id provided in the URL
        if (location.hash) {
            var tabid = location.hash.substr(1);
            $('a[href="#' + tabid + '"]').click();
        }
    }
    // 滚动条
    var handleScrollers = function () {
        $('.scroller').each(function () {
            $(this).slimScroll({
                size: '7px',
                color: '#a1b2bd',
                position: isRTL ? 'left' : 'right',
                height: $(this).attr("data-height"),
                alwaysVisible: ($(this).attr("data-always-visible") == "1" ? true : false),
                railVisible: ($(this).attr("data-rail-visible") == "1" ? true : false),
                disableFadeOut: true
            });
        });
    }
    // 提示条
    var handleTooltips = function () {
        if (App.isTouchDevice()) { // if touch device, some tooltips can be skipped in order to not conflict with click events
            jQuery('.tooltips:not(.no-tooltip-on-touch-device)').tooltip();
        } else {
            jQuery('.tooltips').tooltip();
        }
    }
    // 下拉菜单
    var handleDropdowns = function () {
        $('body').on('click', '.dropdown-menu.hold-on-click', function (e) {
            e.stopPropagation();
        })
    }
    // 提示框
    var handlePopovers = function () {
        jQuery('.popovers').popover();
    }
    // 下来菜单美化
    var handleChoosenSelect = function () {
        if (!jQuery().chosen) {
            return;
        }

        $(".chosen").each(function () {
            $(this).chosen({
                allow_single_deselect: $(this).attr("data-with-diselect") === "1" ? true : false
            });
        });
    }
    // 图片框
    var handleFancybox = function () {
        if (!jQuery.fancybox) {
            return;
        }

        if (jQuery(".fancybox-button").size() > 0) {
            jQuery(".fancybox-button").fancybox({
                groupAttr: 'data-rel',
                prevEffect: 'none',
                nextEffect: 'none',
                closeBtn: true,
                helpers: {
                    title: {
                        type: 'inside'
                    }
                }
            });
        }
    }
    // 设置主题  2013-10-17 (cookie保存设置)
    var handleTheme = function () {

        var panel = $('.color-panel');

        //重置主题
        var resetLayout = function () {
            $("body").
                removeClass("page-boxed").
                removeClass("page-footer-fixed").
                removeClass("page-sidebar-fixed").
                removeClass("page-header-fixed");

            $('.header > .navbar-inner > .container').removeClass("container").addClass("container-fluid");

            if ($('.page-container').parent(".container").size() === 1) {
                $('.page-container').insertAfter('.header');
            }

            if ($('.footer > .container').size() === 1) {
                $('.footer').html($('.footer > .container').html());
            } else if ($('.footer').parent(".container").size() === 1) {
                $('.footer').insertAfter('.page-container');
            }

            $('body > .container').remove();
        }

        var lastSelectedLayout = '';
        var setLayout = function () {

            var layoutOption = $('.layout-option', panel).val();
            $.cookie('layout_option', layoutOption, _cookiEexpires);
            var sidebarOption = $('.sidebar-option', panel).val();
            $.cookie('sidebar_option', sidebarOption, _cookiEexpires);
            var headerOption = $('.header-option', panel).val();
            $.cookie('header_option', headerOption, _cookiEexpires);
            var footerOption = $('.footer-option', panel).val();
            $.cookie('footer_option', footerOption, _cookiEexpires);

            if (sidebarOption == "fixed" && headerOption == "default") {
                alert('导航默认形式不支持固定侧边栏。继续用默认侧边栏默认导航。');
                $('.sidebar-option', panel).val("default");
                sidebarOption = 'default';
                $.cookie('sidebar_option', 'default');
            }

            resetLayout(); // 重置主题

            if (layoutOption === "boxed") {
                $("body").addClass("page-boxed");

                // set header
                $('.header > .navbar-inner > .container-fluid').removeClass("container-fluid").addClass("container");
                var cont = $('.header').after('<div class="container"></div>');

                // set content
                $('.page-container').appendTo('body > .container');

                // set footer
                if (footerOption === 'fixed' || sidebarOption === 'default') {
                    $('.footer').html('<div class="container">' + $('.footer').html() + '</div>');
                } else {
                    $('.footer').appendTo('body > .container');
                }
            }

            if (lastSelectedLayout != layoutOption) {
                //layout changed, run responsive handler:
                runResponsiveHandlers();
            }
            lastSelectedLayout = layoutOption;

            //header
            if (headerOption === 'fixed') {
                $("body").addClass("page-header-fixed");
                $(".header").removeClass("navbar-static-top").addClass("navbar-fixed-top");
            } else {
                $("body").removeClass("page-header-fixed");
                $(".header").removeClass("navbar-fixed-top").addClass("navbar-static-top");
            }

            //sidebar
            if (sidebarOption === 'fixed') {
                $("body").addClass("page-sidebar-fixed");
            } else {
                $("body").removeClass("page-sidebar-fixed");
            }

            //footer 
            if (footerOption === 'fixed') {
                $("body").addClass("page-footer-fixed");
            } else {
                $("body").removeClass("page-footer-fixed");
            }

            handleSidebarAndContentHeight(); // fix content height            
            handleFixedSidebar(); // reinitialize fixed sidebar
            handleFixedSidebarHoverable(); // reinitialize fixed sidebar hover effect
        }

        // handle theme colors
        var setColor = function (color) {
            $('#style_color').attr("href", "./media/css/" + color + ".css");
            $.cookie('style_color', color, _cookiEexpires);
        }

        $('.icon-color', panel).click(function () {
            $('.color-mode').show();
            $('.icon-color-close').show();
        });

        $('.icon-color-close', panel).click(function () {
            $('.color-mode').hide();
            $('.icon-color-close').hide();
        });

        $('li', panel).click(function () {
            setColor($(this).attr("data-style"));
            $('.inline li', panel).removeClass("current");
            $(this).addClass("current");
        });

        $('.layout-option, .header-option, .sidebar-option, .footer-option', panel).change(setLayout);

    }
    // 给ie添加 默认文字
    var handleFixInputPlaceholderForIE = function () {
        //fix html5 placeholder attribute for ie7 & ie8
        if (isIE8 || isIE9) { // ie7&ie8
            // this is html5 placeholder fix for inputs, inputs with placeholder-no-fix class will be skipped(e.g: we need this for password fields)
            jQuery('input[placeholder]:not(.placeholder-no-fix), textarea[placeholder]:not(.placeholder-no-fix)').each(function () {

                var input = jQuery(this);

                if (input.val() == '' && input.attr("placeholder") != '') {
                    input.addClass("placeholder").val(input.attr('placeholder'));
                }

                input.focus(function () {
                    if (input.val() == input.attr('placeholder')) {
                        input.val('');
                    }
                });

                input.blur(function () {
                    if (input.val() == '' || input.val() == input.attr('placeholder')) {
                        input.val(input.attr('placeholder'));
                    }
                });
            });
        }
    }
    // 设置提示框
    var handleMessage = function () {

        $._messengerDefaults = {
            extraClasses: 'messenger-fixed messenger-theme-block messenger-on-top'
        }

        if ($.cookie('Exception') != null) {
            if ($.cookie('Exception') != 'null') {
                var Exception = $.parseJSON($.cookie('Exception'));
                $.globalMessenger().post({
                    message: decodeURIComponent(Exception.msg),
                    type: Exception.err,
                    showCloseButton: true
                });
                $.removeCookie('Exception', { path: '/' });
            }
        }
    }

    //* END:CORE HANDLERS *//

    return {

        //main function to initiate template pages
        init: function () {

            //IMPORTANT!!!: Do not modify the core handlers call order.
            handleCookie();
            //核心函数
            handleInit();
            handleMessage(); //弹出框
            handleResponsiveOnResize(); // 窗口大小改变    
            handleUniform(); //表单美化
            handleScrollers(); // 滚动条
            handleResponsiveOnInit(); // 处理加载页面            

            //布局
            handleTheme(); // handles style customer tool
            handleFixedSidebar(); // handles fixed sidebar menu
            handleFixedSidebarHoverable(); // handles fixed sidebar on hover effect 
            handleSidebarMenu(); // handles main menu
            handleSidebarToggler(); // handles sidebar hide/show            
            handleFixInputPlaceholderForIE(); // fixes/enables html5 placeholder attribute for IE9, IE8
            handleGoTop(); //handles scroll to top functionality in the footer             

            //ui component handlers
            handlePortletTools(); // handles portlet action bar functionality(refresh, configure, toggle, remove)
            handleDropdowns(); // handle dropdowns
            handleTabs(); // handle tabs
            handleTooltips(); // handle bootstrap tooltips
            handlePopovers(); // handles bootstrap popovers
            handleChoosenSelect(); // handles bootstrap chosen dropdowns             

            App.addResponsiveHandler(handleChoosenSelect); // reinitiate chosen dropdown on main content resize. disable this line if you don't really use chosen dropdowns.
        },

        fixContentHeight: function () {
            handleSidebarAndContentHeight();
        },

        addResponsiveHandler: function (func) {
            responsiveHandlers.push(func);
        },

        // useful function to make equal height for contacts stand side by side
        setEqualHeight: function (els) {
            var tallestEl = 0;
            els = jQuery(els);
            els.each(function () {
                var currentHeight = $(this).height();
                if (currentHeight > tallestEl) {
                    tallestColumn = currentHeight;
                }
            });
            els.height(tallestEl);
        },

        // wrapper function to scroll to an element
        scrollTo: function (el, offeset) {
            pos = el ? el.offset().top : 0;
            jQuery('html,body').animate({
                scrollTop: pos + (offeset ? offeset : 0)
            }, 'slow');
        },

        scrollTop: function () {
            App.scrollTo();
        },

        // wrapper function to  block element(indicate loading)
        blockUI: function (el, centerY) {
            var el = jQuery(el);
            el.block({
                message: '<img src="/admin/media/image/ajax-loading.gif" align="">',
                centerY: centerY != undefined ? centerY : true,
                css: {
                    top: '10%',
                    border: 'none',
                    padding: '2px',
                    backgroundColor: 'none'
                },
                overlayCSS: {
                    backgroundColor: '#000',
                    opacity: 0.05,
                    cursor: 'wait'
                }
            });
        },

        // wrapper function to  un-block element(finish loading)
        unblockUI: function (el) {
            jQuery(el).unblock({
                onUnblock: function () {
                    jQuery(el).removeAttr("style");
                }
            });
        },

        // initializes uniform elements
        initUniform: function (els) {

            if (els) {
                jQuery(els).each(function () {
                    if ($(this).parents(".checker").size() == 0) {
                        $(this).show();
                        $(this).uniform();
                    }
                });
            } else {
                handleUniform();
            }

        },

        // initializes choosen dropdowns
        initChosenSelect: function (els) {
            $(els).chosen({
                allow_single_deselect: true
            });
        },

        initFancybox: function () {
            handleFancybox();
        },

        getActualVal: function (el) {
            var el = jQuery(el);
            if (el.val() === el.attr("placeholder")) {
                return "";
            }

            return el.val();
        },

        getURLParameter: function (paramName) {
            var searchString = window.location.search.substring(1),
                i, val, params = searchString.split("&");

            for (i = 0; i < params.length; i++) {
                val = params[i].split("=");
                if (val[0] == paramName) {
                    return unescape(val[1]);
                }
            }
            return null;
        },

        // check for device touch support
        isTouchDevice: function () {
            try {
                document.createEvent("TouchEvent");
                return true;
            } catch (e) {
                return false;
            }
        },

        isIE8: function () {
            return isIE8;
        },

        isRTL: function () {
            return isRTL;
        },

        getLayoutColorCode: function (name) {
            if (layoutColorCodes[name]) {
                return layoutColorCodes[name];
            } else {
                return '';
            }
        }

    };

}();