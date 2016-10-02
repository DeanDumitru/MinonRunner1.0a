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

    /// <summary>
    /// The connection string, this string tells the path to the databas
    /// </summary>
    private static string connectionString;

    // Use this for initialization
    void Start() {

        //Sets the connectionstring as the default datapath inside the assetfolder
        connectionString = "URI=file:" + Application.dataPath + "/StudentDB.s3db";

        //Creates the database if it doesn't exist
        CreateTable();

    }

    // Update is called once per frame
    void Update()
    {
        if (notCorrect == true)
            notCorrectText.SetActive(true);
        else notCorrectText.SetActive(false);

        if (notInDB == true)
            notInDBText.SetActive(true);
        else notInDBText.SetActive(false);
    }

    /// <summary>
    /// Creates a table if it doesn't exist
    /// </summary>
    private void CreateTable()
    {
        //Creates the connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //Opens the connection
            dbConnection.Open();

            //Creates a command so that we can execute it on the database
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Create the query 
                string sqlQuery = String.Format("CREATE TABLE if not exists StudentPI (Email TEXT PRIMARY KEY NOT NULL  UNIQUE , Password TEXT NOT NULL, Username TEXT NOT NULL, FirstName TEXT NOT NULL, LastName TEXT NOT NULL)");

                //Gives the sqlQuery to the command
                dbCmd.CommandText = sqlQuery;

                //Executes the commnad
                dbCmd.ExecuteScalar();

                //Closes the connections
                dbConnection.Close();
            }
        }
    }

    /// <summary>
    /// Inserts  a new student into the database
    /// </summary>
    private static void InsertStudent(string email, string password, string username, string firstName, string lastName, string level)
    {

        //Creates a database connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //Opens the connection
            dbConnection.Open();

            //Creates a database comment
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Creates a query for inserting the new score
                string sqlQuery = String.Format("INSERT INTO StudentPI (Email,Password,Username,FirstName,LastName) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", email, password, username, firstName, lastName);

                dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
                dbCmd.ExecuteScalar(); //Executes the query
                dbConnection.Close();//Closes the connetcion

            }
        }

        //loads the game after register
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

        //Creates a database connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //Opens the connection
            dbConnection.Open();

            //Creates a database comment
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Selects everything from the highscores
                string sqlQuery = "SELECT * FROM StudentPI";

                //feeds the query to the command
                dbCmd.CommandText = sqlQuery;

                //Creates a reader and executes it so that we can load the highscores
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read()) //As long as we have something to read
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
                        UserClass.player.firstName = f;
                        UserClass.player.lastName = l;
                        UserClass.player.userId = u;
                        allowLogin(email, level);
                    }
                    else if ((e == email && p != password) || (e != email && p == password))
                        denyLogin();
                    else requireRegister();

                    //Closes the connection
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

    }
    static void allowLogin(string email, string level)
    {
        /////// ERROR: Database is Locked
        /*/Creates a database connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //Opens the connection
            dbConnection.Open();

            //Creates a database comment
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Creates a query for inserting the new score
                string sqlQuery = String.Format("INSERT INTO StudentLoginRegister (Email) VALUES(\"{0}\")", email);

                dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
                dbCmd.ExecuteScalar(); //Executes the query
                dbConnection.Close();//Closes the connetcion

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


    /// <summary>
    /// Deletes a specific entry in the database
    /// </summary>
    /// <param name="id">The scores database id</param>
    private static void DeleteStudent(string email)
    {
        //Creates a database connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open(); //Opens the connection

            //Creates a database command
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Creates a query
                string sqlQuery = String.Format("DELETE FROM StudentPI WHERE Email = \"{0}\"", email);

                //Feeds the query to the command
                dbCmd.CommandText = sqlQuery;

                //Executes the command
                dbCmd.ExecuteScalar();

                //Closes the connection
                dbConnection.Close();
            }
        }
    }

    private static void InsertStudentRecord(string givenFraction, string enteredFraction, string enteredRFraction, bool success)
    {
        string email = UserClass.player.email;

        //Creates a database connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //Opens the connection
            dbConnection.Open();

            //Creates a database comment
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Creates a query for inserting the new score
                string sqlQuery = String.Format("INSERT INTO StudentRecords (Email,GivenFraction,EnteredFraction,EnteredReducedFraction,Success) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", email, givenFraction, enteredFraction, enteredRFraction, success);

                dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
                dbCmd.ExecuteScalar(); //Executes the query
                dbConnection.Close();//Closes the connetcion

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