/*
 * Erstellt mit SharpDevelop.
 * Benutzer: buck
 * Datum: 23.11.2015
 * Zeit: 11:19
 * 
 */
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Mincraft_Server_Status_Query_GUI.Klassen;

namespace Mincraft_Server_Status_Query_GUI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		ClassServerStatus server;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			server = new ClassServerStatus();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void button1_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textBox1.Text)) {
				server.hostname = textBox1.Text;
			}
			int port = 0; 
			if (!int.TryParse(textBox2.Text, out port)) {
				server.port = port;
				Debug.WriteLine("Ungültiger Port");
			}
			server.getStatus();
		}
	}
}
