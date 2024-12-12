using System;
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
   
    public partial class UC_CustomerDetails : UserControl
    {
        funtion fn = new funtion();
        String querry;
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

       

        private void txtSearchBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0)
            {
                querry = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid";
                getRecord(querry);
            }
            else if (txtSearchBy.SelectedIndex == 1)
            {
                querry = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is null ";
                getRecord(querry);
            }
            else if(txtSearchBy.SelectedIndex == 2)
            {
                querry = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is not null";
                getRecord(querry);
            }
        }
        private void getRecord(String querry)
        {
            DataSet ds = fn.getData(querry);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
} 