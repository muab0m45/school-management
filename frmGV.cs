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
    public partial class frmGV : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmGV()
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
            cmd = new SqlCommand("Select * from tbGiaoVien", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["mgv"].ToString(), dr["hoten"].ToString(), dr["gioitinh"].ToString(), DateTime.Parse(dr["ngaysinh"].ToString()).ToShortDateString(), dr["diachi"].ToString(), dr["chuyenmon"].ToString(), dr["trinhdo"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddGV f = new frmAddGV(this);
            f.btnSave.Enabled = true;
            f.btnUpdate.Enabled = false;
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                frmAddGV f = new frmAddGV(this);
                con.Open();
                cmd = new SqlCommand("select * from tbGiaoVien where mgv like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    f.txtmgv.Text = dr["mgv"].ToString();
                    f.txthoten.Text = dr["hoten"].ToString();
                    f.txtquequan.Text = dr["quequan"].ToString();
                    f.txtdiachi.Text = dr["diachi"].ToString();
                    f.txtlienhe.Text = dr["lienhe"].ToString();
                    f.txttrinhdo.Text = dr["trinhdo"].ToString();
                    f.dtngaysinh.Text = dr["ngaysinh"].ToString();
                    f.txtemail.Text = dr["email"].ToString();
                    f.txtchuyenmon.Text = dr["chuyenmon"].ToString();
                    f.cboGioiTinh.Text = dr["gioitinh"].ToString();
                    f.btnUpdate.Enabled = true;
                    f.btnSave.Enabled = false;
                }
                dr.Close();
                con.Close();
                f.ShowDialog();
            }
            else if (colName == "colDelete")
            {
                if (MessageBox.Show("Xác Nhận Xóa?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("Delete from tbGiaoVien where mgv like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Giáo Viên Đã Được Xóa.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecord();
                }
            }
        }
    }
}
