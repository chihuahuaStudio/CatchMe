using UnityEngine;

namespace CoreDesign
{
    /// <summary>
    /// Cette Interface gere le deplacement du personnages
    /// </summary>
    public interface IDeplacement
    {
        /// <summary>
        /// Cette methode execute le deplacement du personnage
        /// </summary>
        /// <param name="direction">La direction du deplacment</param>
        public void Deplacement(Transform transfo, Vector3 direction, float vitesse);
        
        /// <summary>
        /// Cette methode calcule la limite de deplacement de chaque personnages
        /// </summary>
        /// <param name="currentPosition">La position actuelle du personnages</param>
        /// <param name="limitePosition">La positon limite</param>
        public void CalculeLimiteDeplacement(float currentPosition, float limitePosition);
        
    }
}
