using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace HYT.NewsDemo.Models
{
    public class NewsPart : ContentPart<NewsRecord>
    {
        public virtual string NewsContent
        {
            get { return Record.NewsContent; }
            set { Record.NewsContent = value; }
        }
        public virtual string NewsTitle
        {
            get { return Record.NewsTitle; }
            set { Record.NewsTitle = value; }
        }
        public virtual int NewsCategory
        {
            get { return Record.NewsCategory; }
            set { Record.NewsCategory = value; }
        }
    }
}