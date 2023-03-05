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
    public partial class frmNH : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        ClassDB db = new ClassDB();
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        frmNamHoc f;
        public frmNH(frmNamHoc f)
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

        private void cboHocKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtYear1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtYear2.Text = (long.Parse(txtYear1.Text) + 1).ToString();
            } catch (Exception ex)
            {
                txtYear2.Clear();
            }
        }

        public void Clear()
        {
            txtYear1.Clear();
            txtYear2.Clear();
            cboHocKy.Text = "";
            txtYear1.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string _nhcode = txtYear1.Text + txtYear2.Text + cboHocKy.Text;
                if (txtYear1.Text==String.Empty || txtYear2.Text==String.Empty || cboHocKy.Text=="")
                {
                    MessageBox.Show("Vui Lòng Điền Đủ Thông Tin", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Xác Nhận Thêm Mới?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE tbNamHoc set tinhtrang = 'ĐÓNG'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_NH_INSERT";
                    cmd.Parameters.AddWithValue("@nhcode", _nhcode);
                    cmd.Parameters.AddWithValue("@nam1", txtYear1.Text);
                    cmd.Parameters.AddWithValue("@nam2", txtYear2.Text);
                    cmd.Parameters.AddWithValue("@hocky", cboHocKy.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thêm Năm Học Mới Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRecords();
                    Clear();
                }
            } catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmNH_Load(object sender, EventArgs e)
        {

        }
    }
}
