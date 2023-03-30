/*
 * Created by SharpDevelop.
 * User: GENIUS
 * Date: 9/1/2022
 * Time: 5:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Group4Database_Projct
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		MySqlConnection mysconn = new MySqlConnection();
		
		
		//Reading Student data from the database.
		MySqlCommand sqlCmd = new MySqlCommand();
		DataTable dt = new DataTable();
		string sqlQuery;
		MySqlDataAdapter Adapter = new MySqlDataAdapter();
		MySqlDataReader sqlReader, sqlReader2, sqlReader3, sqlReader4, sqlReader5, sqlReader6;
		DataSet dataset = new DataSet();
		
		//Reading Manager data from the database.
		MySqlCommand sqlCmd2 = new MySqlCommand();
		DataTable dt2 = new DataTable();
		//MySqlDataReader sqlReader2;
		
		// variables to hold the data from the hostel table.
		MySqlCommand sqlCmd3 = new MySqlCommand();
		DataTable dt3 = new DataTable();
		//MySqlDataReader sqlReader3;
		
		// variables to hold the data from the room table
		MySqlCommand sqlCmd4 = new MySqlCommand();
		DataTable dt4 = new DataTable();
		//MySqlDataReader sqlReader4;
		
		//variables to hold the data from the payment table
		MySqlCommand sqlCmd5 = new MySqlCommand();
		DataTable dt5 = new DataTable();
		//MySqlDataReader sqlReader5;
		
		//variables to hold the data from the reservation table
		MySqlCommand sqlCmd6 = new MySqlCommand();
		DataTable dt6 = new DataTable();
		//MySqlDataReader sqlReader6;
		
		
		private void loadData(){
			try{
			mysconn.ConnectionString = "server = localhost ; username = root ; password = 210103la ; database = group4db;";
			mysconn.Open();
			sqlCmd.Connection = mysconn;
			sqlCmd.CommandText = "select * from student";
			sqlReader = sqlCmd.ExecuteReader();
			dt.Load(sqlReader);
			sqlReader.Close();
//			mysconn.Close();
			dataGridViewStud.DataSource = dt;
			//MessageBox.Show(dt.ToString());
			
			//Reading the Manager data from data
			sqlCmd2.Connection = mysconn;
			sqlCmd2.CommandText = "select * from manager";
			sqlReader2 = sqlCmd2.ExecuteReader();
			dt2.Load(sqlReader2);
			sqlReader2.Close();
//			mysconn.Close();
			dataGridViewMgr.DataSource = dt2;
			
			//Reading the Hostel data from database.
			sqlCmd3.Connection = mysconn;
			sqlCmd3.CommandText = "select * from hostel";
			sqlReader3 = sqlCmd3.ExecuteReader();
			dt3.Load(sqlReader3);
			sqlReader3.Close();
//			mysconn.Close();
			dataGridViewHost.DataSource = dt3;
			
			//Reading the Room data from database.
			sqlCmd4.Connection = mysconn;
			sqlCmd4.CommandText = "select * from room";
			sqlReader4 = sqlCmd4.ExecuteReader();
			dt4.Load(sqlReader4);
			sqlReader4.Close();
//			mysconn.Close();
			dataGridViewRoom.DataSource = dt4;
			
			// Reading the Payment data from database.
			sqlCmd5.Connection = mysconn;
			sqlCmd5.CommandText = "select * from payment";
			sqlReader5 = sqlCmd5.ExecuteReader();
			dt5.Load(sqlReader5);
			sqlReader5.Close();
			dataGridViewPay.DataSource = dt5;
			
			//Reading the Reservation data from the database into gridview
			sqlCmd6.Connection = mysconn;
			sqlCmd6.CommandText = "select * from reservation";
			sqlReader6 = sqlCmd6.ExecuteReader();
			dt6.Load(sqlReader6);
			sqlReader6.Close();
			mysconn.Close();
			dataGridViewResv.DataSource = dt6;
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,"Message");
			}
			
		}
		
		public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Form1Load(object sender, EventArgs e)
		{
			loadData();
		}
		
		
		void BtnRoSaveClick(object sender, EventArgs e)
		{
			
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = test123 ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlQuery = "insert into group4db.room(RoomID,RoomType,RoomDesc,RoomPrice)" +
					"values('"+tbRoomId.Text+"','"+tbRoomType.Text + "','"+tbRoomDesc.Text +"','"+tbRoomPr.Text + "');";
				
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				sqlReader = sqlCmd.ExecuteReader();
				mysconn.Close();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
		}
		
		void BtnRoDelClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlCmd.CommandText="delete from room where RoomID=@RoomID";
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				mysconn.Close();
				
				foreach(DataGridViewRow item in this.dataGridViewRoom.SelectedRows){
					dataGridViewRoom.Rows.RemoveAt(item.Index);
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
		}
		
		
		void BtnRoUpClick(object sender, EventArgs e)
		{
				try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
					
					MySqlCommand mysqlcmd = new MySqlCommand();
					mysqlcmd.Connection = mysconn;
					
					mysqlcmd.CommandText = "update room set RoomID=@RoomID, RoomType=@RoomType, RoomDesc=@RoomDesc, RoomPrice=@RoomPrice where RoomID=@RoomID";
					
					mysqlcmd.CommandType = CommandType.Text;
					mysqlcmd.Parameters.AddWithValue("@RoomID",tbRoomId.Text);
					mysqlcmd.Parameters.AddWithValue("@RoomType",tbRoomType.Text);
					mysqlcmd.Parameters.AddWithValue("@RoomDesc",tbRoomDesc.Text);
					mysqlcmd.Parameters.AddWithValue("@RoomPrice",tbRoomPr.Text);
					
					mysqlcmd.ExecuteNonQuery();
					mysconn.Close();
					loadData();
					
				}
				catch(Exception ex){
					MessageBox.Show(ex.Message,ex.Source);
				}
			
		}
		
		
		
		void DataGridViewRoomCellClick(object sender, DataGridViewCellEventArgs e)
		{
			try{
				tbRoomId.Text = dataGridViewRoom.SelectedRows[0].Cells[0].Value.ToString();
				tbRoomType.Text = dataGridViewRoom.SelectedRows[0].Cells[1].Value.ToString();
				tbRoomDesc.Text = dataGridViewRoom.SelectedRows[0].Cells[2].Value.ToString();
				tbRoomPr.Text = dataGridViewRoom.SelectedRows[0].Cells[3].Value.ToString();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);
			}
			
		}
		
		void BtnRoClrClick(object sender, EventArgs e)
		{
			tbRoomId.Text = null;
			tbRoomType.Text = null;
			tbRoomDesc.Text = null;
			tbRoomPr.Text = null;			
		}
		
		void BtnMgnSaveClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlQuery = "insert into group4db.manager(MgrID,MgrName,MgrContact,HostelID)" +
					"values('"+tbMgnId.Text+"','"+tbMngName.Text + "','"+tbMngCont.Text +"','"+tbMgnHosteId.Text + "');";
				
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				sqlReader = sqlCmd.ExecuteReader();
				mysconn.Close();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
			
		}
		
		void BtnMgnDeleteClick(object sender, EventArgs e)
		{
			
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlCmd.CommandText="delete from manager where RoomID=@RoomID";
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				mysconn.Close();
				
				foreach(DataGridViewRow item in this.dataGridViewMgr.SelectedRows){
					dataGridViewMgr.Rows.RemoveAt(item.Index);
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
			
		}
		
		void BtnMgnUpadteClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
					
					MySqlCommand mysqlcmd = new MySqlCommand();
					mysqlcmd.Connection = mysconn;
					
					mysqlcmd.CommandText = "update manager set MgrID=@MgrID, MgrName=@MgrName, MgrContact=@MgrContact, HostelID=@HostelID where MgrID=@MgrID";
					
					mysqlcmd.CommandType = CommandType.Text;
					mysqlcmd.Parameters.AddWithValue("@MgrID",tbMgnId.Text);
					mysqlcmd.Parameters.AddWithValue("@MgrName",tbMngName.Text);
					mysqlcmd.Parameters.AddWithValue("@MgrContact",tbMngCont.Text);
					mysqlcmd.Parameters.AddWithValue("@HostelID",tbMgnHosteId.Text);
					
					mysqlcmd.ExecuteNonQuery();
					mysconn.Close();
					loadData();
					
				}
				catch(Exception ex){
					MessageBox.Show(ex.Message,"");
				}
		}
		
		
		
		void BtnMgnClearClick(object sender, EventArgs e)
		{
			tbMgnHosteId.Text = null;
			tbMgnId.Text = null;
			tbMngCont.Text = null;
			tbMngName.Text = null;			
		}
		
		
		
		void DataGridViewMgrCellClick(object sender, DataGridViewCellEventArgs e)
		{
			try{
				tbMgnId.Text = dataGridViewMgr.SelectedRows[0].Cells[0].Value.ToString();
				tbMngCont.Text = dataGridViewMgr.SelectedRows[0].Cells[1].Value.ToString();
				tbMgnHosteId.Text = dataGridViewMgr.SelectedRows[0].Cells[2].Value.ToString();
				tbMngName.Text = dataGridViewMgr.SelectedRows[0].Cells[3].Value.ToString();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,"");
			}
			
			
		}
		
		
		
		void BtnHosSaveClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlQuery = "insert into group4db.hostel(HostelID,HostelName,HostelAdd,RoomID)" +
					"values('"+tbHostID.Text+"','"+tbHostName.Text + "','"+tbHostAd.Text +"','"+tbHostRoId.Text + "');";
				
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				sqlReader = sqlCmd.ExecuteReader();
				mysconn.Close();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
		}
		
		
		
		
		void BtnHosDelClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlCmd.CommandText="delete from hostel where HostelID=@HostelID";
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				mysconn.Close();
				
				foreach(DataGridViewRow item in this.dataGridViewHost.SelectedRows){
					dataGridViewHost.Rows.RemoveAt(item.Index);
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
			
		}
		
		
		
		void BtnHosClrClick(object sender, EventArgs e)
		{
			tbHostID.Text = null;
			tbHostAd.Text = null;
			tbHostName.Text = null;
			tbHostRoId.Text = null;			
		}
		
		
		
		void BtnHosUpdClick(object sender, EventArgs e)
		{
			
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
					
					MySqlCommand mysqlcmd = new MySqlCommand();
					mysqlcmd.Connection = mysconn;
					
					mysqlcmd.CommandText = "update hostel set HostelID=@HostelID, HostelName=@HostelName, HostelAdd=@HostelAdd, RoomID=@RoomID where HostelID=@HostelID";
					
					mysqlcmd.CommandType = CommandType.Text;
					mysqlcmd.Parameters.AddWithValue("@HostelID",tbHostID.Text);
					mysqlcmd.Parameters.AddWithValue("@HostelName",tbHostName.Text);
					mysqlcmd.Parameters.AddWithValue("@HostelAdd",tbHostAd.Text);
					mysqlcmd.Parameters.AddWithValue("@RoomID",tbHostRoId.Text);
					
					mysqlcmd.ExecuteNonQuery();
					mysconn.Close();
					loadData();
					
				}
				catch(Exception ex){
					MessageBox.Show(ex.Message,"");
				}
		}
		
		
		
		
		void DataGridViewHostCellClick(object sender, DataGridViewCellEventArgs e)
		{
			try{
				tbHostID.Text = dataGridViewHost.SelectedRows[0].Cells[0].Value.ToString();
				tbHostName.Text = dataGridViewHost.SelectedRows[0].Cells[1].Value.ToString();
				tbHostAd.Text = dataGridViewHost.SelectedRows[0].Cells[2].Value.ToString();
				tbHostRoId.Text = dataGridViewHost.SelectedRows[0].Cells[3].Value.ToString();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,"");
			}
		}
		
		void BtnPaySaveClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlQuery = "insert into group4db.payment(PaymentID,StudID,ReservID)" +
					"values('"+tbPaymentId.Text+"','"+tbPayStuID.Text + "','"+tbPayResvID.Text +"');";
				
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				sqlReader = sqlCmd.ExecuteReader();
				mysconn.Close();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
			
		}
		
		
		
		void BtnPayDelClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlCmd.CommandText="delete from payment where PaymentID=@PaymentID";
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				mysconn.Close();
				
				foreach(DataGridViewRow item in this.dataGridViewPay.SelectedRows){
					dataGridViewPay.Rows.RemoveAt(item.Index);
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
			
		}
		
		
		
		void BtnPayClrClick(object sender, EventArgs e)
		{
			tbPaymentId.Text = null;
			tbPayStuID.Text = null;
			tbPayResvID.Text = null;			
		}
		
		
		
		void BtnPayUpdClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
					
					MySqlCommand mysqlcmd = new MySqlCommand();
					mysqlcmd.Connection = mysconn;
					
					mysqlcmd.CommandText = "update payment set PaymentID=@PaymentID, StudID=@StudID, ReservID=@ReservID where PaymentID=@PaymentID";
					
					mysqlcmd.CommandType = CommandType.Text;
					mysqlcmd.Parameters.AddWithValue("@PaymentID",tbPaymentId.Text);
					mysqlcmd.Parameters.AddWithValue("@StudID",tbPayStuID.Text);
					mysqlcmd.Parameters.AddWithValue("@ReservID",tbPayResvID.Text);
					mysqlcmd.ExecuteNonQuery();
					mysconn.Close();
					loadData();
					
				}
				catch(Exception ex){
					MessageBox.Show(ex.Message,ex.Source);
				}
		}
		
		
		
		void DataGridViewPayCellClick(object sender, DataGridViewCellEventArgs e)
		{
			try{
			tbPaymentId.Text = dataGridViewPay.SelectedRows[0].Cells[0].Value.ToString();
			tbPayStuID.Text = dataGridViewPay.SelectedRows[0].Cells[1].Value.ToString();
			tbPayResvID.Text = dataGridViewPay.SelectedRows[0].Cells[2].Value.ToString();
			
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);
			}
			
		}
		
		
		
		void BtnResSaveClick(object sender, EventArgs e)
		{
			
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlQuery = "insert into group4db.reservation(ReservID,StudID,HostelID,ReservDate)" +
					"values('"+tbResId.Text+"','"+tbResStuId.Text + "','"+tbResHostId.Text +"','"+tbResDate.Text + "');";
				
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				sqlReader = sqlCmd.ExecuteReader();
				mysconn.Close();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
			
		}
		
		
		
		void BtnReDelClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlCmd.CommandText="delete from reservation where ReservID=@ReservID";
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				mysconn.Close();
				
				foreach(DataGridViewRow item in this.dataGridViewResv.SelectedRows){
					dataGridViewResv.Rows.RemoveAt(item.Index);
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
		}
		
		
		
		void BtnReClrClick(object sender, EventArgs e)
		{
			tbResId.Text = null;
			tbResStuId.Text = null;
			tbResHostId.Text = null;
			tbResDate.Text = null;			
		}
		
		
		
		void BtnReUpdClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
					
					MySqlCommand mysqlcmd = new MySqlCommand();
					mysqlcmd.Connection = mysconn;
					
					mysqlcmd.CommandText = "update reservation set ReservID=@ReservID, StudID=@StudID, HostelID=@HostelID, ReservDate=@ReservDate where ReservID=@ReservID";
					
					mysqlcmd.CommandType = CommandType.Text;
					mysqlcmd.Parameters.AddWithValue("@ReservID",tbResId.Text);
					mysqlcmd.Parameters.AddWithValue("@StudID",tbResStuId.Text);
					mysqlcmd.Parameters.AddWithValue("@HostelID",tbResHostId.Text);
					mysqlcmd.Parameters.AddWithValue("@ReservDate",tbResDate.Text);
					
					mysqlcmd.ExecuteNonQuery();
					mysconn.Close();
					loadData();
					
				}
				catch(Exception ex){
					MessageBox.Show(ex.Message,ex.Source);
				}
		}
		
		
		
		void DataGridViewResvCellClick(object sender, DataGridViewCellEventArgs e)
		{
			try{
				
			tbResId.Text = dataGridViewResv.SelectedRows[0].Cells[0].Value.ToString();
			tbResStuId.Text = dataGridViewResv.SelectedRows[0].Cells[1].Value.ToString();
			tbResHostId.Text = dataGridViewResv.SelectedRows[0].Cells[2].Value.ToString();
			tbResDate.Text = dataGridViewResv.SelectedRows[0].Cells[3].Value.ToString();
			}
			
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);
			}
		}
		
		
		
		void BtnStudSaveClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlQuery = "insert into group4db.student(StudID,StudName,StudAdd,StudPhone,RoomID)" +
					"values('"+tbStdId.Text+"','"+tbStdName.Text + "','"+tbStdAd.Text +"','"+tbStdPhone+"',"+tbStdRoomId+"')";
				
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				sqlReader = sqlCmd.ExecuteReader();
				mysconn.Close();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
			
		}
		
		
		
		void BtnStudDelClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
				
				sqlCmd.CommandText="delete from student where StudentID=@StudnetID";
				sqlCmd = new MySqlCommand(sqlQuery,mysconn);
				mysconn.Close();
				
				foreach(DataGridViewRow item in this.dataGridViewStud.SelectedRows){
					dataGridViewStud.Rows.RemoveAt(item.Index);
				}
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);		
			}
			finally{
				mysconn.Close();
			}
			loadData();
			
		}
		
		void BtnStudClrClick(object sender, EventArgs e)
		{
			tbStdId.Text = null;
			tbStdAd.Text = null;
			tbStdName.Text = null;
			tbStdPhone.Text = null;
			tbStdRoomId.Text = null;			
		}
		
		void BtnStudUpdClick(object sender, EventArgs e)
		{
			try{
				
				mysconn.ConnectionString = "server = localhost ; " +
					"username = root ; " +
					"password = 210103la ; " +
					"database = group4db;";
				
				mysconn.Open();
					
					MySqlCommand mysqlcmd = new MySqlCommand();
					mysqlcmd.Connection = mysconn;
					
					mysqlcmd.CommandText = "update student set StudID=@StudID, StudName=@StudName, StudAdd=@StudAdd, StudPhone=@StudPhone, RoomID=@RoomID where StudID=@StudID";
					
					mysqlcmd.CommandType = CommandType.Text;
					mysqlcmd.Parameters.AddWithValue("@StudID",tbStdId.Text);
					mysqlcmd.Parameters.AddWithValue("@StudName",tbStdName.Text);
					mysqlcmd.Parameters.AddWithValue("@StudAdd",tbStdAd.Text);
					mysqlcmd.Parameters.AddWithValue("@StudPhone",tbStdPhone.Text);
					mysqlcmd.Parameters.AddWithValue("@RoomID",tbStdRoomId.Text);
					
					mysqlcmd.ExecuteNonQuery();
					mysconn.Close();
					loadData();
					
				}
				catch(Exception ex){
					MessageBox.Show(ex.Message, ex.Source);
				}
			
		}
		
		void DataGridViewStudCellClick(object sender, DataGridViewCellEventArgs e)
		{
			try{
				
				tbStdId.Text = dataGridViewStud.SelectedRows[0].Cells[0].Value.ToString();
				tbStdName.Text = dataGridViewStud.SelectedRows[0].Cells[1].Value.ToString();
				tbStdAd.Text = dataGridViewStud.SelectedRows[0].Cells[2].Value.ToString();
				tbStdPhone.Text = dataGridViewStud.SelectedRows[0].Cells[3].Value.ToString();
				tbStdRoomId.Text = dataGridViewStud.SelectedRows[0].Cells[4].Value.ToString();
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message,ex.Source);
			}
		}
		
		
	}
}
