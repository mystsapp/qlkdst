using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace qlkdstDB.Data.ViewModel
{
    public class dmfileViewModal
    {
        public decimal file_id { get; set; }
        public string loaifile { get; set; }
        public string tenfile { get; set; }
        public Nullable<decimal> idtour { get; set; }

        public string nguoitao { get; set; }
        public Nullable<System.DateTime> ngaytao { get; set; }
        public string log_file { get; set; }
        public HttpPostedFileBase fileupload { get; set; }
    }
}
