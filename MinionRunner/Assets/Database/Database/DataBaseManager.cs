using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataBaseManager : MonoBehaviour {

    public static bool notInDB = false;
    public static bool notCorrect = false;
    public GameObject notInDBText;
    public GameObject notCorrectText;

    private static string connectionString;

    void Start() 
	{
        connectionString = "URI=file:" + Application.dataPath + "/StudentDB.s3db";
		CreateTable ();
    }
		
    void Update()
    {
        if (notCorrect == true)
            notCorrectText.SetActive(true);
        else notCorrectText.SetActive(false);

        if (notInDB == true)
            notInDBText.SetActive(true);
        else notInDBText.SetActive(false);
    }
		
    private void CreateTable()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("CREATE TABLE if not exists StudentPI (Email TEXT PRIMARY KEY NOT NULL  UNIQUE , Password TEXT NOT NULL, Username TEXT NOT NULL, FirstName TEXT NOT NULL, LastName TEXT NOT NULL)");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
		using (IDbConnection dbConnection = new SqliteConnection(connectionString))
		{
			dbConnection.Open();
			using (IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				string sqlQuery = String.Format("CREATE TABLE if not exists StudentRecords (Email TEXT  NOT NULL, GivenFraction TEXT  NOT NULL, EnteredFraction TEXT  NOT NULL, EnteredReducedFraction TEXT  NOT NULL, Success BOOLEAN  NOT NULL)");
				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar();
				dbConnection.Close();
			}
		}
    }
		
    private static void InsertStudent(string email, string password, string username, string firstName, string lastName, string level)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO StudentPI (Email,Password,Username,FirstName,LastName) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", email, password, username, firstName, lastName);
                dbCmd.CommandText = sqlQuery; 
                dbCmd.ExecuteScalar(); 
                dbConnection.Close();

            }
        }
        SceneManager.LoadScene(level);
    }

    private static void GetStudent(string email, string password, string level)
    {
        string e = null;
        string p = null;
        string u = null;
        string f = null;
        string l = null;
        int ok = 0;

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM StudentPI";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
					while (reader.Read())
                    {
                        e = reader.GetString(0);
                        p = reader.GetString(1);
                        u = reader.GetString(2);
                        f = reader.GetString(3);
                        l = reader.GetString(4);

                        if (e == email && p == password)
                        {
                            ok = 1;
                            break;
                        }
                    }

                    if (ok == 1)
                    {
                        UserClass.player.email = e;
                        UserClass.player.firstName = f;
                        UserClass.player.lastName = l;
                        UserClass.player.userId = u;
                        allowLogin(email, level);
                    }
                    else if ((e == email && p != password) || (e != email && p == password))
                        denyLogin();
                    else requireRegister();
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

    }
    static void allowLogin(string email, string level)
    {
        /////// ERROR: Database is Locked 
        /*using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO StudentLoginRegister (Email) VALUES(\"{0}\")", email);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }*/
        /////////////////////////////
        
        SceneManager.LoadScene(level);
    }
    static void denyLogin()
    {
        notCorrect = true;
    }
    static void requireRegister()
    {
        notInDB = true;
    }
		
    private static void DeleteStudent(string email)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM StudentPI WHERE Email = \"{0}\"", email);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    private static void InsertStudentRecord(string givenFraction, string enteredFraction, string enteredRFraction, bool success)
    {
        string email = UserClass.player.email;

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO StudentRecords (Email,GivenFraction,EnteredFraction,EnteredReducedFraction,Success) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", email, givenFraction, enteredFraction, enteredRFraction, success);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    public static void registerStudent(string email, string password, string username, string firstName, string lastName, string level)
    {
        InsertStudent(email, password, username, firstName, lastName, level);
    }

    public static void loginStudent(string email, string password, string level)
    {
        GetStudent(email, password, level);
    }

    public static void deleteStudent(string email)
    {
        DeleteStudent(email);
    }

    public static void writeSuccess(string givenFraction, string enteredFraction, string enteredRFraction, bool success)
    {
        InsertStudentRecord(givenFraction, enteredFraction, enteredRFraction, success);
    }
}