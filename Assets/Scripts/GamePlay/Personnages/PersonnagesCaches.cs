/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * This script was mmodified Feb 23 2023
 * I implemented the Command Pattern without the undo function
 */

using System;
using CoreDesign;
using UnityEngine;

namespace GamePlay.Personnages
{
    /// <summary>
    /// Cette classe execute le deplacment verticale des animaux cachés
    /// </summary>
    public class PersonnagesCaches : MonoBehaviour, IDeplacement
    {
        #region Déclarations des variables
    

        [Header("Paramètre du contrôleur")]
        [Tooltip("Vitesse de déplacement")]
        [SerializeField] float vitesseDeplacement;
    
        [Tooltip("Limite du déplacement vertical")]
        [SerializeField] float limiteY;

        [Tooltip("Delai du deplacement")] 
        [SerializeField] private float delaiDeplacement;

        [Header("Reference seulement")] 
        [SerializeField] private float timer;
    
        //private variables
        private Transform _transform;
    
        //Command Pattern Objects
        private Deplacement _deplacementVertical;

        #endregion

        #region Mono

        private void Awake()
        {
            _deplacementVertical = new Deplacement();

        }
        
        void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            timer = MathF.Round(Time.time);
            
            if (timer >= delaiDeplacement)
            {
                CalculeLimiteDeplacement(_transform.position.y, limiteY);
                Deplacement(_transform, Vector3.up, vitesseDeplacement);
            }
        }

        #endregion


        #region Custom methods
        
        public void Deplacement(Transform transfo, Vector3 direction, float vitesse)
        {
            _deplacementVertical.Execute(_transform, direction, vitesse);
        }

        public void CalculeLimiteDeplacement(float currentPosition, float limitePosition)
        {
            if (currentPosition >= limitePosition)
                vitesseDeplacement = 0.0f;
        }

        #endregion

   
    }
}
