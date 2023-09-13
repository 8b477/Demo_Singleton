namespace Demo_Singleton
{
    public class Singleton
    {
        // Étape 1 :
        // Déclarer une variable privée statique pour stocker l'instance unique
        #region Propriétés
        private static Singleton? instance; 
        #endregion

        // Étape 2 :
        // Rendre le constructeur privé pour empêcher la création d'instances
        #region Constructeur
        private Singleton() { } 
        #endregion

        // Étape 3 :
        // Créer une méthode publique statique pour obtenir l'instance unique
        #region Méthodes
        public static Singleton GetInstance()
        {
            // Si l'instance n'a pas été créée, la créer maintenant
            if (instance == null)
            {
                return instance = new Singleton();
            }

            return instance;
        } 
        #endregion
    }
}
