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
    public partial class frmAddHS : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        frmHocSinh f;
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmAddHS(frmHocSinh f)
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = db.GetConnection();
            this.f = f;
        }

        public void getLop()
        {
            con.Open();
            cmd = new SqlCommand("select * from tbLop", con);
            dr = cmd.ExecuteReader();
            cboLop.Items.Clear();
            while (dr.Read())
            {
                cboLop.Items.Add(dr["lop"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void cboGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void Clear()
        {
            txtmhs.Clear();
            txthoten.Clear();
            dtngaysinh.Value = DateTime.Now;
            cboGioiTinh.Text = "";
            txtnoisinh.Clear();
            txtdantoc.Clear();
            txttongiao.Clear();
            txtdoituong.Clear();
            txtdiachi.Clear();
            txtlienhe.Clear();
            txtghichu.Clear();
            txthtbo.Clear();
            txthtme.Clear();
            txtnghebo.Clear();
            txtngheme.Clear();
            txthtace.Clear();
            txtlienhebm.Clear();
            txtghichubm.Clear();
            cboLop.Text = "";
            txtmhs.Focus();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO tbHocSinh (mhs,hoten,ngaysinh,gioitinh,noisinh,dantoc,tongiao,doituong,diachi,lienhe,ghichu,htbo,htme,nghebo,ngheme,htace,ngheace,lienhebm,ghichubm,lop)" +
                    "values(@mhs,@hoten,@ngaysinh,@gioitinh,@noisinh,@dantoc,@tongiao,@doituong,@diachi,@lienhe,@ghichu,@htbo,@htme,@nghebo,@ngheme,@htace,@ngheace,@lienhebm,@ghichubm,@lop)", con);
                cmd.Parameters.AddWithValue("@mhs", txtmhs.Text);
                cmd.Parameters.AddWithValue("@hoten", txthoten.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", dtngaysinh.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@noisinh", txtnoisinh.Text);
                cmd.Parameters.AddWithValue("@dantoc", txtdantoc.Text);
                cmd.Parameters.AddWithValue("@tongiao", txttongiao.Text);
                cmd.Parameters.AddWithValue("@doituong", txtdoituong.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                cmd.Parameters.AddWithValue("@lienhe", txtlienhe.Text);
                cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text);
                cmd.Parameters.AddWithValue("@htbo", txthtbo.Text);
                cmd.Parameters.AddWithValue("@htme", txthtme.Text);
                cmd.Parameters.AddWithValue("@nghebo", txtnghebo.Text);
                cmd.Parameters.AddWithValue("@ngheme", txtngheme.Text);
                cmd.Parameters.AddWithValue("@htace", txthtace.Text);
                cmd.Parameters.AddWithValue("@ngheace", txtngheace.Text);
                cmd.Parameters.AddWithValue("@lienhebm", txtlienhebm.Text);
                cmd.Parameters.AddWithValue("@ghichubm", txtghichubm.Text);
                cmd.Parameters.AddWithValue("@lop", cboLop.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm Học Sinh Mới Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                f.LoadRecord();
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
                cmd = new SqlCommand("UPDATE tbHocSinh SET mhs=@mhs,hoten=@hoten,ngaysinh=@ngaysinh,gioitinh=@gioitinh,noisinh=@noisinh,dantoc=@dantoc,tongiao=@tongiao,doituong=@doituong,diachi=@diachi,lienhe=@lienhe,ghichu=@ghichu,htbo=@htbo,htme=@htme,nghebo=@nghebo,ngheme=@ngheme,htace=@htace,ngheace=@ngheace,lienhebm=@lienhebm,ghichubm=@ghichubm,lop=@lop where mhs=@mhs", con);
                
                cmd.Parameters.AddWithValue("@hoten", txthoten.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", dtngaysinh.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@noisinh", txtnoisinh.Text);
                cmd.Parameters.AddWithValue("@dantoc", txtdantoc.Text);
                cmd.Parameters.AddWithValue("@tongiao", txttongiao.Text);
                cmd.Parameters.AddWithValue("@doituong", txtdoituong.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                cmd.Parameters.AddWithValue("@lienhe", txtlienhe.Text);
                cmd.Parameters.AddWithValue("@ghichu", txtghichu.Text);
                cmd.Parameters.AddWithValue("@htbo", txthtbo.Text);
                cmd.Parameters.AddWithValue("@htme", txthtme.Text);
                cmd.Parameters.AddWithValue("@nghebo", txtnghebo.Text);
                cmd.Parameters.AddWithValue("@ngheme", txtngheme.Text);
                cmd.Parameters.AddWithValue("@htace", txthtace.Text);
                cmd.Parameters.AddWithValue("@ngheace", txtngheace.Text);
                cmd.Parameters.AddWithValue("@lienhebm", txtlienhebm.Text);
                cmd.Parameters.AddWithValue("@ghichubm", txtghichubm.Text);
                cmd.Parameters.AddWithValue("@lop", cboLop.Text);
                cmd.Parameters.AddWithValue("@mhs", txtmhs.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cập Nhật Thông Tin Học Sinh Thành Công.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
