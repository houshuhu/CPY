using System;
using System.Collections.Generic;
using CPy.RequestDto.Pagination;

namespace CPy.Dto.Admin
{
    public class SysModuleSearchParam : Pagination
    {
        public string ModuleName { get; set; }
        public List<Guid> Ids { get; set; }
    }

    public class SysModuleSearchDto
    {
        public Guid Id { get; set; }
        public string MNo { get; set; }
        public string MName { get; set; }
        public string Description { get; set; }
    }

    public class SysModuleSaveParam
    {
        public Guid Id { get; set; }
        public string MNo { get; set; }
        public string MName { get; set; }
        public string Description { get; set; }
    }
}