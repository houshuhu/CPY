﻿var HandleDate = {
    //加载DataGrid
    //dataGridId--表格Id,title--表格标题,toolbar--表格工具栏,url---请求地址,idField---标识列
    InitDataGrid: function(dataGridId, title, toolbar, url, idField, singleSelect, onClickRow, onDblClickRow) {
        $('#' + dataGridId).datagrid({
            title: title, //标题
            iconCls: 'icon-save', //图标
            fitColumns: true,
            toolbar: toolbar,
            nowrap: false,
            striped: true,
            border: true,
            collapsible: true, //是否可折叠的  
            fit: true, //自动大小  
            url: url, //请求地址
            idField: idField, //标识列
            singleSelect: singleSelect, //是否单选  
            loadMsg: "正在加载，请稍等...",
            pagination: true, //分页控件
            pagePosition: "bottom",
            rownumbers: true, //行号  
            frozenColumns: [
                [
                    { field: 'ck', checkbox: true }
                ]
            ],
            onLoadSuccess: function(data) {
                console.log(data);
            },
            onClickRow: onClickRow,
            onDblClickRow: onDblClickRow
        });
        //设置分页控件  
        var p = $('#' + dataGridId).datagrid('getPager');
        $(p).pagination({
            pageSize: 10, //每页显示的记录条数，默认为10  
            pageList: [5, 10, 15], //可以设置每页记录条数的列表  
            beforePageText: '第', //页数文本框前显示的汉字  
            afterPageText: '页    共 {pages} 页',
            displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录',
            buttons: [
                {
                    iconCls: 'icon-search',
                    handler: function() {
                        alert('search');
                    }
                }, {
                    iconCls: 'icon-add',
                    handler: function() {
                        alert('add');
                    }
                }, {
                    iconCls: 'icon-edit',
                    handler: function() {
                        alert('edit');
                    }
                }
            ]
        });
    },

    //删除表格行数据
    DeleteDataGrid: function (dataGridId, url) {
        var dto = {
            List:[]
        };
        var selectedrows = $('#' + dataGridId).datagrid('getChecked');
        $.each(selectedrows, function (index, value) {
            dto.List.push(value.Id);
        });
        console.log(JSON.stringify(dto));
        $.ajax({
            type: 'POST',
            url: url,
            data: JSON.stringify(dto),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data.ExceptionMessage) {
                    alert(data.ExceptionMessage);
                } else {
                    $.messager.show({
                        title: '提示',
                        msg: '删除成功！.',
                        timeout: 1000,
                        showType: 'slide'
                    });
                    $('#' + dataGridId).datagrid("load");
                    $('#' + dataGridId).datagrid("clearSelections");
                }
            },error: function(data) {
                alert('error');
            }
        });
        
    },

    //重新加载表格，但是停留在当前页
    ReLoadDataGrid: function (dataGridId) {
        $('#' + dataGridId).datagrid('reload');
    },

    //查询，远程重新加载数据
    LoadDataGrid: function (dataGridId,params) {
        $('#' + dataGridId).datagrid('load',params);
    },

    //加载form表单
    LoadForm: function(formid, url) {
        $.ajax({
            url: url,
            method: 'post',
            success: function (data) {
                console.log(data);
                $("#" + formid).form('load',data.ResultData);
            },
            errot: function(data) {
                alert('data');
            }
        });
    },

    //提交form表单
    SubmitForm: function(formid,url,successfun) {
        $('#'+formid).form('submit', {
            url: url,
            onSubmit: function () {
                var isValid = $(this).form('validate');
                if (!isValid) {
                    $.messager.alert('提示', '请填写必要信息！', 'info');
                }
                return isValid; // 返回false将停止form提交
            },
            success: successfun
        });
    }
};

var HandleUrl = {
    //获取url参数
    GetQueryString: function(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
}