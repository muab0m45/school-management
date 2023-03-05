namespace Quan_Ly_Truong_Hoc_Lien_Cap
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.FromArgb(64, 64, 64);
            menuStrip1.ForeColor = Color.BlueViolet;
            menuStrip1.Cursor = Cursors.Hand;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void menuNH_Click(object sender, EventArgs e)
        {
            frmNamHoc f = new frmNamHoc();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecords();
            f.BringToFront();
            f.Show();
        }

        private void menuCTH_Click(object sender, EventArgs e)
        {
            frmCTHoc f = new frmCTHoc();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.Loadrecord();
            f.BringToFront();
            f.Show();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void menuLop_Click(object sender, EventArgs e)
        {
            frmLop f = new frmLop();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecord();
            f.BringToFront();
            f.Show();
        }

        private void menuHocSinh_Click(object sender, EventArgs e)
        {
            frmHocSinh f = new frmHocSinh();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecord();
            f.BringToFront();
            f.Show();
        }

        private void menuLuuTru_Click(object sender, EventArgs e)
        {
            frmLuuTru f = new frmLuuTru();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecord();
            f.BringToFront();
            f.Show();
        }

        private void menuGiaoVien_Click(object sender, EventArgs e)
        {
            frmGV f = new frmGV();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecord();
            f.BringToFront();
            f.Show();
        }

        private void menuMonHoc_Click(object sender, EventArgs e)
        {
            frmMonHoc f = new frmMonHoc();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecord();
            f.BringToFront();
            f.Show();
        }

        private void menuPhongHoc_Click(object sender, EventArgs e)
        {
            frmPhongHoc f = new frmPhongHoc();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.LoadRecord();
            f.BringToFront();
            f.Show();
        }
    }
}