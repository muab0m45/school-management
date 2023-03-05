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
    public partial class frmNamHoc : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        string _title = "QUẢN LÝ TRƯỜNG LIÊN CẤP";
        public frmNamHoc()
        {
            InitializeComponent();
            con = new SqlConnection(db.GetConnection());
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNH f = new frmNH(this);
            f.ShowDialog();
        }

        public void LoadRecords()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new SqlCommand("select * from tbNamHoc", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["nhcode"].ToString(), dr["nam1"].ToString() + "-" + dr["nam2"].ToString(), dr["hocky"].ToString(), dr["tinhtrang"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colOpen")
            {
                if (MessageBox.Show("Mở Năm Học/Học Kỳ Này?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("update tbNamHoc set tinhtrang = N'ĐÓNG'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("update tbNamHoc set tinhtrang = N'MỞ' where nhcode like N'" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Năm Học/Học Kỳ Đã Được Mở Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
            } else if (colName == "colClose")
            {
                if (MessageBox.Show("Đóng Năm Học/Học Kỳ Này?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    

                    con.Open();
                    cmd = new SqlCommand("update tbNamHoc set tinhtrang = N'ĐÓNG' where nhcode like N'" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Năm Học/Học Kỳ Đã Được Đóng Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void frmNamHoc_Load(object sender, EventArgs e)
        {

        }
    }
}
