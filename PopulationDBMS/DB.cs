//Cong Liu, Zalak Patel, Jyoti Mittal, Penghsuo Liu
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PopulationDBMS
{
    internal class DB
    {
        #region SQL commands
        const string CONNECTION_STRING = @"Server=.\PROG8080;Database=Population;Trusted_Connection=True;";
        const string INSERT_COMMAND = "INSERT INTO City (City, Population) VALUES (@CITY, @POPULATION)";
        const string SELECT_COMMAND = "SELECT City, Population FROM City";
        const string UPDATE_COMMAND = "UPDATE City SET City = @CITY, Population = @POPULATION WHERE City = @CITY";
        const string DELETE_COMMAND = "DELETE FROM City WHERE City = @CITY";
        #endregion

        private readonly SqlConnection conn;

        private static DB db;
        public static DB Instance { get { db ??= new DB(); return db; } }

        private DB()
        {
            conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
        }

        public bool Insert(Population population)
        {
            using SqlCommand cmd = new SqlCommand(INSERT_COMMAND, conn);
            cmd.Parameters.AddWithValue("@CITY", population.City);
            cmd.Parameters.AddWithValue("@POPULATION", population.PopulationNum);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Population population)
        {
            using SqlCommand cmd = new SqlCommand(UPDATE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@CITY", population.City);
            cmd.Parameters.AddWithValue("@POPULATION", population.PopulationNum);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(Population population)
        {
            using SqlCommand cmd = new SqlCommand(DELETE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@CITY", population.City);
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<Population> Get()
        {
            List<Population> populations = new List<Population>();

            using SqlCommand cmd = new SqlCommand(SELECT_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Population p = new Population
                {
                    IsNew = false,
                    City = dr.GetString(dr.GetOrdinal("City")),
                    PopulationNum = dr.GetInt32(dr.GetOrdinal("Population"))
                };
                populations.Add(p);
            }
            dr.Close();

            return populations;
        }
    }
}
