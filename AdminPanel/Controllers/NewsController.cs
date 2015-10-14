using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Parse;
using AdminPanel.Models;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditNews(string id)
        {
           
            ParseQuery<ParseObject> query = ParseObject.GetQuery("News");
            ParseObject news = await query.GetAsync(id);

            News n = new News();
            n.NewsId = news.ObjectId;

            n.title = news.Get<string>("title");
            n.content = news.Get<string>("content");
            
            return View(n);
        }


        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> EditNews(string id, News fc)
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("News");
            ParseObject news = await query.GetAsync(id);

            news["title"] = fc.title;
            news["content"] = fc.content;

            await news.SaveAsync();

            return RedirectToAction("ShowNews");
        }

        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> AddNews(News fc)
        {
            ParseObject newsObj = new ParseObject("News");
            newsObj["title"] = fc.title;
            newsObj["content"] = fc.content;

            await newsObj.SaveAsync();

            return RedirectToAction("ShowNews");
        }

        public async Task<ActionResult> DeleteNews(string id)
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("News");
            ParseObject news = await query.GetAsync(id);

            await news.DeleteAsync();
            return RedirectToAction("ShowNews");
        }

        public async Task<ActionResult> ShowNews()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("News");
            IEnumerable<ParseObject> _news = await query.FindAsync();

            List<News> _newsList = new List<News>();

            foreach (ParseObject n in _news)
            {
                News news = new News();
                news.NewsId = n.ObjectId;
                news.title = n.Get<string>("title");
                news.content = n.Get<string>("content");
                _newsList.Add(news);
            }

            return View(_newsList);
        }
    }
}