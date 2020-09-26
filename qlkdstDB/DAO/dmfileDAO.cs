using PagedList;
using qlkdstDB.Data.ViewModel;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class dmfileDAO
    {
        qlkdtrEntities db = null;
        public dmfileDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(string searchString, int page, int pagesize)
        {
            IQueryable<dmfile> model = db.dmfile;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.tenfile.Contains(searchString));
            }
            return model.OrderBy(x => x.tenfile).ToPagedList(page, pagesize);
        }

        public List<dmfileViewModal> LayDSDmFile(decimal idtour,string loaifile)
        {
            List<dmfileViewModal> model = new List<dmfileViewModal>();
            List<dmfile> lst = db.dmfile.Where(x => x.idtour == idtour && x.loaifile==loaifile).ToList();
            foreach (dmfile cp in lst)
            {
                dmfileViewModal vm = new dmfileViewModal();
                vm.file_id = cp.file_id;
                vm.loaifile = cp.loaifile;
                vm.tenfile = cp.tenfile;
                vm.idtour = cp.idtour;
                vm.nguoitao = cp.nguoitao;
                vm.ngaytao = cp.ngaytao;
                vm.log_file = cp.log_file;
                model.Add(vm);
            }

            return model;
        }
        public dmfile CPDetails(decimal id)
        {
            dmfile model = db.dmfile.Find(id);
            return model;
        }       

        public dmfile Details(decimal id)
        {
            dmfile model = db.dmfile.Find(id);
            return model;
        }


        public string Update(dmfile model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.file_id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(dmfile model)
        {
            try
            {
                db.dmfile.Add(model);
                db.SaveChanges();
                return model.file_id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(decimal id)
        {
            dmfile co = db.dmfile.Find(id);
            db.dmfile.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string UpdateAnDel(decimal id, string log, string user, DateTime ngayxoa)
        {
            dmfile model = db.dmfile.Find(id);
            model.ngaytao = ngayxoa;
            model.nguoitao = user;
            model.log_file = model.log_file + log;
            //update
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            //delete
            db.Entry(model).State = EntityState.Deleted;
            db.dmfile.Remove(model);
            db.SaveChanges();
            return id.ToString();
        }
    }
}
