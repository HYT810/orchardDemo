using HYT.NewsDemo.Models;
using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYT.NewsDemo.ViewModels
{
    public class NewsEditViewModel
    {
        public dynamic News { get; set; }
        public dynamic Pager { get; set; }

        public NewsEditViewModel(dynamic news)
        {
            News = news;
        }
        public NewsEditViewModel(dynamic news, dynamic pager)
        {
            News = news;
            Pager = pager;
        }
        //public int Id
        //{
        //    get { return News.As<NewsPart>().Id; }

        //}
        //public string NewsTitle
        //{
        //    get { return News.As<NewsPart>().NewsTitle; }
        //    set { News.As<NewsPart>().NewsTitle = value; }
        //}
        //public string NewsContent
        //{
        //    get { return News.As<NewsPart>().NewsContent; }
        //    set { News.As<NewsPart>().NewsContent = value; }
        //}

        //public IContent News;
    }
}