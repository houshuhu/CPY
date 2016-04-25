using System;

namespace CPy.Dto.Admin
{
    public class SysModuleSearchParam
    {
        public string ModuleName { get; set; }
    }

    public class SysModuleSearchDto
    {
        public Guid Id { get; set; }
        public string MNo { get; set; }
        public string MName { get; set; }
        public string Description { get; set; }
    }
}