# <h1 align="center">EXPLICATION, PATERN DU SINGE BRETON</h1>
</br>

-----------------------------------------
</br>

# Sommaire :
### [Explication du concept.](#expli)
### [Quand l'utilisé ?](#quand)
### [Implémentation step by step (basic).](#basic)
### [Implémentation step by step (DB).](#db)
</br>

-----------------------------------------
</br>

# En une phrase c'est quoi ??
</br>
<a name= "expli">C'est une garantit qu'une classe n'a qu'une seule instance et fournit un point d'accès global à cette instance **UNIQUE** dans tout notre programme.</a>

</br></br>

-----------------------------------------
</br>

# Quand l'utilisé ??

</br>

- Pour une connexions de base de données.
- <a name= "quand">Pour une gestion de fichiers de configuration.</a>

</br></br>

-----------------------------------------

</br>

# Implémentation de base :

</br>

- Étape (1) :
  
```C#
    public class Singleton
    {
        private static Singleton instance;
    }
```
  Créer une classe et déclarer une variable privée statique pour stocker l'instance qui sera unique.
</br>
</br>
</br>
</br>
-<a name= "basic"> Étape (2) :</a>
  
```C#
 public class Singleton
    {
        private static Singleton? instance;

        private Singleton(){}
    }
```

Rendre le constructeur privé pour empêcher la création d'instances !
</br>
</br>
</br>
</br>
- Étape (3) :
  
```C#
  public class Singleton
    {
        private static Singleton? instance;

        private Singleton(){}

        public static Singleton GetInstance()
        {
            // Si l'instance n'a pas été créée, la créer maintenant
            if (instance == null)
            {
                return instance = new Singleton();
            }

            return instance;
        }
    }
```
Créer la méthode GetInstance() en public static pour obtenir l'instance unique.

</br></br>

-------------------------------------------

</br>

# Implémentation de base pour une DB :
*( Dans l'exemple j'utilise SQL Server mais rien ne vous empêche d'en utiliser d'autre )*
</br>
</br>
- Étape (1) :
  
```C#
   public class DBConnection
    {
        // Chaîne de connexion SQL Server.
        private static readonly string connectionString = "ta chaine de connexion";

        // Instance unique de la connexion SQL Server.
        private static SqlConnection connection;

        // Instance unique de la classe DBConnection.
        private static DBConnection instance;
```

Création des propriétés.
</br>
</br>
</br>
</br>
  
-<a name= "db"> Étape (2) :</a> 


```C#
 private DBConnection()
        {
            connection = new SqlConnection(connectionString);
        }
```

Création de mon constructeur en priver pour respecter le patern !
</br>
</br>
</br>
</br>
- Étape (3) :

```C#
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


public SqlConnection GetConnection()
{
    if (connection.State == ConnectionState.Closed)
    {
        connection.Open();
    }
    return connection;
}


public void CloseConnection()
{
    if (connection.State == ConnectionState.Open)
    {
        connection.Close();
    }
} 
```

Création de nos méthodes.
</br>
</br>
</br>
</br>
- Votre projet devrait ressembler à ça :

```C#
public class DBConnection
    {
        private static readonly string connectionString = "chaine de connexion";
        private static SqlConnection connection;
        private static DBConnection instance;


        private DBConnection()
        {
            connection = new SqlConnection(connectionString);
        }


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


        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }


        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        } 
    }
```

