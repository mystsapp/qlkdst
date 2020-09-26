using PagedList;
using qlkdstDB.Data.ViewModel;
using qlkdstDB.EF;
using qlkdstDB.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class huongdanDAO
    {
        qlkdtrEntities db = null;
        public huongdanDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(string searchString, int page, int pagesize)
        {
            IQueryable<dmhuongdan> model = db.dmhuongdan;


            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.tenhd.Contains(searchString));
            }
            return model.OrderBy(x => x.tenhd).ToPagedList(page, pagesize);
        }

       

        public dmhuongdan Details(string id)
        {
            dmhuongdan model = db.dmhuongdan.Find(id);
            return model;
        }

        public List<huongdanViewModal> LayDSHuongDan(decimal id)//idtour
        {
            List<dmhuongdan> model = db.dmhuongdan.Where(x => x.idtour == id).ToList();
            List<huongdanViewModal> vie = new List<huongdanViewModal>();
            foreach (dmhuongdan t in model)
            {
                huongdanViewModal v = new huongdanViewModal();
                v.idtour = t.idtour;
                v.mahd = t.mahd;
                v.chinhanh = t.chinhanh;
                v.tenhd = t.tenhd;
                v.phai = t.phai;
                v.ngaysinh = t.ngaysinh;
                v.dienthoaidd = t.dienthoaidd;
                v.hochieu = t.hochieu;
                v.hieuluchc = t.hieuluchc;
             
                vie.Add(v);
            }
            return vie;
        }

        public string lastCode()//ma hop dong
        {
            string sRes = "";            
            //dinh dang :0001                  

            try
            {
                var hd = db.dmhuongdan.OrderByDescending(x => x.mahd).Take(1).SingleOrDefault().mahd;
                sRes = hd;
                return sRes;

            }
            catch
            {
                return "";
            }           
        }

     
        public string newCode()
        {
            GenerateId newId = new GenerateId();
            return newId.NextId(lastCode(), "", "0001");
        }

        public string Update(dmhuongdan model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.mahd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(dmhuongdan model)
        {
            try
            {
                db.dmhuongdan.Add(model);
                db.SaveChanges();
                return model.mahd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(string id)
        {
            dmhuongdan co = db.dmhuongdan.Find(id);
            db.dmhuongdan.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }
    
    }
}
