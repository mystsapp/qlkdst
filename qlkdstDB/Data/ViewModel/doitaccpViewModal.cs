using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace qlkdstDB.Data.ViewModel
{
    public class doitaccpViewModal
    {
        public decimal Id { get; set; }
        public string sgtcode { get; set; }
        public string mancc { get; set; }
        public string tenncc { get; set; }
        public string iddv { get; set; }
        public Nullable<bool> tienmat { get; set; }
        public Nullable<decimal> ngoaite { get; set; }
        public string loaitien { get; set; }
        public Nullable<decimal> tigia { get; set; }
        public Nullable<decimal> tienvnd { get; set; }
        public Nullable<int> sokhach { get; set; }
        public string noidung { get; set; }
        public string ghichu { get; set; }
        public string nguoinhap { get; set; }
        public Nullable<System.DateTime> ngaynhap { get; set; }
        public string computer { get; set; }
        public Nullable<bool> del { get; set; }

        public string tenfileinvoice { get; set; }
        public string log_file { get; set; }

        public HttpPostedFileBase uploadInvoice { get; set; }
        public string tendv { get; set; }        
        public decimal idtour { get; set; }
               
    }
}
