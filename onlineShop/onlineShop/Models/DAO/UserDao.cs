using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onlineShop.Models.EF;
using System.Data.SqlClient;

namespace onlineShop.DAO
{
    public class UserDao
    {
        NCT_ShopDbContext db = null;
        public UserDao()
        {
            db = new NCT_ShopDbContext();
        }
        public KhachHang FindInfo(string taiK)
        {
            var kh = db.KhachHangs.Single(x => x.TenTKK == taiK);
            return kh;
        }
        public string Insert(NhanVien entity)
        {
            db.NhanViens.Add(entity);
            db.SaveChanges();
            return entity.MaNV;
        }
        public KhachHang Login(string username, string pass)
        {
            
            var result = db.KhachHangs.Where(a => a.TenTKK.Equals(username) && a.PassK.Equals(pass)).FirstOrDefault();
            KhachHang k = null;
            if (result != null)
            {
                k = new KhachHang();
                k.TenTKK = result.TenTKK;
                k.PassK = result.PassK;
                k.MaKH = result.MaKH;
            }
            return k;
        }

    }
}
