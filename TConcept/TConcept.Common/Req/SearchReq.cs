using System;
using System.Collections.Generic;
using System.Text;

namespace TConcept.Common.Req
{
    public class SearchReq
    {
        public int Page { set; get; }
        public int Size { set; get; }
        public int Id { set; get; }
        public string Type { set; get; }
        public string Keyword { set; get; }
        public string Date { set; get; }
    }
}
