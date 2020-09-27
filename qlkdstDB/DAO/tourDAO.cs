using PagedList;
using qlkdstDB.Data.ViewModel;
using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace qlkdstDB.DAO
{
    public class tourDAO
    {
        qlkdtrEntities db = null;
        public tourDAO()
        {
            db = new qlkdtrEntities();
        }

        public bool KTTourTrung(string sgtcode)
        {
            bool b = false;//chua co
            int count = db.tour.Where(x => x.sgtcode == sgtcode).Count();
            b = (count > 0);
            return b;
        }


        public List<quan> GetQuan(decimal[] maquocgia)
        {
            List<quan> lst = new List<quan>();                   

            var model =from s in db.quan select s;
            if (maquocgia != null)
            {
                model = from m in model where maquocgia.Contains(m.maquocgia) select m;
            }

            lst = model.ToList();
            return lst;
        }

        public tourViewModel loadAllTourDetails(decimal id)
        {
            tourViewModel tvm = new tourViewModel();
            try
            {
                tour model = db.tour.Find(id);
                tvm.tour = model;

                tvm.tour = db.tour.Where(x => x.idtour == id).SingleOrDefault();
              //  dmkhachtour dm = new dmkhachtour();
                tvm.lstdmkhachtour = new List<dmkhachtour>();
                tvm.lstdmkhachtour = db.dmkhachtour.Where(x => x.idtour == id).ToList();

              //  datcoc dc = new datcoc();
                tvm.lstbiennhan = new List<datcoc>();
                tvm.lstbiennhan = db.datcoc.Where(x => x.idtour == id).ToList();

                //file chiettinh
                tvm.lstfilechiettinh = new List<dmfileViewModal>();
                List<dmfile> lstdmfilechiettinh = db.dmfile.Where(x => x.idtour == id && x.loaifile == "CHIETTINH").ToList();
                List<dmfileViewModal> viedmfilechietinh=new List<dmfileViewModal>();
                foreach (dmfile t in lstdmfilechiettinh)
                {
                    dmfileViewModal vm = new dmfileViewModal();
                    vm.file_id = t.file_id;
                    vm.loaifile = t.loaifile;
                    vm.tenfile = t.tenfile;
                    vm.idtour = t.idtour;
                    vm.nguoitao = t.nguoitao;
                    vm.ngaytao = t.ngaytao;
                    vm.log_file = t.log_file;

                    viedmfilechietinh.Add(vm);
                }
                tvm.lstfilechiettinh = viedmfilechietinh;

                //file hop dong
                tvm.lstfilehopdong = new List<dmfileViewModal>();
                List<dmfile> lstdmfilehopdong = db.dmfile.Where(x => x.idtour == id && x.loaifile == "HOPDONG").ToList();
                List<dmfileViewModal> viedmfilehopdong = new List<dmfileViewModal>();
                foreach (dmfile t in lstdmfilehopdong)
                {
                    dmfileViewModal vm = new dmfileViewModal();
                    vm.file_id = t.file_id;
                    vm.loaifile = t.loaifile;
                    vm.tenfile = t.tenfile;
                    vm.idtour = t.idtour;
                    vm.nguoitao = t.nguoitao;
                    vm.ngaytao = t.ngaytao;
                    vm.log_file = t.log_file;

                    viedmfilehopdong.Add(vm);
                }
                tvm.lstfilehopdong = viedmfilehopdong;

                //chuong trinh tour cua dieu hanh
                tvm.lstdmfileviewmodel = new List<dmfileViewModal>();
                List<dmfile> lstdmfile = db.dmfile.Where(x => x.idtour == id && x.loaifile== "CTTOURDH").ToList();
                List<dmfileViewModal> viedmfile = new List<dmfileViewModal>();
                foreach (dmfile t in lstdmfile)
                {
                    dmfileViewModal vm = new dmfileViewModal();
                    vm.file_id = t.file_id;
                    vm.loaifile = t.loaifile;
                    vm.tenfile = t.tenfile;
                    vm.idtour = t.idtour;
                    vm.nguoitao = t.nguoitao;
                    vm.ngaytao = t.ngaytao;
                    vm.log_file = t.log_file;

                    viedmfile.Add(vm);
                }
                tvm.lstdmfileviewmodel = viedmfile;

                //thong tin
                tvm.lstdsthongtin = new List<vie_tttour>();
                List<thongtintour> lstttour = db.thongtintour.Where(x => x.idtour == id).ToList();
                List<vie_tttour> vie = new List<vie_tttour>();
                foreach (thongtintour t in lstttour)
                {
                    vie_tttour v = new vie_tttour();
                    v.id_nd = t.id_nd;
                    v.idtour = t.idtour;
                    v.noidungtin = t.noidungtin;
                    v.ngaytao = t.ngaytao;
                    v.nguoitao = t.nguoitao;
                    v.nguoisua = t.nguoisua;
                    v.ngaysua = t.ngaysua;
                    v.loaitin = t.loaitin;

                    try
                    {
                        users usr = db.users.Where(x => x.userId == t.nguoitao).SingleOrDefault();
                        v.username = usr.username;
                    }
                    catch
                    {
                        v.username = "";
                    }


                    vie.Add(v);
                }
                tvm.lstdsthongtin = vie;

                //doi tac chi phi
                tvm.lstdoitacCP = new List<doitaccpViewModal>();
                List<chiphi> lstcp = db.chiphi.Where(x => x.idtour == model.idtour).ToList();
                List<doitaccpViewModal> lstdoitaccp = new List<doitaccpViewModal>();
                foreach (chiphi t in lstcp)
                {
                    doitaccpViewModal dmchiphi = new doitaccpViewModal();
                    dmchiphi.Id = t.Id;
                    dmchiphi.idtour = id;
                    dmchiphi.sgtcode = t.sgtcode;
                    dmchiphi.mancc = t.mancc;
                    dmchiphi.tenncc = t.tenncc;
                    dmchiphi.iddv = t.iddv;
                    dmchiphi.tienmat = t.tienmat;
                    dmchiphi.ngoaite = t.ngoaite;
                    dmchiphi.loaitien = t.loaitien;
                    dmchiphi.tigia = t.tigia;
                    dmchiphi.tienvnd = t.tienvnd;
                    dmchiphi.sokhach = t.sokhach;
                    dmchiphi.noidung = t.noidung;
                    dmchiphi.ghichu = t.ghichu;
                    dmchiphi.nguoinhap = t.nguoinhap;
                    dmchiphi.ngaynhap = t.ngaynhap;
                    dmchiphi.computer = t.computer;
                    dmchiphi.del = false;
                    dmchiphi.tenfileinvoice = t.tenfileinvoice;
                    dmchiphi.computer = t.computer;
                    dmchiphi.nguoinhap = t.nguoinhap;
                    dmchiphi.log_file = t.log_file;

                    lstdoitaccp.Add(dmchiphi);
                }
                tvm.lstdoitacCP = lstdoitaccp;

                //HANG KHONG          
                tvm.lsthkviewmodel = new List<hangkhongViewModal>();
                List<hangkhong> lsthk = db.hangkhong.Where(x => x.idtour == id).ToList();
                List<hangkhongViewModal> lsthkvm = new List<hangkhongViewModal>();
                foreach (hangkhong t in lsthk)
                {
                    hangkhongViewModal hk = new hangkhongViewModal();
                    hk.idtour = id;
                    hk.id = t.id;
                    hk.tenncc = t.tenncc;
                    hk.sgtcode = t.sgtcode;
                    hk.mancc = t.mancc;
                    hk.iddv = t.iddv;
                    hk.hanhtrinh = t.hanhtrinh;
                    hk.codebooking = t.codebooking;
                    hk.loaibooking = t.loaibooking;
                    hk.chococ1 = t.chococ1;
                    hk.tiencoc1 = t.tiencoc1;
                    hk.chococ2 = t.chococ2;
                    hk.tiencoc2 = t.tiencoc2;
                    hk.chococ3 = t.chococ3;
                    hk.tiencoc3 = t.tiencoc3;
                    hk.sochoxuatve = t.sochoxuatve;
                    hk.tiencocphat = t.tiencocphat;
                    hk.tiencochoan = t.tiencochoan;
                    hk.ghichu = t.ghichu;

                    try
                    {
                        hk.tendv = db.dichvu.Where(x => x.iddv == t.iddv).SingleOrDefault().tendv;
       
                    }
                    catch
                    {
                        hk.tendv = "";
                       
                    }

                    lsthkvm.Add(hk);
                }
                tvm.lsthkviewmodel = lsthkvm;
                //END HANG KHONG

                //VISA
                tvm.lstvisa = new List<visa>();
                tvm.lstvisa = db.visa.Where(x=>x.idtour==model.idtour).ToList();

                //END VISA

                //KHACH SAN
                tvm.lstks = new List<khachsan>();
                tvm.lstks = db.khachsan.Where(x => x.idtour == model.idtour).ToList();

                //END KHACH SAN

                //Huong dan
                tvm.lsthdviewmodel = new List<huongdanViewModal>();
                List<dmhuongdan> lsthd = db.dmhuongdan.Where(x => x.idtour == model.idtour).ToList();
                List<huongdanViewModal> lsthdvm = new List<huongdanViewModal>();
                foreach(dmhuongdan t in lsthd)
                {
                    huongdanViewModal v = new huongdanViewModal();
                    v.mahd = t.mahd;
                    v.idtour = t.idtour;
                    v.chinhanh = t.chinhanh;
                    v.SgtCode = t.SgtCode;
                    v.tenhd = t.tenhd;
                    v.phai = t.phai;
                    v.ngaysinh = t.ngaysinh;
                    v.dienthoaidd = t.dienthoaidd;
                    v.hochieu = t.hochieu;
                    v.hieuluchc = t.hieuluchc;
                    lsthdvm.Add(v);
                }
                tvm.lsthdviewmodel = lsthdvm;
                //End Huong dan



            }
            catch { }            

            return tvm;
        }


        public object ListAllPageList(string searchString, DateTime d1, DateTime d2, string tencongty, string sohopdong, string sChiNhanh, string sDaily, users usr, string salenm, string tuyentq, string[] sCongTyPre, int page, int pagesize)
        {

            IQueryable<tour> model = db.tour;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }

            if (d1 != null && d2 != null)
            {
                model = model.Where(x => x.batdau != null && DbFunctions.TruncateTime(x.batdau.Value) >= DbFunctions.TruncateTime(d1) && DbFunctions.TruncateTime(x.batdau.Value) <= DbFunctions.TruncateTime(d2));
            }

            if (!String.IsNullOrEmpty(tencongty))
            {
                model = model.Where(x => x.tenkh.Contains(tencongty));
            }

            if (!String.IsNullOrEmpty(sohopdong))
            {
                model = model.Where(x => x.sohopdong.Contains(sohopdong));
            }

            if (!String.IsNullOrEmpty(tuyentq))
            {
                model = model.Where(x => x.tuyentq.Contains(tuyentq));
            }

            if (!String.IsNullOrEmpty(salenm))
            {
                model = model.Where(x => x.nguoitao.Contains(salenm));
            }


            if (sCongTyPre.Length > 0 && usr.role != "admin" && usr.role != "superadmin") //user co quyen theo vung mien
            {
                model = model.Where(x => sCongTyPre.Contains(x.chinhanh) || x.chinhanh == usr.chinhanh);
                //model = model.Where(x => new[] { "STA","STT","STC" }.Contains(x.chinhanh));
            }
            else
            {
                if (!String.IsNullOrEmpty(sChiNhanh) && usr.role != "admin" && usr.role != "superadmin")
                {
                    model = model.Where(x => x.chinhanh == sChiNhanh);
                }

                // if (usr.role == "salemanager") //chi thay code cua chi nhanh minh
                //05/06/2020 them quyen dieuhanh nhung chỉ để xài phần điều hành
                if (usr.role == "salemanager" || usr.role.ToLower() == "cashier" || usr.role.ToLower() == "dieuhanh")//them quyen cashier nhung chi cho xem
                {
                    model = model.Where(x => x.chinhanh == usr.chinhanh);

                }
                //15/05 tam thoi bo dieu kien nay
                //19/5 mo lai, sale chi thay doan cua minh
                if (usr != null && usr.role != "admin" && usr.role != "superadmin" && usr.role != "salemanager" && usr.role.ToLower() != "cashier" && usr.role.ToLower() != "dieuhanh") //user chi thay du lieu do minh tao tru user admin hay superadmin, salemanager, cashier(chi xem)
                {
                    model = model.Where(x => x.nguoitao == usr.username || x.nguoitao.Contains(usr.fullName) || x.nguoisua == usr.username || x.nguoisua.Contains(usr.fullName));
                }
            }




            return model.OrderBy(x => x.batdau).ThenBy(x => x.ngaytao).ToPagedList(page, pagesize);
        }



        public object ListAllPageList(string searchString,DateTime d1,DateTime d2,string tencongty,string sohopdong,string sChiNhanh,string sDaily,users usr, int page, int pagesize)
        {
            IQueryable<tour> model = db.tour;            

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }

            if (d1 != null && d2 != null)
            {
                model = model.Where(x => x.batdau != null && DbFunctions.TruncateTime(x.batdau.Value) >= DbFunctions.TruncateTime(d1) && DbFunctions.TruncateTime(x.batdau.Value) <= DbFunctions.TruncateTime(d2));
            }

            if (!String.IsNullOrEmpty(tencongty))
            {
                model = model.Where(x => x.tenkh.Contains(tencongty));
            }

            if (!String.IsNullOrEmpty(sohopdong))
            {
                model = model.Where(x => x.sohopdong.Contains(sohopdong));
            }

            if (!String.IsNullOrEmpty(sChiNhanh) && usr.role != "admin" && usr.role != "superadmin")
            {
                model = model.Where(x => x.chinhanh == sChiNhanh);
            }

           
            //15/05: tam cho phep sales thay toan bo code cua chi nhanh
            if (usr.role == "salemanager") //chi thay code cua chi nhanh minh
            {
                model = model.Where(x => x.chinhanh == usr.chinhanh);

            }
            //15/05 tam thoi bo dieu kien nay
            //16/5 mo lai, sale chi thay doan cua minh
            if (usr != null && usr.role != "admin" && usr.role != "superadmin" && usr.role != "salemanager") //user chi thay du lieu do minh tao tru user admin hay superadmin
            {
                model = model.Where(x => x.nguoitao == usr.username || x.nguoitao.Contains(usr.fullName) || x.nguoisua == usr.username || x.nguoisua.Contains(usr.fullName));
            }

            return model.OrderBy(x => x.batdau).ThenBy(x=>x.ngaytao).ToPagedList(page, pagesize);
        }

        public List<tour> GetDsTour(string searchString, string tencongty, string sohopdong, string sChiNhanh, string sDaily, users usr)
        {
            IQueryable<tour> model = db.tour;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.sgtcode.Contains(searchString));
            }         

            if (!String.IsNullOrEmpty(tencongty))
            {
                model = model.Where(x => x.tenkh.Contains(tencongty));
            }

            if (!String.IsNullOrEmpty(sohopdong))
            {
                model = model.Where(x => x.sohopdong.Contains(sohopdong));
            }

            if (!String.IsNullOrEmpty(sChiNhanh) && usr.role != "admin" && usr.role != "superadmin")
            {
                model = model.Where(x => x.chinhanh == sChiNhanh);
            }


            //15/05: tam cho phep sales thay toan bo code cua chi nhanh
            if (usr.role == "salemanager") //chi thay code cua chi nhanh minh
            {
                model = model.Where(x => x.chinhanh == usr.chinhanh);

            }
            //15/05 tam thoi bo dieu kien nay
            //16/5 mo lai, sale chi thay doan cua minh
            if (usr != null && usr.role != "admin" && usr.role != "superadmin" && usr.role != "salemanager") //user chi thay du lieu do minh tao tru user admin hay superadmin
            {
                model = model.Where(x => x.nguoitao == usr.username || x.nguoitao.Contains(usr.fullName) || x.nguoisua == usr.username || x.nguoisua.Contains(usr.fullName));
            }

            return model.OrderByDescending(x => x.ngaytao).ToList();
        }

        public List<dmkhachhang> GetDmKhachHang(string tengiaodich)
        {
            List<dmkhachhang> lst = db.dmkhachhang.Where(x => x.tengiaodich.Contains(tengiaodich)).OrderBy(x=>x.tengiaodich).ToList();
            return lst;
        }

        public object GetDmKh(string[] id)
        {
            IQueryable<dmkhachhang> lst = db.dmkhachhang;
                       
            if (id != null)
            {
                lst = from m in lst where id.Contains(m.makh) select m;
            }

            lst = lst.OrderBy(x => x.tengiaodich);             
            return lst;
        }

     

        public List<quan> GetQuanByLstId(decimal[] id)
        {
            List<quan> lst = new List<quan>();

            var model = from s in db.quan select s;
            if (id != null)
            {
                model = from m in model where id.Contains(m.maquan) select m;
            }

            model = model.OrderBy(x => x.tenquan);

            lst = model.ToList();
            return lst;
        }

      

        public tour Details(decimal id)
        {
            tour model = db.tour.Find(id);
            return model;
        }

        public tour DetailsByCode(string sgtcode)
        {
            tour model = db.tour.Where(x => x.sgtcode == sgtcode).FirstOrDefault();
            return model;
        }

        public string Update(tour model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model.sgtcode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Insert(tour model)
        {
            try
            {
                db.tour.Add(model);
                db.SaveChanges();
                return model.sgtcode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Delete(decimal id)
        {
            tour co = db.tour.Find(id);
            db.tour.Remove(co);
            db.SaveChanges();
            return id.ToString();
        }

        public string GetStrSTTCuaSoHopDong(int nam, int thang)
        {
            DataSet ds = GetSoHopDong(nam,thang);
            DataTable dt = ds.Tables[0];

            string sRes = "";
            if (dt.Rows.Count > 0)
            {
                sRes = dt.Rows[0]["stt"].ToString();
            }

            return sRes;
        }

        public DataSet GetSoHopDong(int nam, int thang)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(constr))
            {
                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "spGetSoHopDong";
                cmdReport.Parameters.Add(new SqlParameter("nam", nam));
                cmdReport.Parameters.Add(new SqlParameter("thang", thang));

                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(ds);
                }
            }


            return ds;
        }

        public int HuyTourSangKhachLe(string sgtcode, DateTime? huytour, string nguoihuy, string lydohuy)
        {
            int iOutput = 0;

            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;

            try
            {
                SqlConnection sqlConn = new SqlConnection(constr);
                sqlConn.Open();

                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "spHuyKhachDoanTourleob";
                cmdReport.Parameters.Add(new SqlParameter("sgtcode", sgtcode));
                cmdReport.Parameters.Add(new SqlParameter("huytour", huytour));
                cmdReport.Parameters.Add(new SqlParameter("nguoihuy", nguoihuy));
                cmdReport.Parameters.Add(new SqlParameter("lydohuy", lydohuy));              

                try
                {
                    int sqlRows = cmdReport.ExecuteNonQuery();
                    iOutput = sqlRows;
                }
                catch (Exception e)
                {
                    iOutput = -1;
                }


            }
            catch (Exception e)
            {
                iOutput = -1;
            }


            return iOutput;
        }


        /// <summary>
        /// sau khi update thong tin khach doan, phai cap nhat sang khach le
        /// vi chuong trình huong dan vien co su dung
        /// </summary>
        /// <param name="chinhanh"></param>
        /// <param name="batdau"></param>
        /// <param name="ketthuc"></param>
        /// <param name="sokhach"></param>
        /// <param name="tuyentq"></param>
        /// <param name="chudetour"></param>
        /// <param name="makh"></param>
        /// <param name="nguoitaotour"></param>
        /// <returns></returns>
        public int CapNhatThongTinSangKhachLe(string sgtcode, string makh, string chuongtrinhtour, DateTime? batdau, DateTime? ketthuc,string tuyentq, string diemtq, string chudetour, int? sokhachdk=0)
        {
            int iOutput = 0;

            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;

            try
            {
                SqlConnection sqlConn = new SqlConnection(constr);
                sqlConn.Open();

                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "spUpdateKhachDoanTourleob";
                cmdReport.Parameters.Add(new SqlParameter("sgtcode", sgtcode));
                cmdReport.Parameters.Add(new SqlParameter("batdau", batdau));
                cmdReport.Parameters.Add(new SqlParameter("ketthuc", ketthuc));
                cmdReport.Parameters.Add(new SqlParameter("tuyentq", tuyentq));
                cmdReport.Parameters.Add(new SqlParameter("diemtq", diemtq));
                cmdReport.Parameters.Add(new SqlParameter("chudetour", chudetour));
                cmdReport.Parameters.Add(new SqlParameter("sokhachdk", sokhachdk));
                cmdReport.Parameters.Add(new SqlParameter("makh", makh));
                cmdReport.Parameters.Add(new SqlParameter("chuongtrinhtour", chuongtrinhtour));

                try
                {
                    int sqlRows = cmdReport.ExecuteNonQuery();
                    iOutput = sqlRows;
                }
                catch (Exception e)
                {
                    iOutput = -1;
                }


            }
            catch (Exception e)
            {
                iOutput = -1;
            }            


            return iOutput;
        }

        public string CapNhatThongTinSangKhachLeStr(string sgtcode, string makh, string chuongtrinhtour, DateTime? batdau, DateTime? ketthuc, string tuyentq, string diemtq, string chudetour, int? sokhachdk = 0)
        {
            string iOutput = "";

            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;

            try
            {
                SqlConnection sqlConn = new SqlConnection(constr);
                sqlConn.Open();

                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "spUpdateKhachDoanTourleob";
                cmdReport.Parameters.Add(new SqlParameter("sgtcode", sgtcode));
                cmdReport.Parameters.Add(new SqlParameter("batdau", batdau));
                cmdReport.Parameters.Add(new SqlParameter("ketthuc", ketthuc));
                cmdReport.Parameters.Add(new SqlParameter("tuyentq", tuyentq));
                cmdReport.Parameters.Add(new SqlParameter("diemtq", diemtq));
                cmdReport.Parameters.Add(new SqlParameter("chudetour", chudetour));
                cmdReport.Parameters.Add(new SqlParameter("sokhachdk", sokhachdk));
                cmdReport.Parameters.Add(new SqlParameter("makh", makh));
                cmdReport.Parameters.Add(new SqlParameter("chuongtrinhtour", chuongtrinhtour));

                try
                {
                    int sqlRows = cmdReport.ExecuteNonQuery();
                    iOutput = sqlRows.ToString();
                }
                catch (Exception e)
                {
                    iOutput = e.Message;
                }


            }
            catch (Exception e)
            {
                iOutput = e.Message;
            }


            return iOutput;
        }

        /*
         ALTER PROC [dbo].[spTaoCodeDoan]
            @chinhanh VARCHAR(3),
            @batdau DATETIME,
            @ketthuc DATETIME,
            @sokhach INT,
            @tuyentq NVARCHAR(150),
            @chudetour NVARCHAR(150),
            @makh VARCHAR(5),
            @nguoitaotour NVARCHAR(25),
            @sgtcode VARCHAR(17) OUTPUT
             */
        public string TaoCodeDoan(string chinhanh,DateTime batdau, DateTime ketthuc,int sokhach,string tuyentq,string chudetour,string makh,string nguoitaotour)
        {
            string sOutputSgtCode = "";
           
            string constr = ConfigurationManager.ConnectionStrings["strkhi_goiprocedure"].ConnectionString;

            try
            {
                SqlConnection sqlConn = new SqlConnection(constr);
                sqlConn.Open();

                SqlCommand cmdReport = sqlConn.CreateCommand();
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "spTaoCodeDoan";
                cmdReport.Parameters.Add(new SqlParameter("chinhanh", chinhanh));
                cmdReport.Parameters.Add(new SqlParameter("batdau", batdau));
                cmdReport.Parameters.Add(new SqlParameter("ketthuc", ketthuc));
                cmdReport.Parameters.Add(new SqlParameter("sokhach", sokhach));
                cmdReport.Parameters.Add(new SqlParameter("tuyentq", tuyentq));
                cmdReport.Parameters.Add(new SqlParameter("chudetour", chudetour));
                cmdReport.Parameters.Add(new SqlParameter("makh", makh));
                cmdReport.Parameters.Add(new SqlParameter("nguoitaotour", nguoitaotour));

                SqlParameter sgtcodeP = new SqlParameter();
                sgtcodeP.ParameterName = "sgtcode";
                sgtcodeP.Direction = ParameterDirection.Output;
                sgtcodeP.DbType = DbType.String;
                sgtcodeP.Size = 17;
                cmdReport.Parameters.Add(sgtcodeP);

                try
                {
                    int sqlRows = cmdReport.ExecuteNonQuery();
                    sOutputSgtCode = sgtcodeP.Value.ToString();

                    if (sqlRows > 0)
                        sOutputSgtCode = cmdReport.Parameters["sgtcode"].Value.ToString();
                }
                catch (Exception e)
                {

                }

            }
            catch (Exception e)
            {
                
            }

            //using (SqlConnection sqlConn = new SqlConnection(constr))
            //{
                
            //}           
            


            return sOutputSgtCode;
        }

    }
}
