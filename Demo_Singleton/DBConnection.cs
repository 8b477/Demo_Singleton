using System.Data;
using System.Data.SqlClient;

namespace Demo_Singleton
{
    public class DBConnection
    {

        #region Propriétés
        // Chaîne de connexion SQL Server.
        private static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testHash;Integrated Security=True;";

        // Instance unique de la connexion SQL Server.
        private static SqlConnection connection;

        // Instance unique de la classe DBConnection.
        private static DBConnection instance;
        #endregion



        #region Constructeur
        /// <summary>
        /// Constructeur privé pour initialiser la connexion SQL Server.
        /// </summary>
        private DBConnection()
        {
            connection = new SqlConnection(connectionString);
        }
        #endregion



        #region Méthodes
        /// <summary>
        /// Obtient l'instance unique de la classe DBConnection.
        /// </summary>
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnection();
                }
                return instance;
            }
        }


        /// <summary>
        /// Obtient la connexion SQL Server, l'ouvre si elle est fermée.
        /// </summary>
        /// <returns>Une instance de SqlConnection prête à être utilisée.</returns>
        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }


        /// <summary>
        /// Ferme la connexion SQL Server si elle est ouverte.
        /// </summary>
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        } 
        #endregion
    }
}





