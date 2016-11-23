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
using DTO;

namespace BTL_QUANLYSINHVIEN
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public int chucVu=-1;
        NhanVien_DTO user = new NhanVien_DTO();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (NhanVien_BUS.Login(tbUserName.Text, tbPassWord.Text).Rows.Count>0)
            {
               // Form1 f = new Form1();
               // f.userName = tbUserName.Text;
           //   NhanVien_BUS.Login(tbUserName.Text, tbPassWord.Text);
                chucVu =Convert.ToInt32( NhanVien_BUS.Login(tbUserName.Text, tbPassWord.Text).Rows[0][5]);
             //   MessageBox.Show(chucVu.ToString());
              //  f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công");
                tbUserName.Clear();
                tbPassWord.Clear();
            }
        }

        //private void btnThoat_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
    }
}