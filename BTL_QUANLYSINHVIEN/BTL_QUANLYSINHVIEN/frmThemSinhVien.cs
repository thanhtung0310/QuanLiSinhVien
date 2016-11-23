using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;

namespace BTL_QUANLYSINHVIEN
{
    public partial class frmThemSinhVien : DevExpress.XtraEditors.XtraForm
    {
        public string tenLop = "";
        public frmThemSinhVien()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            //load tên lớp vào combobox
            DataTable dtb = Lop_BUS.LoadtenLop();
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                string name = ChuanHoa(dtb.Rows[i][0].ToString().ToLower());
                cboLop.Items.Add(name);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //chuẩn hóa chuỗi
        public string ChuanHoa(string st)
        {
            string st1 = "";
            st = st.Trim();
            while (st.Length != 0)
            {
                st += " ";
                int i = st.IndexOf(' ');
                string s = char.ToUpper(st[0]) + st.Substring(1, i);
                st1 += s;
                st = st.Substring(i + 1).Trim();
            }
            return st1.Trim();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            tenLop = cboLop.Text;
        }
    }
}