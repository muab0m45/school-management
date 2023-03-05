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
    public partial class frmLop : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmLop()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = db.GetConnection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddLop f = new frmAddLop(this);
            f.btnSave.Enabled = true;
            f.btnUpdate.Enabled = false;
            f.getCTHoc();
            f.ShowDialog();
        }
        public void LoadRecord()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            con.Open();
            cmd = new SqlCommand("Select * from tbLop", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["cthoc"].ToString(), dr["khoi"].ToString(), dr["lop"].ToString(), dr["gvcn"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                frmAddLop f = new frmAddLop(this);
                f.getCTHoc();
                f.lbID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.cboCTHoc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.cboKhoi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                f.txtTenLop.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.txtGVCN.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.btnSave.Enabled = false;
                f.btnUpdate.Enabled = true;
                f.ShowDialog();
            }
            else if (colName == "colDelete")
            {
                if (MessageBox.Show("Xác Nhận Xóa?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("delete from tbLop where id = '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Xóa Lớp Học Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecord();
                }
            }
        }
    }
}
