using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGiaySneaker.Models;

namespace WebsiteBanGiaySneaker.Areas.Admin.Controllers
{
    public class WelcomeController : BaseController
    {
        WebsiteBanGiaySneakerEntities db = new WebsiteBanGiaySneakerEntities();
        // GET: Admin/ThongKe
        public ActionResult Index(DateTime? NgayA, DateTime? NgayB)
        {
            //Tính tổng doanh thu
            TempData["TongDoanhThu"] = db.DONHANGs.Where(n => n.TinhTrang == "Đã duyệt" && n.NgayGiao.ToString() != "").Sum(n => n.TongTien);

            //Đếm đơn hàng chưa duyệt
            TempData["DonHangChuaDuyet"] = db.DONHANGs.Where(n => n.TinhTrang == "Chưa duyệt").Count();

            //Đếm đơn hàng chờ giao
            TempData["DonHangChoGiao"] = db.DONHANGs.Where(n => n.TinhTrang == "Đã duyệt" && n.NgayGiao.ToString() == "").Count();

            //Đếm số khách hàng
            TempData["TongKhachHang"] = db.KHACHHANGs.Count();
            return View(db.DONHANGs.Where(n => n.NgayDat >= NgayA && n.NgayDat < NgayB && n.TinhTrang == "Đã duyệt").ToList());
        }
    }
}