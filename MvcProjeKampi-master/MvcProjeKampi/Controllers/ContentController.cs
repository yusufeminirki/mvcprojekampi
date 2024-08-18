﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context context = new Context();

        public ActionResult Index()
        {
            var values = cm.TGetList();
            ViewBag.Sayi = values.Count();
            return View(values);
        }

        public ActionResult GetAllContent(string p)
        {

            if (!string.IsNullOrEmpty(p))
            {
                var values = cm.GetList(p);
                return View(values);
            }
            else
            {
                var values = cm.GetList("");
                return View(values);
            }
        }

        public ActionResult ContentByHeading(int id)
        {
            var ContentValues = cm.GetListByHeadingID(id);
            ViewBag.ID = id;
            ViewBag.BA = context.Headings.Where(x => x.HeadingID == id).Select(y => y.HeadingName).FirstOrDefault();
            ViewBag.Sayi = ContentValues.Count();
            return View(ContentValues);
        }
    }
}