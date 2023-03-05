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
    public partial class frmCTHoc : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string _title = "QUẢN LÝ TRƯỜNG LIÊN CẤP";
        ClassDB db = new ClassDB();
        public frmCTHoc()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = db.GetConnection();
        }

        private void frmCTHoc_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddCTH fcth = new frmAddCTH(this);
            fcth.ShowDialog();
        }

        public void Loadrecord()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new SqlCommand("select * from tbCTHoc", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["cthoc"].ToString(), dr["mota"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                frmAddCTH f = new frmAddCTH(this);
                f.txtTenCTH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtMotaCTH.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.btnSave.Enabled = false;
                f.btnUpdate.Enabled = true;
                f.txtTenCTH.Enabled = false;
                f.ShowDialog();
            }
            else if (colName == "colDelete")
            {
                if (MessageBox.Show("Xác Nhận Xóa?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("delete from tbCTHoc where cthoc like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Xóa Chương Trình Học Thành Công!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loadrecord();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
