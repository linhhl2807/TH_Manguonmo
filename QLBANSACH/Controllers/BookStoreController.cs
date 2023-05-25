using QLBANSACH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using PagedList;
using PagedList.Mvc;

namespace QLBANSACH.Controllers
{
    public class BookStoreController : Controller
    {
        dbQLBanSachDataContext data = new dbQLBanSachDataContext();

        public dbQLBanSachDataContext Data { get => data; set => data = value; }

        // GET: BookStore
        private List<SACH> laysachmoi(int count)
        {
            return Data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }

        public ActionResult Index(int ? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var sachmoi = laysachmoi(16);
            return View(sachmoi.ToPagedList(pageNum,pageSize));
        }
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult Nhaxuatban()
        {
            var nhaxuatban = from cd in data.NHAXUATBANs select cd;
            return PartialView(nhaxuatban);
        }
        public ActionResult SPTheochude(int id)
        {
            var sach = from s  in data.SACHes where s.MaCD==id select s  ;
            return View(sach);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes 
                       where s.Masach == id 
                       select s;
            return View(sach.Single());
        }
    }
}