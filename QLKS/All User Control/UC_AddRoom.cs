﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.All_User_Control
{
    public partial class UC_AddRoom : UserControl
    {
        funtion fn = new funtion();
        String querry;
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            querry = "Select * from rooms";
            DataSet ds = fn.getData(querry);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomno = txtRoomNo.Text;
                String type = txtRoomType.Text;
                String bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                querry = "insert into rooms (roomNo, roomType, bed, price) values ('" + roomno + "','" + type + "','" + bed + "'," + price + ")";
                fn.setData(querry, "Đã thêm phòng");

                UC_AddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền đầy đủ thông tin", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearAll()
        {
            txtRoomNo.Clear();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void guna2DataGridView1_Leave(object sender, EventArgs e)
        {

        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);  
        }
    }
}