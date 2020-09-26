using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlkdstDB.Data.ViewModel
{
    public class tourViewModel
    {
        public tour tour { get; set; }
        public List<dmkhachtour> lstdmkhachtour { get; set; }
        public List<datcoc> lstbiennhan { get; set; }
        public List<vie_tttour> lstdsthongtin { get; set; }
        public List<doitaccpViewModal> lstdoitacCP { get; set; }
        public List<hangkhongViewModal> lsthkviewmodel { get; set; }
        public List<huongdanViewModal> lsthdviewmodel { get; set; }
        public List<visa> lstvisa { get; set; }
        public List<khachsan> lstks { get; set; }

        public List<dmfileViewModal> lstdmfileviewmodel { get; set; }
        public List<dmfileViewModal> lstfilehopdong { get; set; }
        public List<dmfileViewModal> lstfilechiettinh { get; set; }
    }
}
