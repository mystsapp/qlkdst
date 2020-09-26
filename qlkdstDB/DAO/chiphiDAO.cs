using PagedList;
using qlkdstDB.Data.ViewModel;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class chiphiDAO
    {
        qlkdtrEntities db = null;
        public chiphiDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(string searchString, int page, int pagesize)
        {
            IQueryable<chiphi> model = db.chiphi;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }
            return model.OrderBy(x => x.sgtcode).ToPagedList(page, pagesize);
        }

        public List<doitaccpViewModal> GetDSCP(decimal idtour)
        {
            List<doitaccpViewModal> model = new List<doitaccpViewModal>();
            List<chiphi> lst = db.chiphi.Where(x => x.idtour == idtour).ToList();
            foreach(chiphi cp in lst)
            {
                doitaccpViewModal vm = new doitaccpViewModal();
                vm.Id = cp.Id;
                vm.idtour = idtour;
                vm.sgtcode = cp.sgtcode;
                vm.mancc = cp.mancc;
                vm.tenncc = cp.tenncc;
                vm.iddv = cp.iddv;
                vm.tienmat = cp.tienmat;
                vm.ngoaite = cp.ngoaite;
                vm.loaitien = cp.loaitien;
                vm.tigia = cp.tigia;
                vm.tienvnd = cp.tienvnd;
                vm.sokhach = cp.sokhach;
                vm.noidung = cp.noidung;
                vm.ghichu = cp.ghichu;
                vm.nguoinhap = cp.nguoinhap;
                vm.ngaynhap = cp.ngaynhap;
                vm.computer = cp.computer;
                vm.del = false;
                vm.tenfileinvoice = cp.tenfileinvoice;
                vm.log_file = cp.log_file;

                try
                {
                    vm.tendv = db.dichvu.Where(x => x.iddv == cp.iddv).SingleOrDefault().tendv;
                

                }
                catch
                {
                    vm.tendv = "";
                     
                }


                vm.nguoinhap = cp.nguoinhap;
                vm.ngaynhap = cp.ngaynhap;
                model.Add(vm);
            }

            return model;
        }
        public chiphi CPDetails(decimal id)
        {
            chiphi model = db.chiphi.Find(id);
            return model;
        }

        public string XoaCP(decimal id)
        {
            chiphi co = db.chiphi.Find(id);
            db.chiphi.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string EditCP(chiphi model)
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

        public string InsertCP(chiphi model)
        {
            try
            {
                db.chiphi.Add(model);
                db.SaveChanges();
                return model.Id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public chiphi Details(decimal id)
        {
            chiphi model = db.chiphi.Find(id);
            return model;
        }


        public string Update(chiphi model)
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

        public string Insert(chiphi model)
        {
            try
            {
                db.chiphi.Add(model);
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
            chiphi co = db.chiphi.Find(id);
            db.chiphi.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string UpdateAnDel(decimal id, string log, string user, DateTime ngayxoa)
        {
            chiphi model = db.chiphi.Find(id);
            model.ngaynhap = ngayxoa;
            model.nguoinhap = user;
            model.log_file = model.log_file + log;
            //update
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            //delete
            db.Entry(model).State = EntityState.Deleted;
            db.chiphi.Remove(model);
            db.SaveChanges();
            return id.ToString();
        }
    }
}
