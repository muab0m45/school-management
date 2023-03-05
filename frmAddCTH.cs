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
    public partial class frmAddCTH : Form
    {
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        ClassDB db = new ClassDB();
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        frmCTHoc f;
        public frmAddCTH(frmCTHoc f)
        {
            con = new SqlConnection();
            con.ConnectionString = db.GetConnection();
            this.f = f;

            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAddCTH_Load(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            txtTenCTH.Clear();
            txtMotaCTH.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtTenCTH.Text == String.Empty) || (txtMotaCTH.Text == String.Empty))
                {
                    MessageBox.Show("Vui Lòng Điền Đủ Thông Tin", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CTHOC_INSERT";
                cmd.Parameters.AddWithValue("@cthoc", txtTenCTH.Text);
                cmd.Parameters.AddWithValue("@mota", txtMotaCTH.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm Chương Trình Học Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                f.Loadrecord();
            } catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtTenCTH.Text == String.Empty) || (txtMotaCTH.Text == String.Empty))
                {
                    MessageBox.Show("Vui Lòng Điền Đủ Thông Tin", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CTHOC_UPDATE";
                cmd.Parameters.AddWithValue("@mota", txtMotaCTH.Text);
                cmd.Parameters.AddWithValue("@cthoc", txtTenCTH.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cập Nhật Chương Trình Học Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                f.Loadrecord();
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
