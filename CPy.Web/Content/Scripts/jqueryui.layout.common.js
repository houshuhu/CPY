//class点击事件
$(function() {
    $(".menu-list-item a").click(function() {
        var a = $(this);
    });
});

//新建tab
function addTab(title, url) {
    console.log("add");
    //如果tab标签存在选中，否则创建新tab
    if ($('#tt').tabs('exists', title)) {
        $('#tt').tabs('select', title);
    } else {
        $('#tt').tabs('add', {
            title: title,
            content: addiframe(url),
            closable: true,
            tools: [
                {
                    iconCls: 'icon-mini-refresh',
                    handler: function() {
                        alert('refresh');
                    }
                }
            ]
        });
    }
}
//创建tab标签内容
function addiframe(url) {
    var iframe = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
    return iframe;
}
