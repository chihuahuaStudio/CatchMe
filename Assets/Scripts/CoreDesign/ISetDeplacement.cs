using UnityEngine;

namespace CoreDesign
{
    /// <summary>
    /// Cette interface gere les parametre d'arret, depart et pause des personnages
    /// </summary>
    public interface ISetDeplacement 
    {
        /// <summary>
        /// Cette methode configure le depart du personnage
        /// </summary>
        public void SetDepartPersonnage();
    
        /// <summary>
        /// Cette methode configure l'arret du personnage
        /// </summary>
        public void SetPausePersonnage();
        
        /// <summary>
        /// Cette methode determine la condition d'Arret du personnage.
        /// </summary>
        /// <param name="nombreDeplacements">le nombre de deplacements effectue</param>
        /// <param name="maxDeplacements">Le nombre maximum de deplacments</param>
        public void SetArretPersonnages(int nombreDeplacements, int maxDeplacements);
    }
}
