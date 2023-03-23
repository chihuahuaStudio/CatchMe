/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */

using CoreDesign;
using UnityEngine;

namespace GamePlay.Personnages
{
    public class DeplacementPersonnages : MonoBehaviour
    {
        #region Déclarations des Variables

        [Header("Paramètres")] 
        [Tooltip("Le type de deplacement")] 
        [SerializeField] private TypeDeplacement typeDeplacement;
        
        [Tooltip("Vitesse de Déplacement du Personnage")]
        [SerializeField] float vitesseDeplacement;
        
        [Tooltip("Delai de Départ")]
        [SerializeField] float delaiProchainDeplacement;

        [Header("Référence Seulement")]
        [Tooltip("Affichage du temps écoulé depuis le début du programme")]
        [SerializeField] float time;
        
        //Private fields
        private Animator _persoAnimator;
        private Transform _transform;
        private Vector3 _posDepart;
        private float _vitesseInitial;
        private float _delaiInitial;
        private Vector3 directionPersonnage;
        
        // Script refereneces
        private Animations deplacementPersonnage;
        private CalculeDeplacement _calculeDeplacement;
        
        private const float VITESSE_NULL = 0;

        #endregion

        #region Methode Mono

        private void Awake()
        {
            _transform = transform;
            _persoAnimator = GetComponent<Animator>();
            deplacementPersonnage = new Deplacement();
            _calculeDeplacement = GetComponent<CalculeDeplacement>();
        }

        
        void Start()
        {
            _posDepart = _transform.position;
            _vitesseInitial = vitesseDeplacement;
            _delaiInitial = delaiProchainDeplacement;
            
            SelectionTypeDeDeplacement();
        }
        

        void Update()
        {
            time = Time.time;

            if (_calculeDeplacement.EstEnArret)
            {
              ArretPersonnage();
              UpdateTimer();
            }
     
            Deplacement(directionPersonnage);
            
            if (Time.time >= delaiProchainDeplacement)
            {
                DepartPersonnage();
            }
            
        }
        
        #endregion

        #region Methode custom

        /// <summary>
        /// Cette methode determine le type de deplacement du personnage
        /// </summary>
        private void SelectionTypeDeDeplacement()
        {
            switch (typeDeplacement)
            {
                case TypeDeplacement.Avant:
                    directionPersonnage = Vector3.right;
                    break;
                case TypeDeplacement.Arriere:
                    directionPersonnage = Vector3.left;
                    break;
                case TypeDeplacement.Verticale:
                    directionPersonnage = Vector3.up;
                    break;
            }
        }

        /// <summary>
        /// Fonction de calcule le déplacement du personnage
        /// </summary>
        private void Deplacement(Vector3 directionDeplacement)
        {
            deplacementPersonnage.Execute(_transform, directionDeplacement, 
                vitesseDeplacement);
            
            if (Time.time >= delaiProchainDeplacement)
            {
                DepartPersonnage();
            }
        }
        
        /// <summary>
        /// Determine le départ du personnage
        /// </summary>
        private void DepartPersonnage()
        {
            _persoAnimator.enabled = true;
            vitesseDeplacement = _vitesseInitial;
            delaiProchainDeplacement = _delaiInitial;
            _calculeDeplacement.EstEnArret = false;
        }
        
        
        /// <summary>
        ///  Determine l'arret du personnage
        /// </summary>
        private void ArretPersonnage()
        {
            _transform.position = _posDepart;
            vitesseDeplacement = VITESSE_NULL;
            _persoAnimator.enabled = false;
        }
        
        private void UpdateTimer()
        {
            delaiProchainDeplacement += Time.time;
        }

        #endregion

     

    }
}
