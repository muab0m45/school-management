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
    
    public partial class frmMonHoc : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        string _title = "QUẢN LÝ TRƯỜNG HỌC LIÊN CẤP";
        public frmMonHoc()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = db.GetConnection();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddMH f = new frmAddMH(this);
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
            cmd = new SqlCommand("Select * from tbMonHoc", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["mmh"].ToString(), dr["tenmh"].ToString(), dr["khoi"].ToString(), dr["cthoc"].ToString(), dr["sotiet"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                frmAddMH f = new frmAddMH(this);
                con.Open();
                cmd = new SqlCommand("select * from tbMonHoc where mmh like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    f.txtmmh.Text = dr["mmh"].ToString();
                    f.txttenmh.Text = dr["tenmh"].ToString();
                    f.cbokhoi.Text = dr["khoi"].ToString();
                    f.cbocthoc.Text = dr["cthoc"].ToString();
                    f.txtsotiet.Text = dr["sotiet"].ToString();
                    f.btnUpdate.Enabled = true;
                    f.btnSave.Enabled = false;
                }
                f.getCTHoc();
                dr.Close();
                con.Close();
                f.ShowDialog();
            }
            else if (colName == "colDelete")
            {
                if (MessageBox.Show("Xác Nhận Xóa?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("Delete from tbMonHoc where mmh like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Môn Học Đã Được Xóa.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecord();
                }
            }
        }
    }
}
