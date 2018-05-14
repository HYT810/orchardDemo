using System.Collections.Generic;
using System.Linq;
using Orchard.ContentManagement;
using Orchard;
using Orchard.Data;
using HYT.NewsDemo.Models;

namespace HYT.NewsDemo.Services
{
    public class NewsService : INewsService
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IRepository<NewsRecord> _newsRepository;
        private readonly IContentManager _contentManager;
        public NewsService(IOrchardServices orchardService, IRepository<NewsRecord> newsRepository, IContentManager contentManager)
        {
            _orchardServices = orchardService;
            _newsRepository = newsRepository;
            _contentManager = contentManager;
        }

        #region 查询
        public IContentQuery<NewsPart> GetNewsList()
        {
            return _orchardServices.ContentManager.Query<NewsPart, NewsRecord>();
        }

        public NewsPart GetNews(int id)
        {
            return _contentManager.Get<NewsPart>(id, VersionOptions.Latest);
        }

        public List<NewsRecord> GetRepoNewsList()
        {
            return _newsRepository.Table.ToList();
        }


        public NewsRecord GetRepoNewsById(int id)
        {
            return _newsRepository.Get(id);
        }
        #endregion

        #region 新增
        public NewsPart CreateNews(NewsRecord newsRecord)
        {
            var newpart = _orchardServices.ContentManager.New<NewsPart>("News");
            newpart.Record = newsRecord;
            _contentManager.Create(newpart, VersionOptions.Published);
            return newpart;
        }

        public void CreateRepoNews(NewsRecord newsRecord)
        {
            _newsRepository.Create(newsRecord);
        }
        #endregion

        #region 修改
        public void UpdateNews(NewsRecord news)
        {
            
        }

        public void UpdateRepoNews(NewsRecord news)
        {
            NewsRecord oldNews = _newsRepository.Get(news.Id);
            oldNews.NewsTitle = news.NewsTitle;
            oldNews.NewsContent = news.NewsContent;
            oldNews.NewsCategory = news.NewsCategory;
            _newsRepository.Update(oldNews);
        }
        #endregion

        #region 删除
        public void DeleteNews(int id)
        {
            var newspart = GetNews(id);
            if (newspart == null)
            {
                return;
            }
            _orchardServices.ContentManager.Remove(newspart.ContentItem);
        }

        public void DeleteRepoNews(int id)
        {
            _newsRepository.Delete(_newsRepository.Get(id));
        }


        #endregion



    }
}