using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlkdstDB.Data.ViewModel
{
    public class hangkhongViewModal
    {
        [Key]
        public decimal id { get; set; }
        public string sgtcode { get; set; }
        public string mancc { get; set; }
        public string tenncc { get; set; }
        public string iddv { get; set; }
        public string hanhtrinh { get; set; }
        public string codebooking { get; set; }
        public string loaibooking { get; set; }
        public int chococ1 { get; set; }
        public decimal tiencoc1 { get; set; }
        public int chococ2 { get; set; }
        public decimal tiencoc2 { get; set; }
        public int chococ3 { get; set; }
        public decimal tiencoc3 { get; set; }
        public int sochoxuatve { get; set; }
        public decimal tiencocphat { get; set; }
        public decimal tiencochoan { get; set; }
        public string ghichu { get; set; }
        public string logfilehk { get; set; }

        public string tendv { get; set; }
        public decimal idtour { get; set; }

        public string nguoinhap { get; set; }
        public DateTime? ngaynhap { get; set; }
        public string nguoisua { get; set; }
        public DateTime? ngaysua { get; set; }
    }
}
