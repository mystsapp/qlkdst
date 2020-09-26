using qlkdstDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qlkdst.Data.ViewModel
{
    public class dmkhachtourVM
    {
        public dmkhachtour dmkhachtour { get; set; }
        public HttpPostedFileBase uploadExcel { get; set; }
        public decimal idtour { get; set; }
    }
}