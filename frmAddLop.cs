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
    public partial class frmAddLop : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        frmLop f;
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmAddLop(frmLop f)
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = db.GetConnection();
            this.f = f;
        }

        public void getCTHoc()
        {
            con.Open();
            cmd = new SqlCommand("select * from tbCTHoc", con);
            dr = cmd.ExecuteReader();
            cboCTHoc.Items.Clear();
            cboCTHoc.Items.Add("N/A");
            while (dr.Read())
            {
                cboCTHoc.Items.Add(dr["cthoc"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void cboCTHoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboKhoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            cboCTHoc.Text = "";
            cboKhoi.Text = "";
            txtGVCN.Clear();
            txtTenLop.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            cboKhoi.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO tbLop (khoi,lop,cthoc,gvcn)values(@khoi,@lop,@cthoc,@gvcn)",con);
                cmd.Parameters.AddWithValue("@khoi", cboKhoi.Text);
                cmd.Parameters.AddWithValue("@cthoc", cboCTHoc.Text);
                cmd.Parameters.AddWithValue("@lop", txtTenLop.Text);
                cmd.Parameters.AddWithValue("@gvcn", txtGVCN.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm Lớp Học Mới Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                f.LoadRecord();
                f.Dispose();
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
                cmd = new SqlCommand("UPDATE tbLop set khoi=@khoi,lop=@lop,cthoc=@cthoc,gvcn=@gvcn where id=@id", con);
                cmd.Parameters.AddWithValue("@khoi", cboKhoi.Text);
                cmd.Parameters.AddWithValue("@cthoc", cboCTHoc.Text);
                cmd.Parameters.AddWithValue("@lop", txtTenLop.Text);
                cmd.Parameters.AddWithValue("@gvcn", txtGVCN.Text);
                cmd.Parameters.AddWithValue("@id", lbID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cập Nhật Lớp Học Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
