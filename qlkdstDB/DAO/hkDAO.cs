using PagedList;
using qlkdstDB.Data.ViewModel;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class hkDAO
    {
        qlkdtrEntities db = null;
        public hkDAO()
        {
            db = new qlkdtrEntities();
        }

        public object ListAllPageList(string searchString, int page, int pagesize)
        {
            IQueryable<hangkhong> model = db.hangkhong;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }
            return model.OrderBy(x => x.sgtcode).ToPagedList(page, pagesize);
        }

        public List<hangkhongViewModal> GetDSHK(decimal idtour)
        {
            List<hangkhongViewModal> model = new List<hangkhongViewModal>();
            List<hangkhong> lst = db.hangkhong.Where(x => x.idtour == idtour).ToList();
            foreach (hangkhong cp in lst)
            {
                hangkhongViewModal vm = new hangkhongViewModal();
                vm.id = cp.id;
                vm.idtour = idtour;
                vm.tenncc = cp.tenncc;
                vm.sgtcode = cp.sgtcode;
                vm.mancc = cp.mancc;
                vm.iddv = cp.iddv;
                vm.hanhtrinh = cp.hanhtrinh;
                vm.codebooking = cp.codebooking;
                vm.loaibooking = cp.loaibooking;
                vm.chococ1 = cp.chococ1;
                vm.tiencoc1 = cp.tiencoc1;
                vm.chococ2 = cp.chococ2;
                vm.tiencoc2 = cp.tiencoc2;
                vm.chococ3 = cp.chococ3;
                vm.tiencoc3 = cp.tiencoc3;
                vm.sochoxuatve = cp.sochoxuatve;
                vm.tiencocphat = cp.tiencocphat;
                vm.tiencochoan = cp.tiencochoan;
                vm.ghichu = cp.ghichu;

                try
                {
                    vm.tendv = db.dichvu.Where(x => x.iddv == cp.iddv).SingleOrDefault().tendv;

                }
                catch
                {
                    vm.tendv = "";
                 
                }

                model.Add(vm);
            }

            return model;
        }
        public hangkhong HKDetails(decimal id)
        {
            hangkhong model = db.hangkhong.Find(id);
            return model;
        }

        public string XoaHK(decimal id)
        {
            hangkhong co = db.hangkhong.Find(id);
            db.hangkhong.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string EditHK(hangkhong model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertHK(hangkhong model)
        {
            try
            {
                db.hangkhong.Add(model);
                db.SaveChanges();
                return model.id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertHKDel(hangkhong_del model)
        {
            try
            {
                db.hangkhong_del.Add(model);
                db.SaveChanges();
                return model.id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public hangkhong Details(decimal id)
        {
            hangkhong model = db.hangkhong.Find(id);
            return model;
        }


        public string Update(hangkhong model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(hangkhong model)
        {
            try
            {
                db.hangkhong.Add(model);
                db.SaveChanges();
                return model.id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(decimal id)
        {
            hangkhong co = db.hangkhong.Find(id);
            db.hangkhong.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string UpdateAnDel(decimal id,string log,string user,DateTime ngayxoa)
        {
            hangkhong model = db.hangkhong.Find(id);
            model.ngaysua = ngayxoa;
            model.nguoisua = user;
            model.logfilehk = model.logfilehk + log;
            //update
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            //delete
            db.Entry(model).State = EntityState.Deleted;
            db.hangkhong.Remove(model);
            db.SaveChanges();
            return id.ToString();
        }
    }
}
