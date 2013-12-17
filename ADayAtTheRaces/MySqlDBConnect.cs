﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    class MySqlDBConnect
    {
    private MySqlConnection connection;
    private MySqlDataAdapter dataAdapter;
    private MySqlCommandBuilder commandBuilder;

    //Constructor
    public MySqlDBConnect()
    {
        Initialize();
    }

    //Initialize values
    private void Initialize()
    {

        string connectionString = "datasource=db4free.net;port=3306;username=koczo;password=koczo14";
        connection = new MySqlConnection(connectionString);
        dataAdapter = new MySqlDataAdapter();
    }

    //open connection to database
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            switch (ex.Number)
            {
                case 0:
                    MessageBox.Show("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    MessageBox.Show("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }

    //Close connection
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    public void Test()
    {
      
        if (this.OpenConnection() == true)
        {

            dataAdapter.SelectCommand = new MySqlCommand("select * race.User", connection);
            commandBuilder = new MySqlCommandBuilder(dataAdapter);
            MessageBox.Show("Test ok");
            //close connection
            this.CloseConnection();
        }
    }

    //Insert statement
    public void Insert( string value)
    {
        string query = String.Format("INSERT INTO  `race`.`history` (`description`)VALUES ('{0}');",value);

        //open connection
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
            }
            

            //close connection
            this.CloseConnection();
        }
    }

    //Update statement
    public void Update()
    {
    }

    //Delete statement
    public void Delete()
    {
    }

    //Select statement
    //public List <string> [] Select()
    //{
    //}

    ////Count statement
    //public int Count()
    //{
    //}

    //Backup
    public void Backup()
    {
    }

    //Restore
    public void Restore()
    {
    }
    }
}
