using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MyController : Controller
    {
        private readonly IHttpContext context;

        public MyController(IHttpContext context)
        {
            this.context = context;
        }

        public MyController()
        {
            context = new ContextWrapper(this.HttpContext);
        }

        // GET: My
        public ActionResult Index()
        {
            var foo = context.Request["Foo"];
            ViewData["foo"] = foo;
            return View();

        }
    }

    public class ContextWrapper : IHttpContext
    {
        private readonly HttpContextBase httpContext;

        public ContextWrapper(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public Cache Cache
        {
            get { return httpContext.Cache; }
        }

        public HttpRequestBase Request
        {
            get { return httpContext.Request; }
        }
    }


    public abstract class IHttpContext
    {
        public virtual Cache Cache { get; set; }
        public virtual HttpRequestBase Request { get; set; }
    }
}