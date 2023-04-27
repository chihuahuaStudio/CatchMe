using UnityEngine;

namespace CoreDesign
{
    public interface IDeplacement
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
        /// Cette methode execute le deplacement du personnage
        /// </summary>
        /// <param name="direction">La direction du deplacment</param>
        public void Deplacement(Transform transfo, Vector3 direction, float vitesse);

        /// <summary>
        /// Cette methode calcule le nombre de deplacement effectue
        /// </summary>
        public void CompteNombreDeDeplacement();

        /// <summary>
        /// Cette methode calcule la limite de deplacement de chaque personnages
        /// </summary>
        /// <param name="xPosition"></param>
        /// <param name="limiteXPosition"></param>
        public void CalculeLimiteDeplacement(float xPosition, float limiteXPosition);

        public void SetArretPersonnages(int nombreDeplacements, int maxDeplacements);

    }
}
