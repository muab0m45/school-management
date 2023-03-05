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
    public partial class frmAddGV : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        frmGV f;
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmAddGV(frmGV f)
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
            txtmgv.Clear();
            txthoten.Clear();
            txtquequan.Clear();
            txtdiachi.Clear();
            txtlienhe.Clear();
            txttrinhdo.Clear();
            dtngaysinh.Value = DateTime.Now;
            cboGioiTinh.Text = "";
            txtemail.Clear();
            txtchuyenmon.Clear();
            txtmgv.Focus();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO tbGiaoVien(mgv,hoten,quequan,diachi,lienhe,trinhdo,ngaysinh,email,chuyenmon,gioitinh)values(@mgv,@hoten,@quequan,@diachi,@lienhe,@trinhdo,@ngaysinh,@email,@chuyenmon,@gioitinh)", con);
                cmd.Parameters.AddWithValue("@mgv", txtmgv.Text);
                cmd.Parameters.AddWithValue("@hoten", txthoten.Text);
                cmd.Parameters.AddWithValue("@quequan", txtquequan.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                cmd.Parameters.AddWithValue("@lienhe", txtlienhe.Text);
                cmd.Parameters.AddWithValue("@trinhdo", txttrinhdo.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", dtngaysinh.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@chuyenmon", txtchuyenmon.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cboGioiTinh.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm Giáo Viên Mới Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cmd = new SqlCommand("UPDATE tbGiaoVien SET mgv=@mgv,hoten=@hoten,quequan=@quequan,diachi=@diachi,lienhe=@lienhe,trinhdo=@trinhdo,ngaysinh=@ngaysinh,email=@email,chuyenmon=@chuyenmon,gioitinh=@gioitinh", con);
                cmd.Parameters.AddWithValue("@mgv", txtmgv.Text);
                cmd.Parameters.AddWithValue("@hoten", txthoten.Text);
                cmd.Parameters.AddWithValue("@quequan", txtquequan.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                cmd.Parameters.AddWithValue("@lienhe", txtlienhe.Text);
                cmd.Parameters.AddWithValue("@trinhdo", txttrinhdo.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", dtngaysinh.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@chuyenmon", txtchuyenmon.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cboGioiTinh.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cập Nhật Thông Tin Giáo Viên Thành Công.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
