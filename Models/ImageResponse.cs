using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project
{
    public class Tag2
    {
        public string en { get; set; }
    }

    public class Tag
    {
        public double confidence { get; set; }
        public Tag2 tag { get; set; }

        public Tag(Tag2 tag, double confidence)//c-tor
        {
            this.tag = tag;
            this.confidence = confidence;
        }
    }

    public class Result
    {
        public List<Tag> tags { get; set; }
    }

    public class Status
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Root
    {
        public Result result { get; set; }
        public Status status { get; set; }
    }
}
