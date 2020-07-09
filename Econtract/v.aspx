<%@ Page Language="C#" AutoEventWireup="true" CodeFile="v.aspx.cs" Inherits="qihang.v" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <link href="/v3/css/buttons.css" rel="stylesheet" />
    <style>
        body {
            margin: 0;
            padding: 0;
            /*background-color:#c0c0c0;*/
        }

        #wrap {
            width: 950px;
            max-width: 100%;
            margin: 0 auto;
        }

        img {
            max-width: 100%;
            height: auto;
            width: auto\9;
            border: 0px;
            display: block;
        }

        .rotate90 {
            transform: rotate(90deg);
            -ms-transform: rotate(90deg); /* IE 9 */
            -moz-transform: rotate(90deg); /* Firefox */
            -webkit-transform: rotate(90deg); /* Safari 和 Chrome */
            -o-transform: rotate(90deg); /* Opera */
        }

        #signatureparent {
            color: darkblue;
            background-color: darkgrey;
            /*max-width:600px;*/
            padding: 20px;
        }

        /*This is the div within which the signature canvas is fitted*/
        #signature {
            /*float:left;*/
            width: 95%;
            height: 90%;
            margin: 0 auto;
            border: 2px dotted black;
            background-color: lightgrey;
        }

        canvas {
            width: 100%;
            height: 100%;
        }

        @media screen and (max-width: 1023px) {
            #wrap {
                width: 100%;
            }
        }
    </style>
</head>
<body>
    <div id="wrap">

    </div>
    <div id="content" class="">
        <div style="text-align:center;">请仔细阅读协议，确认无误后请在下方签名！</div>
        <div id="signature" class=""></div>
        <div id="tools" style="text-align:center;margin:10px 0;"><input type="button" id="ok" value="确定" class="button button-action button-rounded" style="margin-right:10px;" /><input type="button" id="reset" value="重置" class="button button-rounded" style="margin-left:10px;" /></div>
    </div>
    <!--<img id="image" src="" />-->

    <script src="../v3/js/jquery-1.8.3.min.js"></script>
    <script src="../v3/js/layer/layer.js"></script>
    <!--[if IE 9]>
    <script src="/v3/js/jSignature-master/libs/flashcanvas.js"></script>
    <![endif]-->
    <script src="../v3/js/jSignature-master/libs/jSignature.min.js"></script>
    <script>
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        $(function () {
            var phone = GetQueryString("m");
            var date = GetQueryString("d");
            var id = GetQueryString("i");
            $.ajax({
                url: '/api/GetContract.ashx',
                type: 'POST',
                dataType: "json",
                //processData: false,
                data: { phone: phone, r: Math.random(), date: date },
                success: function (json) {
                    layer.closeAll();
                    $.each(json, function (i, e) {
                        $("#wrap").append('<img src="' + e + '" />');
                    })
                },
                beforeSend: function () {
                    layer.load();
                }
            });
            //$("#wrap").append('<img src="/contracts/' + phone + '/' + date + '/1.png" /><img src="/contracts/' + phone + '/' + date + '/2.png" /><img src="/contracts/' + phone + '/' + date + '/3.png" /><img src="/contracts/' + phone + '/' + date + '/4.png" />')
            var $sigdiv = $("#signature").jSignature({
                'UndoButton': false,
                color: "#000",
                lineWidth: 3,
                height: '100%',
                width: '100%',
            })
            $("#ok").click(function () {
                var datapair = $sigdiv.jSignature("getData", "image");
                //$("#image").attr('src', 'data:' + datapair[0] + "," + datapair[1]);
                layer.load(1, {
                    shade: [0.1, '#fff'] //0.1透明度的白色背景
                });
                $.ajax({
                    url: '/api/create.ashx',
                    type: 'POST',
                    dataType: "json",
                    //processData: false,
                    data: { dataurl: datapair[1], phone: phone, r: Math.random(), id: id, date: date },
                    success: function (json) {
                        layer.closeAll();
                        //var s = json;
                        //$("#bill").html('<img src="' + json.imgUrl + '" / >');
                        layer.open({
                            type: 1,
                            title: "协议下载",
                            closeBtn: 2,
                            shadeClose: true,
                            area: ['80%', '30%'],
                            content: '<a href="' + json.Url + '"  >签署成功，点击预览！</a>'
                        })
                    }
                });
            })
            $("#reset").click(function () {
                var datapair = $sigdiv.jSignature("reset");
            })
        })
    </script>
</body>
</html>
