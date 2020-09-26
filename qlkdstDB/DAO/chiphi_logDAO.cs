using PagedList;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class chiphi_logDAO
    {
        qlkdtrEntities db = null;
        public chiphi_logDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(string searchString, int page, int pagesize)
        {
            IQueryable<chiphi_log> model = db.chiphi_log;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }
            return model.OrderBy(x => x.sgtcode).ToPagedList(page, pagesize);
        }

        public List<chiphi_log> GetDSCPLog(string sgtcode)
        {
            List<chiphi_log> model = db.chiphi_log.Where(x => x.sgtcode == sgtcode).ToList();
            return model;
        }
        public chiphi_log CPLogDetails(decimal id)
        {
            chiphi_log model = db.chiphi_log.Find(id);
            return model;
        }

        public string XoaCPLog(decimal id)
        {
            chiphi_log co = db.chiphi_log.Find(id);
            db.chiphi_log.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string EditCPLog(chiphi_log model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertCPLog(chiphi_log model)
        {
            try
            {
                db.chiphi_log.Add(model);
                db.SaveChanges();
                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public chiphi_log Details(int id)
        {
            chiphi_log model = db.chiphi_log.Find(id);
            return model;
        }


        public string Update(chiphi_log model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(chiphi_log model)
        {
            try
            {
                db.chiphi_log.Add(model);
                db.SaveChanges();
                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(decimal id)
        {
            chiphi_log co = db.chiphi_log.Find(id);
            db.chiphi_log.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }
    }
}
