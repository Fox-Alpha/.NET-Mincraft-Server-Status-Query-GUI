/*
 * Erstellt mit SharpDevelop.
 * Benutzer: buck
 * Datum: 23.11.2015
 * Zeit: 12:01
 * 
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Mincraft_Server_Status_Query_GUI.Klassen
{
	/// <summary>
	/// Description of ClassServerStatus.
	/// </summary>
	public class ClassServerStatus
	{
		Dictionary<string, string> serverdata;
		bool isIPAdress = false;
		
		string _hostname;
		static string pwd = "BvLzB2jAeflOO3n8hvr66dUW&1";
		static private byte[] m_buffer;
		
		public string hostname {
			get { return _hostname; }
			set {
				if (Regex.IsMatch(value, @"\b(?:\d{1,3}\.){3}\d{1,3}\b")) {
					Debug.WriteLine("Hostname entspricht einer IP Adresse");
					isIPAdress = true;
				}				
				_hostname = value; 
			}
		}
		
		int _port;
		
		public int port {
			get { return _port; }
			set { if(value > 0 && value < 65556)
					_port = value;
				else
					_port = 0;
			}
		}
		
		Socket serversocket;
		
		public ClassServerStatus()
		{
			hostname = "192.168.21.4";
			serverdata = new Dictionary<string, string>();
			
			serverdata.Add("hostname", "");
			serverdata.Add("version", "");
			serverdata.Add("protocol", "");
			serverdata.Add("players", "");
			serverdata.Add("maxplayers", "");
			serverdata.Add("motd", "");
			serverdata.Add("motd_raw", "");
			serverdata.Add("favicon", "");
			serverdata.Add("ping", "");
			
			m_buffer = new byte[1024];
		}
		
		public void getStatus()
		{
//			serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//			Socket.ConnectAsync(SocketType.Stream, ProtocolType.Tcp, null);
			Connect();
		}
		
		public void getStatus(string host, int port)
		{
			
		}
		
	   	private static void Connect(string ipAdd="127.0.0.1")
	    {
			Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			SocketAsyncEventArgs e = new SocketAsyncEventArgs();
			IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(ipAdd), 12489);
			e.RemoteEndPoint = ipEnd;
			e.UserToken = s;
			e.Completed += new EventHandler<SocketAsyncEventArgs>(e_Completed);
		
			
			Debug.WriteLine("Trying to connect to : " + ipEnd);
			
			
			
			s.ConnectAsync(e);
//			s.Connect(ipEnd);
			
//			if(s.Connected)
//			{
//				NetworkStream ns = new NetworkStream(s);
//				StreamReader sr = new StreamReader (ns);
//				StreamWriter sw = new StreamWriter(ns);
//				sw.Write("{0}&CLIENTEVERSION\n", pwd);
//				string text;
				
//				if ((text = sr.ReadLine()).Length > 0) {
//					Debug.WriteLine("Daten vom NSClient: {0}", text);
//				}

//				s.Shutdown(SocketShutdown.Both);
				
//				sw.Close();
//				s.Close();
//				s.Disconnect(false);
//			}
//				Debug.WriteLine("Verbindung wartend");
//			}
//			else
//				Debug.WriteLine("Verbindung gescheitert");
	    }
	   	
	    private static void  e_Completed(object sender, SocketAsyncEventArgs e)
	    {
//	        if (e.ConnectSocket != null)
//	        {
//	        	if (e.ConnectSocket.Connected) {
//	        		e.ConnectSocket.Send(StringToByteArray(pwd)
//	        	}
//	            StreamReader sr = new StreamReader(new NetworkStream(e.ConnectSocket));
//	            Debug.WriteLine("Connection Established : " + e.RemoteEndPoint + " PC NAME : " + sr.ReadLine());
//	        }
//	        else
//	        {
//	            Console.WriteLine("Connection Failed : " + e.RemoteEndPoint);
//	        }
			switch (e.LastOperation)
	        {
	            case SocketAsyncOperation.Receive:
//	                ProcessReceive(e);
					Debug.WriteLine("Datenempfang ...", "e_Completed()");
	                break;
	            case SocketAsyncOperation.Send:
//	                ProcessSend(e);
	                Debug.WriteLine("Datensenden ...", "e_Completed()");
		            StreamReader sr = new StreamReader(new NetworkStream(e.ConnectSocket));
		            Debug.WriteLine("Connection Established : " + e.RemoteEndPoint + " PC NAME : " + sr.ReadLine());
	                break;
	            case SocketAsyncOperation.Connect:
	                Debug.WriteLine("Verbindung hergestellt", "e_Completed()");
		    		StringToByteArray(pwd).CopyTo(m_buffer, 0);
//		    		StreamWriter sw = new StreamWriter(new NetworkStream(e.ConnectSocket));
//					sw.Write("{0}&1\n", pwd);
		    		e.SetBuffer(m_buffer, e.Offset, StringToByteArray(pwd).Length);
		    		e.ConnectSocket.SendAsync(e);
	                break;
//	            default:
//	                throw new ArgumentException("The last operation completed on the socket was not a receive or send");
	        }       

	    }
	    
	    private static void ProcessReceive(SocketAsyncEventArgs e)
	    {
//	    	Socket token = (Socket)e.UserToken;
//	    	if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
//        	{
//	    		StringToByteArray(pwd).CopyTo(m_buffer, 0);
//	    		e.SetBuffer(m_buffer, e.Offset, StringToByteArray(pwd).Length);
//	    	}
	    
	    	
	    }
	    
	    private static void ProcessSend(SocketAsyncEventArgs e)
	    {
	    	
	    }

		/// <summary>
		/// Wandelt einen String in ein Byte Array um
		/// </summary>
		/// <param name="str">Der zu konvertierende String</param>
		/// <returns>Bytearray</returns>
		private static byte[] StringToByteArray(string str)
		{
			System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
			return enc.GetBytes(str);
		}
		
		private static string ByteArrayToString(byte[] arr)
		{
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			//ASCIIEncoding
			return enc.GetString(arr);
		}
	}
}
