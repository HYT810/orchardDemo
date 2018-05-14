using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HYT.NewsDemo.Models;
namespace HYT.NewsDemo.Handlers
{
    public class NewsHandler : ContentHandler
    {
        public NewsHandler(IRepository<NewsRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<NewsPart>("News"));

            // OnRemove事件 当发生remove时进行彻底删除
            OnRemoved<NewsPart>((context, clue) => repository.Delete(clue.Record));
        }
    }
}