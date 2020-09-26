using PagedList;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class visaDAO
    {
        qlkdtrEntities db = null;
        public visaDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(decimal id, string searchString, int page, int pagesize)
        {
            IQueryable<visa> model = db.visa.Where(x => x.idtour == id);


            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.hoten.Contains(searchString));
            }
            return model.OrderBy(x => x.hoten).ToPagedList(page, pagesize);
        }

        public List<visa> LayDSVisa(decimal id)
        {
            List<visa> lst = new List<visa>();
            lst = db.visa.Where(x => x.idtour == id).ToList();
            return lst;
        }

        public visa Details(decimal id)
        {
            visa model = db.visa.Find(id);
            return model;
        }

        //public List<visa> GetDSThongtintour(decimal id)
        //{
        //    List<thongtintour> model = db.thongtintour.Where(x => x.idtour == id).ToList();
        //    List<vie_tttour> vie = new List<vie_tttour>();
        //    foreach (thongtintour t in model)
        //    {
        //        vie_tttour v = new vie_tttour();
        //        v.id_nd = t.id_nd;
        //        v.idtour = t.idtour;
        //        v.noidungtin = t.noidungtin;
        //        v.ngaytao = t.ngaytao;
        //        v.nguoitao = t.nguoitao;
        //        v.nguoisua = t.nguoisua;
        //        v.ngaysua = t.ngaysua;
        //        v.loaitin = t.loaitin;

        //        try
        //        {
        //            users usr = db.users.Where(x => x.userId == t.nguoitao).SingleOrDefault();
        //            v.username = usr.username;
        //        }
        //        catch
        //        {
        //            v.username = "";
        //        }


        //        vie.Add(v);
        //    }
        //    return vie;
        //}

        public string Update(visa model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.visa_id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(visa model)
        {
            try
            {
                db.visa.Add(model);
                db.SaveChanges();
                return model.visa_id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(decimal id)
        {
            visa co = db.visa.Find(id);
            db.visa.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }
    }
}
