/*
 * Created by SharpDevelop.
 * User: GENIUS
 * Date: 8/27/2022
 * Time: 8:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Group4Database_Projct
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class SplashScreen : Form
	{
		public SplashScreen()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			panel2.Width += 3;
			if(panel2.Width >= 594){
				timer1.Stop();
				Form1 frm1 = new Form1();
				frm1.Show();
				this.Hide();
			}
		}
	}
}
