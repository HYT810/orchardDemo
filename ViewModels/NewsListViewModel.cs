using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYT.NewsDemo.ViewModels
{
    public class NewsListViewModel
    {
        public IList<dynamic> NewsList { get; set; }
        public dynamic Pager { get; set; }

        public NewsListViewModel(IEnumerable<dynamic> newsList)
        {
            NewsList = newsList.ToList();
        }

        public NewsListViewModel(IEnumerable<dynamic> newsList, dynamic pager)
        {
            NewsList = newsList.ToList();
            Pager = pager;
        }
    }
}