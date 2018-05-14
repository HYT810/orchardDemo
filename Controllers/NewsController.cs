
using HYT.NewsDemo.Models;
using HYT.NewsDemo.Services;
using HYT.NewsDemo.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.UI.Notify;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace HYT.NewsDemo.Controllers
{
    public class NewsController : Controller, IUpdateModel
    {
        private readonly INewsService _newsService;
        private readonly IOrchardServices _orchardServices;
        private dynamic Shape { get; set; }
        public Localizer T { get; set; }

        public NewsController(INewsService newsService, IShapeFactory shapeFactory, IOrchardServices orchardServie)
        {
            _newsService = newsService;
            Shape = shapeFactory;
            _orchardServices = orchardServie;
            T = NullLocalizer.Instance;
        }
        // GET: News
        public ActionResult Index()
        {
            var newsListQuery = _newsService.GetRepoNewsList();
            //IEnumerable<dynamic> newsList = from news in newsListQuery
            //                                select Shape.News
            //                              (
            //                                  id: news.Id,
            //                                  newsTitle: news.NewsTitle,
            //                                  newsContent: news.NewsContent,
            //                                  newsCategory: news.NewsCategory
            //                              );
            //NewsListViewModel model = new NewsListViewModel(newsList);

            var newspartListQuery = _newsService.GetNewsList().List();
            IEnumerable<dynamic> newspartList = from a in newspartListQuery
                                                select Shape.News
                                                (
                                                    id: a.Id,
                                                    newsTitle: a.NewsTitle,
                                                    newsContent: a.NewsContent,
                                                    newsCategory: a.NewsCategory
                                                );
            NewsListViewModel model = new NewsListViewModel(newspartList);
            return View(model);
        }

        public ActionResult EditView(int id)
        {
            var newsQuery = _newsService.GetRepoNewsById(id);
            dynamic news = Shape.News(id: newsQuery.Id, newsTitle: newsQuery.NewsTitle, newsContent: newsQuery.NewsContent, newsCategory: newsQuery.NewsCategory);
            NewsEditViewModel model = new NewsEditViewModel(news);
            return View("EditView", model);

            //var newspart = _orchardServices.ContentManager.Get<NewsPart>(id);
            //if (newspart == null)
            //    return HttpNotFound();

            //var editModel = new NewsEditViewModel() { News = newspart };  

            //var model = _orchardServices.ContentManager.BuildEditor(newspart);
            //var editor = Shape.EditorTemplate(TemplateName: "Parts_News_Edit", Model: editModel, Prefix: null);

            //model.Content.Add(editor);

            //return View(model);

        }
        [HttpPost]
        public ActionResult Edit(string title, string content, string id)
        {
            //NewsRecord news = new NewsRecord()
            //{
            //    Id = int.Parse(id),
            //    NewsTitle = title,
            //    NewsContent = content
            //};
            //_newsService.UpdateRepoNews(news);
            //_newsService.UpdateNews(news);


            //------------------------------------------------------------------------------------------------
            var newspart = _orchardServices.ContentManager.Get<NewsPart>(int.Parse(id), VersionOptions.Latest);
            if (newspart == null)
                return HttpNotFound();

            var model = _orchardServices.ContentManager.UpdateEditor(newspart, this);
            newspart.NewsTitle = title;
            newspart.NewsContent = content;
            //var editModel = new NewsEditViewModel () { News = newspart };
            var editModel = new NewsEditViewModel(newspart);

            TryUpdateModel(editModel);

            if (!ModelState.IsValid)
            {
                _orchardServices.TransactionManager.Cancel();


                var editor = Shape.EditorTemplate(TemplateName: "Parts_News_Edit", Model: editModel, Prefix: null);

                model.Content.Add(editor);

                return View(model);
            }

            _orchardServices.ContentManager.Publish(newspart.ContentItem);
            _orchardServices.Notifier.Information(T("新闻信息修改成功"));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //_newsService.DeleteRepoNews(id);
            _newsService.DeleteNews(id);
            return RedirectToAction("Index");
        }

        public ActionResult CreateView()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(string title, string content)
        {
            NewsRecord news = new NewsRecord()
            {
                NewsTitle = title,
                NewsContent = content
            };
            _newsService.CreateNews(news);
            return RedirectToAction("Index");
        }

        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties)
        {
            throw new System.NotImplementedException();
        }

        public void AddModelError(string key, LocalizedString errorMessage)
        {
            ModelState.AddModelError(key, errorMessage.Text);
        }
    }
}