using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using MySql.Data.MySqlClient; 
using TGModels;
using TGUtility;

namespace TGDataBaseManager
{
	public class DBManager
	{
		public static string connectionString = @"server=localhost;userid=root;password=root;database=IranianCharityDB;Charset=utf8";
		public static MySqlConnection connection = null;
		public static MySqlDataReader dataReader = null;
		public static MySqlTransaction Transaction = null;

		// Marked
		public static bool CheckIfAlreadySignedUp(string userId, string table, string field)
		{
			bool val = false;
			if (table.Equals("AlwaysInvitationTableV1") || table.Equals("NonAlwaysInvitationTableV1"))
				table = "InvUserTableV1";

			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();
				string stm = "SELECT " + field + " AS FIELD FROM " + table + " WHERE UserIdentifier=" + userId;
				MySqlCommand cmd = new MySqlCommand(stm, connection);
				dataReader = cmd.ExecuteReader();
				Console.WriteLine("Query: "+stm);

				if (!dataReader.HasRows)
				{
					val = false;
				}
				else
				{
					dataReader.Read();
					string lev = dataReader["FIELD"].ToString();
					if (lev.Length != 0)
					{
						if (lev.Equals("YES"))
							val = true;
						else
							val = false;
					}
					else
					{
						val = false;
					}
				}

			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error: {0}",  ex.ToString());
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		// Marked
		public static bool CheckIfUserExistsInInvUserTable(string userId)
		{
			bool val = false;
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();
				string stm = "SELECT Level AS FIELD FROM InvUserTableV1 WHERE UserIdentifier=" + userId;
				MySqlCommand cmd = new MySqlCommand(stm, connection);
				dataReader = cmd.ExecuteReader();
				Console.WriteLine("Query: "+stm);

				if (!dataReader.HasRows)
				{
					val = false;
				}
				else
				{
					dataReader.Read();
					string lev = dataReader["FIELD"].ToString();
					if (lev.Length != 0)
					{
						if (lev.Equals("1"))
							val = true;
						else
							val = false;
					}
					else
					{
						val = false;
					}
				}

			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error: {0}",  ex.ToString());
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		public static bool CheckIfAlreadySignedUpInSenders(string userId)
		{
			bool val = false;
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();
				string stm = "SELECT Level AS LEVEL FROM SndUserTableV1 WHERE UserIdentifier=" + userId;
				MySqlCommand cmd = new MySqlCommand(stm, connection);
				dataReader = cmd.ExecuteReader();
				Console.WriteLine("Query: "+stm);

				if (!dataReader.HasRows)
				{
					val = false;
				}
				else
				{
					dataReader.Read();
					string lev = dataReader["LEVEL"].ToString();
					if (lev.Length != 0)
					{
						if (lev.Equals("1"))
							val = true;
						else
							val = false;
					}
					else
					{
						val = false;
					}
				}

			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error: {0}",  ex.ToString());
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		// Marked
		public static bool CheckIfUserExistsInInteractTable(string userId)
		{
			bool val = false;
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();
				string stm = "SELECT UserIdentifier AS FIELD FROM InteractedUsersTableV1 WHERE UserIdentifier=" + userId;
				MySqlCommand cmd = new MySqlCommand(stm, connection);
				dataReader = cmd.ExecuteReader();
				Console.WriteLine("Query: "+stm);

				if (!dataReader.HasRows)
				{
					val = false;
				}
				else
				{
					dataReader.Read();
					string lev = dataReader["FIELD"].ToString();
					if (lev.Length != 0)
					{
						val = true;
					}
					else
					{
						val = false;
					}
				}

			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error: {0}",  ex.ToString());
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		public static bool InsertUserToInteractTable(string userId)
		{
			bool val = false;
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();
				
				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = connection;

				cmd.CommandText = "INSERT INTO InteractedUsersTableV1(UserIdentifier) VALUES(@UserIdentifier)";
				cmd.Prepare();

				cmd.Parameters.AddWithValue("@UserIdentifier", userId);
				
				cmd.ExecuteNonQuery();
				val = true;
			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error Creating User: {0}",  ex.ToString());
				val = false;
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		// MArked
		public static bool AddUserToAlwaysInvGroup(string userId, string field)
		{
			bool val = false;
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();

				MySqlCommand cmd1 = new MySqlCommand();
				cmd1.Connection = connection;

				string minQuery = field +"=\""+"YES"+"\"";
				string query = "UPDATE InvUserTableV1 SET "+ minQuery +" WHERE UserIdentifier=" + userId;
				cmd1.CommandText = query;
				cmd1.ExecuteNonQuery();
				val = true;
			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error While Updating: {0}",  ex.ToString());
				val = false;
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		// Marked
		public static bool AddUserToAnotherGroup(string userId, string field)
		{
			bool val = false;
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();

				MySqlCommand cmd1 = new MySqlCommand();
				cmd1.Connection = connection;

				string minQuery = field +"=\""+"YES"+"\"";
				string query = "UPDATE InvUserTableV1 SET "+ minQuery +" WHERE UserIdentifier=" + userId;
				cmd1.CommandText = query;
				cmd1.ExecuteNonQuery();
				val = true;
			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error While Updating: {0}",  ex.ToString());
				val = false;
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		// Marked
		public static bool InsertUserToInvitationTable(string userId, string firstname, string lastname, string phoneNumber, string courseDegree, string timep)
		{
			bool val = false;
			try
			{
				bool exists = CheckIfUserExistsInDB(userId, "InvitationTableV1");
				if (exists)
				{
					val = false;
					return val;
				}
				connection = new MySqlConnection(connectionString);
				connection.Open();
				
				MySqlCommand cmd1 = new MySqlCommand();
				cmd1.Connection = connection;

				cmd1.CommandText = "INSERT INTO InvUserTableV1(UserIdentifier , Firstname, Lastname, City, PhoneNumber, CourseDegree, TimeP, Level, IAG, CG, PSG, DG, KW, PR, EXCV, EXMD, EXPS, EXSP, EXJC, EXTC, EXOT, FM, MD, IT, MG) VALUES(@UserIdentifier, @Firstname, @Lastname, @City, @PhoneNumber, @CourseDegree, @TimeP, @Level, @IAG, @CG, @PSG, @DG, @KW, @PR, @EXCV, @EXMD, @EXPS, @EXSP, @EXJC, @EXTC, @EXOT, @FM, @MD, @IT, @MG)";
				cmd1.Prepare();

				cmd1.Parameters.AddWithValue("@UserIdentifier", userId);
				cmd1.Parameters.AddWithValue("@Firstname", firstname);
				cmd1.Parameters.AddWithValue("@Lastname", lastname);
				cmd1.Parameters.AddWithValue("@City", "None");
				cmd1.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
				cmd1.Parameters.AddWithValue("@CourseDegree", courseDegree);
				cmd1.Parameters.AddWithValue("@TimeP", timep);
				cmd1.Parameters.AddWithValue("@Level", "NO");
				cmd1.Parameters.AddWithValue("@IAG", "NO");
				cmd1.Parameters.AddWithValue("@CG", "NO");
				cmd1.Parameters.AddWithValue("@PSG", "NO");
				cmd1.Parameters.AddWithValue("@DG", "NO");
				cmd1.Parameters.AddWithValue("@KW", "NO");
				cmd1.Parameters.AddWithValue("@PR", "NO");
				cmd1.Parameters.AddWithValue("@EXCV", "NO");
				cmd1.Parameters.AddWithValue("@EXMD", "NO");
				cmd1.Parameters.AddWithValue("@EXPS", "NO");
				cmd1.Parameters.AddWithValue("@EXSP", "NO");
				cmd1.Parameters.AddWithValue("@EXJC", "NO");
				cmd1.Parameters.AddWithValue("@EXTC", "NO");
				cmd1.Parameters.AddWithValue("@EXOT", "NO");
				cmd1.Parameters.AddWithValue("@FM", "NO");
				cmd1.Parameters.AddWithValue("@MD", "NO");
				cmd1.Parameters.AddWithValue("@IT", "NO");
				cmd1.Parameters.AddWithValue("@MG", "NO");

				cmd1.ExecuteNonQuery();
				val = true;
			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error Creating User: {0}",  ex.ToString());
				val = false;
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		// Marked
		public static bool InsertUserToSendersTable(string userId, string firstname, string lastname, string phoneNumber, string fullAddress, string additionalDiscription)
		{
			bool val = false;
			try
			{
				bool exists = CheckIfUserExistsInDB(userId, "SndUserTableV1");
				if (exists)
				{
					val = false;
					return val;
				}
				connection = new MySqlConnection(connectionString);
				connection.Open();
				
				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = connection;

				cmd.CommandText = "INSERT INTO SndUserTableV1(UserIdentifier , Firstname, Lastname, City, PhoneNumber, FullAddress, AdditionalDescription, Level) VALUES(@UserIdentifier, @Firstname, @Lastname, @City, @PhoneNumber, @FullAddress, @AdditionalDescription, @Level)";
				cmd.Prepare();

				cmd.Parameters.AddWithValue("@UserIdentifier", userId);
				cmd.Parameters.AddWithValue("@Firstname", firstname);
				cmd.Parameters.AddWithValue("@Lastname", lastname);
				cmd.Parameters.AddWithValue("@City", "None");
				cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
				cmd.Parameters.AddWithValue("@FullAddress", fullAddress);
				cmd.Parameters.AddWithValue("@AdditionalDescription", additionalDiscription);
				cmd.Parameters.AddWithValue("@Level", "0");
				
				cmd.ExecuteNonQuery();
				val = true;
			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error Creating User: {0}",  ex.ToString());
				val = false;
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		//Marked
		public static bool SetUserCity(string userId, string city,string table)
		{
			bool val = false;
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();

				MySqlCommand cmd1 = new MySqlCommand();
				cmd1.Connection = connection;

				string minQuery = "City" +"=\""+city+"\""+" , Level=1";
				string query = "UPDATE "+table+" SET "+ minQuery +" WHERE UserIdentifier=" + userId;
				cmd1.CommandText = query;
				cmd1.ExecuteNonQuery();
				val = true;
			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error While Updating: {0}",  ex.ToString());
				val = false;
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		// Marked
		public static bool CheckIfUserExistsInDB(string userId, string table)
		{
			bool val = false;
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();
				string stm = "SELECT UserIdentifier AS UID FROM "+table+" WHERE UserIdentifier=" + userId;
				MySqlCommand cmd = new MySqlCommand(stm, connection);
				dataReader = cmd.ExecuteReader();
				Console.WriteLine("Query: "+stm);

				if (!dataReader.HasRows)
				{
					val = false;
				}
				else
				{
					dataReader.Read();
					string lev = dataReader["UID"].ToString();
					if (lev.Length != 0)
					{
						if (lev.Equals(userId))
							val = true;
						else
							val = false;
					}
					else
					{
						val = false;
					}
				}

			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error: {0}",  ex.ToString());
			}
			finally
			{
				if (dataReader != null)
				dataReader.Close();

				if (connection != null)
				connection.Close();
			}
			return val;
		}

		public static List<string> TehranCorporations()
		{
			try
			{
				connection = new MySqlConnection(connectionString);
				connection.Open();
				string stm = "SELECT UserIdentifier FROM InvUserTableV1 WHERE City="+"\"Tehran\"";
				MySqlCommand cmd = new MySqlCommand(stm, connection);
				dataReader = cmd.ExecuteReader();

				List<string> list = new List<string>();
				while (dataReader.Read())
				{
					list.Add(dataReader.GetString(0));
				}
				return list;
			}
			catch (MySqlException ex)
			{
				Console.WriteLine("Error: {0}",  ex.ToString());
				return null;
			}
			finally 
			{
				if (dataReader != null) 
					dataReader.Close();

				if (connection != null)
					connection.Close();
			}
			return null;
		}
	}
}
