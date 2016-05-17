using System;
using CPy.RequestDto.Pagination;

namespace CPy.Dto.Admin
{
    #region Search
    public class SysFunctionSearchParam : Pagination
    {
        public string FunctionName { get; set; }
        public Guid ModuleId { get; set; }
    }

    public class SysFunctionDto
    {
        public Guid Id { get; set; }
        public string FUrl { get; set; }
        public string FNo { get; set; }
        public string FName { get; set; }
        public Guid SysModuleId { get; set; }
    }
    #endregion



    #region Add

    public class SysFunctionAddParam
    {
        public Guid Id { get; set; }
        public string FUrl { get; set; }
        public string FNo { get; set; }
        public string FName { get; set; }
        public Guid SysModuleId { get; set; }
    }

    #endregion




    #region LoadDetail

    public class SysFunctionDetail
    {
        public Guid Id { get; set; }
        public string FUrl { get; set; }
        public string FNo { get; set; }
        public string FName { get; set; }
        public Guid SysModuleId { get; set; }

    }

    #endregion

}