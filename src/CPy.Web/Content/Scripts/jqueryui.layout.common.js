//class点击事件
$(function() {
    $(".easyui-accordion li a").click(function () {
        console.log('addtab');
        var $this = $(this);
        var href = $this.attr('src');
        var title = $this.text();
        addTab($this,title, href);
    });
    tabCloseEven();
});


//新建tab
function addTab(elment,title, url) {
    //修改选中样式
    $(".easyui-accordion div").each(function (index, value) {
        $(this).removeClass("selected");
    });
    elment.parent().addClass("selected");
    
    //如果tab标签存在选中，否则创建新tab
    if ($('#tabs').tabs('exists', title)) {
        $('#tabs').tabs('select', title);//选中并刷新
        var currTab = $('#tabs').tabs('getSelected');
        $('#tabs').tabs('update', {
            tab: currTab,
            options: {
                content: addiframe(url)
            }
        });

    } else {
        console.log("add");
        $('#tabs').tabs('add', {
            title: title,
            content: addiframe(url),
            closable: true
        });
    }
    tabClose();
}
//创建tab标签内容
function addiframe(url) {
    var iframe = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
    return iframe;
}

function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children(".tabs-closable").text();
        $('#mm').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
//绑定右键菜单事件
function tabCloseEven() {
    $('#mm').menu({
        onClick: function (item) {
            closeTab(item.id);
        }
    });
    return false;
}
function closeTab(action) {
    console.log("tg");
    var alltabs = $('#tabs').tabs('tabs');
    var currentTab = $('#tabs').tabs('getSelected');
    var allTabtitle = [];
    $.each(alltabs, function(i, n) {
        allTabtitle.push($(n).panel('options').title);
    });
    switch (action) {
        case "refresh":
            var iframe = $(currentTab.panel('options').content);
            var src = iframe.attr('src');
            $('#tabs').tabs('update', {
                tab: currentTab,
                options: {
                    content: addiframe(src)
                }
            });
            break;
        case "close":
            var currtabtitle = currentTab.panel('options').title;
            $('#tabs').tabs('close', currtabtitle);
            break;
        case "closeall":
            $.each(allTabtitle, function (i, n) {
                    $('#tabs').tabs('close', n);
            });
            break;
        case "closeother":
             currtabtitle = currentTab.panel('options').title;
            $.each(allTabtitle, function (i, n) {
                if (n != currtabtitle) {
                    $('#tabs').tabs('close', n);
                }
            });
            break;
        case "exit":
            $('#closeMenu').menu('hide');
            break;
    }
}
