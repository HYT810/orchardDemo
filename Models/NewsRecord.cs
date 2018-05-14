using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace HYT.NewsDemo.Models
{
    public class NewsRecord : ContentPartRecord
    {
        public virtual string NewsContent { get; set; }
        public virtual string NewsTitle { get; set; }
        public virtual int NewsCategory { get; set; }

    }
}