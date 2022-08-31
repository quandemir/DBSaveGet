
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;



namespace DBSaveGet
{
    public class DB
    {

        public MySqlConnection cs = new MySqlConnection("Server = localhost; Database = ogrenci; Uid = root; Pwd = Usmanım; ");
        public void Save(string query, ArrayList al)
        {
            try
            {
            MySqlCommand cmd = new MySqlCommand(query, cs);
            for (int j = 0; j < al.Count; j+=4)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@0", al[j]);
                cmd.Parameters.AddWithValue("@1", al[j + 1]);
                cmd.Parameters.AddWithValue("@2", al[j + 2]);
                cmd.Parameters.AddWithValue("@3", al[j + 3]);
                cs.Open();
                cmd.ExecuteNonQuery();
                cs.Close();
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine("bir sorun var" + ex.Message);
                Console.ReadLine();
            }
           
        }


        public static DataTable GetDataTableWithParams(string query, ArrayList al)
        {
          
            MySqlConnection cnn = new MySqlConnection("Server = localhost; Database = ogrenci; Uid = root; Pwd = Usmanım; ");
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            for (int j = 0; j < al.Count; j++)
            {
                cmd.Parameters.AddWithValue("@" + j.ToString(), al[j]);
            }
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }



       
        public static ArrayList GetClassWithNoParam(string query) 
        {
            MySqlConnection cnn = new MySqlConnection("Server = localhost; Database = ogrenci; Uid = root; Pwd = Usmanım; ");

            MySqlDataAdapter adp = new MySqlDataAdapter(query, cnn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            ArrayList al= new ArrayList();
            al.Clear();
            for (int j = 0; j < dt.Rows.Count ; j++)
            {
                for (int i=0;i<5;i++) {
                    al.Add(dt.Rows[j][i]);
                }
            }
            return al;
        }
    }
}
