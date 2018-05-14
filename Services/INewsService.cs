using System.Collections.Generic;
using Orchard;
using Orchard.ContentManagement;
using HYT.NewsDemo.Models;

namespace HYT.NewsDemo.Services
{
    public interface INewsService : IDependency
    {
        IContentQuery<NewsPart> GetNewsList();
        NewsPart GetNews(int id);
        NewsPart CreateNews(NewsRecord news);
        void UpdateNews(NewsRecord news);
        void DeleteNews(int id);


        List<NewsRecord> GetRepoNewsList();
        NewsRecord GetRepoNewsById(int id);
        void UpdateRepoNews(NewsRecord news);
        void DeleteRepoNews(int id);
        void CreateRepoNews(NewsRecord news);
    }
}
