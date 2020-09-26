using PagedList;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class dichvuDAO
    {
        qlkdtrEntities db = null;
        public dichvuDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(string searchString, int page, int pagesize)
        {
            IQueryable<dichvu> model = db.dichvu;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.tendv.Contains(searchString));
            }
            return model.OrderBy(x => x.tendv).ToPagedList(page, pagesize);
        }
        public List<dichvu> GetAllDichvu()
        {
            List<dichvu> model = db.dichvu.ToList();
            return model;
        }
        public List<dichvu> GetDSDichVu(string sgtcode)
        {
            List<dichvu> model = db.dichvu.Where(x => x.tendv == sgtcode).ToList();
            return model;
        }
        public dichvu DichvuDetails(decimal id)
        {
            dichvu model = db.dichvu.Find(id);
            return model;
        }

        public string XoaDichVu(decimal id)
        {
            dichvu co = db.dichvu.Find(id);
            db.dichvu.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string EditDichvu(dichvu model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.iddv.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertDV(dichvu model)
        {
            try
            {
                db.dichvu.Add(model);
                db.SaveChanges();
                return model.iddv.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dichvu Details(int id)
        {
            dichvu model = db.dichvu.Find(id);
            return model;
        }


        public string Update(dichvu model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.iddv.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(dichvu model)
        {
            try
            {
                db.dichvu.Add(model);
                db.SaveChanges();
                return model.iddv.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(decimal id)
        {
            dichvu co = db.dichvu.Find(id);
            db.dichvu.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }
    }
}
