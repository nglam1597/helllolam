using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.UC; 


namespace GUI
{
    public partial class frmQuanLyBanHang : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmQuanLyBanHang()
        {
            InitializeComponent();
        }

        private void frmQuanLyBanHang_Load(object sender, EventArgs e)
        {

        }
        private void DongTab()
        {
            TabItem tabItem = TabHeThong.SelectedTab;
            DialogResult dialogResult = MessageBox.Show("Bạn Có Chắc Chắn Đóng Trang : " + tabItem.Text,
                "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if(TabHeThong.SelectedTabIndex !=0)
                {
                    TabHeThong.Tabs.Remove(tabItem); // xóa theo tab được chọn 
                }
            }
        }
        private void TabHeThong_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {
            DongTab(); 
            
        }
        
        private void MenuItemDongTrang_Click(object sender, EventArgs e)
        {
            DongTab(); 
        }

        private void MenuStripHeThong_Opening(object sender, CancelEventArgs e)
        {
            if(TabHeThong.SelectedTabIndex == 0)
            {
                MenuItemDongTrang.Enabled = false; 
            }
            else
            {
                MenuItemDongTrang.Enabled = true; 
            }
        }

        private void MenuItemDongTrangKhac_Click(object sender, EventArgs e)
        {
            int index = TabHeThong.SelectedTabIndex;
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Đóng Tất Cả Các Trang Khác", "Xác Nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
            if(dialogResult == DialogResult.Yes)
            {
                for (int i = TabHeThong.Tabs.Count - 1; i > 0; i--)
                {
                    if (index != i)
                    {
                        TabHeThong.Tabs.RemoveAt(i);
                    }
                }
                TabHeThong.Refresh();
            }
            
        }

        private void MenuItemDongTatCa_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Đóng Tất Cả Các Trang", "Xác Nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = TabHeThong.Tabs.Count - 1; i > 0; i--)
                {
                    TabHeThong.Tabs.RemoveAt(i);    
                }
                TabHeThong.Refresh();
            }
        }

        private void AddNewTab(string NameTab ,UserControl userControl)
        {
            foreach(TabItem tabItem in TabHeThong.Tabs)
            {
                if(tabItem.Text == NameTab)
                {
                    TabHeThong.SelectedTab = tabItem;
                    return; 
                }
            }
            TabControlPanel tabControlPanel = new TabControlPanel(); 
        }
        private void addtab(string tabname, UserControl control)
        {
            foreach (TabItem tabPage in TabHeThong.Tabs)
            {
                if (tabPage.Text == tabname)
                {
                    TabHeThong.SelectedTab = tabPage;
                    return;
                }
            }
            TabControlPanel newtabpannel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newtab = new TabItem(this.components);
            newtabpannel.Dock = System.Windows.Forms.DockStyle.Fill;
            newtabpannel.Location = new System.Drawing.Point(0, 26);
            newtabpannel.Name = tabname;
            newtabpannel.Padding = new System.Windows.Forms.Padding(1);
            newtabpannel.Size = new System.Drawing.Size(1230, 384);
            newtabpannel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newtabpannel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newtabpannel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newtabpannel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newtabpannel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newtabpannel.Style.GradientAngle = 90;
            newtabpannel.TabIndex = 2;

            newtabpannel.TabItem = newtab;
            Random ran = new Random();
            newtab.Name = tabname + ran.Next(100000) + ran.Next(22342);

            newtab.AttachedControl = newtabpannel;
            newtab.Text = tabname;
            newtab.CloseButtonVisible = true;
            control.Dock = DockStyle.Fill;
            newtabpannel.Controls.Add(control);
            TabHeThong.Controls.Add(newtabpannel);
            TabHeThong.Tabs.Add(newtab);
            TabHeThong.SelectedTab = newtab;
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UCNhanVien uCNhanVien = new UCNhanVien();
            addtab("Nhân Viên", uCNhanVien); 
        }

      
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            UCKhachHang uCKhachHang = new UCKhachHang();
            addtab("Khách Hàng", uCKhachHang); 
        }

       

        private void btnMatKhau_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThoatHeThong_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Thoát Khỏi Hệ Thống", "Xác Nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
            if(dialogResult == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void btnDoiHinhNen_Click(object sender, EventArgs e)
        {
            TabHeThong.SelectedTab = TabGioiThieu; 
        }


        private void btnSanPham_Click_1(object sender, EventArgs e)
        {
            UCSanPham uCSanPham = new UCSanPham();
            addtab("Sản Phẩm ", uCSanPham); 
         
        }

        private void btnloaiKhachHang_Click(object sender, EventArgs e)
        {
            UCLoaiKhacHang uCLoaiKhacHang = new UCLoaiKhacHang();
            addtab("Loại Khách Hang", uCLoaiKhacHang); 
        }

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {
            UCLoaiSanPham uCLoaiSanPham = new UCLoaiSanPham();
            addtab("Loại Sản Phẩm", uCLoaiSanPham); 
        }

        private void btbKhoHang_Click_1(object sender, EventArgs e)
        {
            UCKhoHang uCKhoHang = new UCKhoHang();
            addtab("Kho Hàng ", uCKhoHang); 
        }

        private void btnNhaSanSuat_Click(object sender, EventArgs e)
        {
            UCNhaSanXuat uCNhaSanXuat = new UCNhaSanXuat();
            addtab("Nhà Sản Xuất", uCNhaSanXuat); 

        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            UCNhaCungCap uCNhaCungCap = new UCNhaCungCap();
            addtab("Nhà Cung Cấp", uCNhaCungCap); 
        }

        private void btnBaoHanh_Click_1(object sender, EventArgs e)
        {
            UCDanhSachBaoHanh uCDanhSachBaoHanh = new UCDanhSachBaoHanh();
            addtab("Danh Sách Bào Hành", uCDanhSachBaoHanh); 
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            UCHoaDonBaoHanh uCHoaDonBaoHanh = new UCHoaDonBaoHanh();
            addtab("Hóa Đơn Bảo Hành", uCHoaDonBaoHanh); 
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            UCHoaDonNhap uCHoaDonNhap = new UCHoaDonNhap();
            addtab("Hóa Đơn Nhập SP", uCHoaDonNhap); 
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            UCHoaDonBanHang uCHoaDonBanHang = new UCHoaDonBanHang();
            addtab("Hóa Đơn Bán Hàng", uCHoaDonBanHang); 
        }

        private void rbHeThong_Click(object sender, EventArgs e)
        {

        }
    }
}
