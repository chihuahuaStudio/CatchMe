/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * Modifiée en Fév 2023
 */


using UnityEngine;

namespace GamePlay.NPC
{
    /// <summary>
    /// Cette méthode effectue la rotation de 
    /// </summary>
    public class RotationMoulin : MonoBehaviour
    {

        #region Déclaration des Variables

        private const float VITESSE_DE_ROTATION = -100;
        private Transform moulinTransform;

        #endregion

        #region Methode Mono

        private void Awake()
        {
     
            moulinTransform = transform;
        }
    
    
        private void Update()
        {
            MoulinRotation();
        }

        /// <summary>
        /// Cette méthode créer la rotation du moulin
        /// </summary>
        private void MoulinRotation()
        {
            moulinTransform.Rotate(Vector3.forward * (VITESSE_DE_ROTATION * Time.deltaTime), Space.World);   
        
        }
    
        #endregion

    }
}
