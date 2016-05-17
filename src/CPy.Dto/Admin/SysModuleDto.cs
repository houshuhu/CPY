using System;
using System.Collections.Generic;
using CPy.RequestDto.Pagination;
using Newtonsoft.Json;

namespace CPy.Dto.Admin
{
    public class SysModuleSearchParam : Pagination
    {
        public string MName { get; set; }
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
    public class SysModuleDeleteDto
    {
        public List<Guid> List { get; set; }
    }

    public class SysModuleDictionaryList
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("text")]
        public string MName { get; set; }
        //public string MNo { get; set; }
    }
}