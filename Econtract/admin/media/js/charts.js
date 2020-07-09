var Charts = function () {

    var options = {
        credits: {
            enabled: false
        },
        exporting: {
            enabled: false
        },
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false
        },
        title: {
            text: ''
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                showInLegend: true,
                
            },
            column:
                {
                    dataLabels:
                        {
                            enabled: true,
                            align:"center"
                        }
                }
        },
        //legend:{enabled:false},
        //xAxis: {//横轴的数据  097 
        //    categories: ['热场操视频 - 牙刷操', '热场操背景音乐', '企业及产品宣传视频', '主视觉设计', '产品资料包']
        //    },
        series: [{
            type: 'pie',
            name: '所占总比例',
            data:[]
            //data: [ 921, 332, 271, 259, 184],
        }]
    };

    return {
        //main function to initiate the module

        init: function () {
            $.getJSON('api/Stat.ashx', { type: "source" }, function (json) {
                
                options.series[0].data = json.data;
                options.title.text = '来源站点比率分析';
                $('#chart_1').highcharts(options);
            });
            $.getJSON('api/Stat.ashx', { type: "resolution" }, function (json) {
                options.series[0].data = json.data;
                options.title.text = '分辨率比率分析';
                $('#chart_2').highcharts(options);
            });
            $.getJSON('api/Stat.ashx', { type: "system" }, function (json) {
                options.series[0].data = json.data;
                options.title.text = '操作系统分析';
                $('#chart_3').highcharts(options);
            });
            $.getJSON('api/Stat.ashx', { type: "browser" }, function (json) {
                options.series[0].data = json.data;
                options.title.text = '浏览器内核比率';
                $('#chart_4').highcharts(options);
            });
            $.getJSON('api/Stat.ashx', { type: "time" }, function (json) {
                var option = {
                    credits: {
                        enabled: false
                    },
                    exporting: {
                        enabled: false
                    },
                    title: {
                        text: '每小时访问量',
                        x: -20 //center
                    },
                    subtitle: {
                        text: '最近4天访问量对比',
                        x: -20
                    },
                    xAxis: {
                        categories: ['0点', '1点', '2点', '3点', '4点', '5点', '6点', '7点', '8点', '9点', '10点', '11点', '12点', '13点', '14点', '15点', '16点', '17点', '18点', '19点', '20点', '21点', '22点', '23点']
                    },
                    yAxis: {
                        title: {
                            text: ''
                        }
                    },
                    tooltip: {
                        formatter: function () {
                            return '<b>' + this.series.name + ' ' + this.x + '</b><br/>' + '访问量: ' + this.y + '次';
                        }
                    },
                    series: json
                };
                $('#chart_5').highcharts(option);
            });
            $.getJSON('api/Stat.ashx', { type: "date" }, function (json) {
                var option = {
                    credits: {
                        enabled: false
                    },
                    exporting: {
                        enabled: false
                    },
                    title: {
                        text: '每天访问量',
                        x: -20 //center
                    },
                    subtitle: {
                        text: '最近4月访问量对比',
                        x: -20
                    },
                    xAxis: {
                        categories: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30', '31']
                    },
                    yAxis: {
                        title: {
                            text: ''
                        }
                    },
                    tooltip: {
                        formatter: function () {
                            return '<b>' + this.series.name + this.x + '日</b><br/>' + '访问量: ' + this.y + '次';
                        }
                    },
                    series: json
                };
                $('#chart_6').highcharts(option);
            });
        },
        Search: function () {

            $("#StatSearch").click(function () {
                var s = $('#dstart').val(), e = $('#dend').val();

                $('#StatDstart').html(s);
                $('#StatDend').html(e);

                $.getJSON('api/Stat.ashx', { type: "Search", sdate: s, edate: e }, function (json) {
                    var option = {
                        credits: {
                            enabled: false
                        },
                        exporting: {
                            enabled: false
                        },
                        title: {
                            text: '每天访问量',
                            x: -20 //center
                        },
                        subtitle: {
                            text: s + '到' + e + ' 时间段的访问量',
                            x: -20
                        },
                        xAxis: {
                            categories: json.categories
                        },
                        yAxis: {
                            title: {
                                text: ''
                            }
                        },
                        tooltip: {
                            formatter: function () {
                                return '<b>' + this.x + '</b><br/>' + '访问量: ' + this.y + '次';
                            }
                        },
                        series: json.series
                    };

                    $('#StatCount').html(json.Count);
                    $('#chart_1').highcharts(option);

                });

            });

        }

    };

}();