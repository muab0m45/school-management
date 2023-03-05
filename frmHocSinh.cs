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
    public partial class frmHocSinh : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmHocSinh()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = db.GetConnection();
        }

        public void LoadRecord()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            cmd = new SqlCommand("Select * from tbHocSinh where tinhtrang like N'Hoạt Động'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i,dr["mhs"].ToString(), dr["hoten"].ToString(), dr["gioitinh"].ToString(), DateTime.Parse(dr["ngaysinh"].ToString()).ToShortDateString(), dr["lop"].ToString(), dr["noisinh"].ToString(), dr["diachi"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddHS f = new frmAddHS(this);
            f.getLop();
            f.btnSave.Enabled = true;
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "colEdit")
            {
                frmAddHS f = new frmAddHS(this);
                con.Open();
                cmd = new SqlCommand("select * from tbHocSinh where mhs like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                dr = cmd.ExecuteReader(); 
                dr.Read();
                if (dr.HasRows)
                {
                    f.txtmhs.Text = dr["mhs"].ToString();
                    f.txthoten.Text = dr["hoten"].ToString();
                    f.cboGioiTinh.Text = dr["gioitinh"].ToString();
                    f.dtngaysinh.Text = dr["ngaysinh"].ToString();
                    f.txtnoisinh.Text = dr["noisinh"].ToString();
                    f.txtdantoc.Text = dr["dantoc"].ToString();
                    f.txttongiao.Text = dr["tongiao"].ToString();
                    f.txtdoituong.Text = dr["doituong"].ToString();
                    f.txtdiachi.Text = dr["diachi"].ToString();
                    f.txtlienhe.Text = dr["lienhe"].ToString();
                    f.txtghichu.Text = dr["ghichu"].ToString();
                    f.cboLop.Text = dr["lop"].ToString();
                    f.txthtbo.Text = dr["htbo"].ToString();
                    f.txthtme.Text = dr["htme"].ToString();
                    f.txthtace.Text = dr["htace"].ToString();
                    f.txtnghebo.Text = dr["nghebo"].ToString();
                    f.txtngheme.Text = dr["ngheme"].ToString();
                    f.txtngheace.Text = dr["ngheace"].ToString();
                    f.txtlienhebm.Text = dr["lienhebm"].ToString();
                    f.txtghichubm.Text = dr["ghichubm"].ToString();
                    f.btnUpdate.Enabled = true;
                    f.btnSave.Enabled = false;
                }
                dr.Close();
                con.Close();
                f.ShowDialog();
            } else if(colName == "colDelete")
            {
                if(MessageBox.Show("Xác Nhận Lưu Trữ Học Sinh?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("Update tbHocSinh set tinhtrang = N'Không Hoạt Động' where mhs like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sinh Viên Đã Được Lưu Trữ.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecord();
                }
            }
        }
    }
}
