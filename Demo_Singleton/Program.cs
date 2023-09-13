#region using
using System.Data.SqlClient;

using Demo_Singleton;
#endregion

#region Test
// Obtenir l'instance unique du Singleton
Singleton singleton1 = Singleton.GetInstance();
Singleton singleton2 = Singleton.GetInstance();

// Vérifier si les deux instances sont identiques
bool areSameInstance = ReferenceEquals(singleton1, singleton2);

Console.WriteLine($"Les deux instances sont-elles identiques ? {areSameInstance}");


#region ReferenceEquals ? c'est quoi ?
/*
    - Méthode statique fournie par la classe Object.

    - Elle est utilisée pour comparer deux références d'objets
        et déterminer si elles pointent vers la même instance en mémoire. 

    - public static bool ReferenceEquals(object objA, object objB);

        objA : La première référence d'objet à comparer.
        objB : La deuxième référence d'objet à comparer.

        CONCLUSION :
        La méthode renvoie true si les deux références pointent vers la même instance d'objet
*/
#endregion

#endregion



#region Test avec une DB
// Obtenez l'instance de la connexion
DBConnection dbConnection = DBConnection.Instance;
SqlConnection connection = dbConnection.GetConnection();

// Utilisez la connexion pour effectuer une opération SQL
// Par exemple, une requête de sélection
string query = "SELECT * FROM Users";
SqlCommand command = new SqlCommand(query, connection);

// Exécutez la requête et traitez les résultats ici...


// Fermez la connexion lorsque vous avez terminé
dbConnection.CloseConnection();
#endregion