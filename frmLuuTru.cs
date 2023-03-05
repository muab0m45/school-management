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
    public partial class frmLuuTru : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmLuuTru()
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
            cmd = new SqlCommand("Select * from tbHocSinh where tinhtrang like N'Không Hoạt Động'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["mhs"].ToString(), dr["hoten"].ToString(), dr["gioitinh"].ToString(), DateTime.Parse(dr["ngaysinh"].ToString()).ToShortDateString(), dr["lop"].ToString(), dr["noisinh"].ToString(), dr["diachi"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colRestore")
            {
                if (MessageBox.Show("Xác Nhận Khôi Phục Học Sinh?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("Update tbHocSinh set tinhtrang = N'Hoạt Động' where mhs like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Học Sinh Đã Được Khôi Phục.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecord();
                }
            }
        }
    }
}
