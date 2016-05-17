using System.Collections.Generic;

namespace CPy.Common.ToolStrip
{
    public class ToolBar
    {
        /// <summary>
        /// 工具栏Id
        /// </summary>
        public string ToolBarId { get; set; }

        /// <summary>
        /// 是有重置按钮
        /// </summary>
        public bool IsEnableReset { get; set; }

        /// <summary>
        /// 功能模块（添加、删除）
        /// </summary>
        public List<FunctionModule> FunctionModules { get; set; }

        /// <summary>
        /// 查询模块（查询）
        /// </summary>
        public List<SearchModule> SearchModules { get; set; }
    }

    public class FunctionModule
    {
        public string Id { get; set; }
        public bool IsEnable { get; set; }
    }

    public class SearchModule
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public SearchControlType ControlType { get; set; }
    }

    public enum SearchControlType
    {
        /// <summary>
        /// 输入框
        /// </summary>
        Text=1,

        /// <summary>
        /// 下拉框
        /// </summary>
        ComboBox,

        /// <summary>
        /// 日期控件
        /// </summary>
        DateBox,
    }
}