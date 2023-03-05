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
    public partial class frmAddMH : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        frmMonHoc f;
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmAddMH(frmMonHoc f)
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
            cbocthoc.Items.Clear();
            while (dr.Read())
            {
                cbocthoc.Items.Add(dr["cthoc"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            cbocthoc.Text = "";
            cbokhoi.Text = "";
            txtmmh.Clear();
            txttenmh.Clear();
            txtsotiet.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtmmh.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO tbMonHoc(mmh,tenmh,khoi,cthoc,sotiet)values(@mmh,@tenmh,@khoi,@cthoc,@sotiet)", con);
                cmd.Parameters.AddWithValue("@mmh", txtmmh.Text);
                cmd.Parameters.AddWithValue("@tenmh", txttenmh.Text);
                cmd.Parameters.AddWithValue("@khoi", cbokhoi.Text);
                cmd.Parameters.AddWithValue("@cthoc", cbocthoc.Text);
                cmd.Parameters.AddWithValue("@sotiet", txtsotiet.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm Môn Học Mới Thành Công.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cmd = new SqlCommand("UPDATE tbMonHoc SET mmh=@mmh,tenmh=@tenmh,khoi=@khoi,cthoc=@cthoc,sotiet=@sotiet", con);
                cmd.Parameters.AddWithValue("@mmh", txtmmh.Text);
                cmd.Parameters.AddWithValue("@tenmh", txttenmh.Text);
                cmd.Parameters.AddWithValue("@khoi", cbokhoi.Text);
                cmd.Parameters.AddWithValue("@cthoc", cbocthoc.Text);
                cmd.Parameters.AddWithValue("@sotiet", txtsotiet.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cập Nhật Môn Học Thành Công", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
