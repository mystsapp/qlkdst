using PagedList;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class tourleoblogDAO
    {
        qlkdtrEntities db = null;
        public tourleoblogDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(string searchString, int page, int pagesize)
        {
            IQueryable<tourleoblog> model = db.tourleoblog;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }
            

            //return model.OrderByDescending(x => x.ngaytao).ThenBy(x => x.tenquan).ToPagedList(page, pagesize);
            return model.OrderBy(x => x.batdau).ToPagedList(page, pagesize);
        }

      
        public tourleoblog Details(decimal id)
        {
            tourleoblog model = db.tourleoblog.Find(id);
            return model;
        }

        public string Update(tourleoblog model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.idlog.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(tourleoblog model)
        {
            try
            {
                db.tourleoblog.Add(model);
                db.SaveChanges();
                return model.idlog.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string Delete(decimal id)
        {
            tourleoblog co = db.tourleoblog.Find(id);
            db.tourleoblog.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

    }
}
