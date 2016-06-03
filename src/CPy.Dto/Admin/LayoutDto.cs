using System.Collections.Generic;

namespace CPy.Dto.Admin
{
    public class LayoutResponseDto
    {
        public string MNo { get; set; }
        public string MName { get; set; }
        public List<FunctionData> SysFunctions { get; set; }
        public class FunctionData
        {
            public string FNo { get; set; }
            public string FName { get; set; }
            public string FUrl { get; set; }
        }
    }
}