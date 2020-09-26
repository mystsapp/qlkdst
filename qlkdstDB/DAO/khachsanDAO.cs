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
    public class khachsanDAO
    {
        qlkdtrEntities db = null;
        public khachsanDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(string searchString, int page, int pagesize)
        {
            IQueryable<khachsan> model = db.khachsan;


            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.tenks.Contains(searchString));
            }
            return model.OrderBy(x => x.tenks).ToPagedList(page, pagesize);
        }



        public khachsan Details(decimal id)
        {
            khachsan model = db.khachsan.Find(id);
            return model;
        }

        public List<khachsan> LayDSKhachsan(decimal id)//idtour
        {
            List<khachsan> model = db.khachsan.Where(x => x.idtour == id).ToList();            
            return model;
        }

       
        public string Update(khachsan model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.maks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(khachsan model)
        {
            try
            {
                db.khachsan.Add(model);
                db.SaveChanges();
                return model.maks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(decimal id)
        {
            khachsan co = db.khachsan.Find(id);
            db.khachsan.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }
    }
}
