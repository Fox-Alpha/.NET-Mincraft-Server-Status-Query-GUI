/*
 * Erstellt mit SharpDevelop.
 * Benutzer: buck
 * Datum: 23.11.2015
 * Zeit: 11:19
 * 
 */
using System;
using System.Windows.Forms;

namespace Mincraft_Server_Status_Query_GUI
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
