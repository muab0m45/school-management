using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Quan_Ly_Truong_Hoc_Lien_Cap
{
    public partial class frmAddPH : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        frmPhongHoc f;
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmAddPH(frmPhongHoc f)
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = db.GetConnection();
            this.f = f;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txttenphong.Clear();
            cboloaiphong.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txttenphong.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO tbPhongHoc(phong,loaiphong)values(@phong,@loaiphong)", con);
                cmd.Parameters.AddWithValue("@phong", txttenphong.Text);
                cmd.Parameters.AddWithValue("@loaiphong", cboloaiphong.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm Phòng Học Mới Thành Công.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                f.LoadRecord();
                this.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE tbPhongHoc SET loaiphong=@loaiphong where phong=@phong", con);
                cmd.Parameters.AddWithValue("@phong", txttenphong.Text);
                cmd.Parameters.AddWithValue("@loaiphong", cboloaiphong.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cập Nhật Phòng Học Thành Công.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                f.LoadRecord();
                this.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
