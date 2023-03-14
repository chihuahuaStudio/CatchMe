/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */

using System;
using CoreDesign;
using PlasticGui;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Personnages
{
    public class DeplacementAvantPlan : MonoBehaviour
    {
        #region Déclarations des Variables

        [Header("Paramètres")] 
        [Tooltip("Le type de deplacement")] 
        [SerializeField] private TypeDeplacement typeDeplacement;
        
        [Tooltip("Vitesse de Déplacement du Personnage")]
        [SerializeField] float vitesse = 5.0f;
    
        [Tooltip("Limite Déplacement X")]
        [SerializeField] float limiteX;
        
        [Tooltip("Nombre de déplacement maximum avant disparaître")]
        [SerializeField] int nombreMaxDeplacement;
    
        [Tooltip("Delai de Départ")]
        [SerializeField] float delai;

        [Header("Référence Seulement")]
        [Tooltip("Affichage du temps écoulé depuis le début du programme")]
        [SerializeField] float time;
    
        [Tooltip("Nombre de déplacement")]
        [SerializeField] int nmbrDeplacement;
        
 
        private Animator _persoAnimator;
        private Transform _persoTransfo;
        private Vector3 _pos;
        private Vector3 _posDepart;
        private float _vitesseInitial;
        private float _delaiInitial;

        private Animations deplacementPersonnage;

        private const float ZERO = 0;

        #endregion

        #region Methode Mono

        private void Awake()
        {
            _persoTransfo = transform;
            _persoAnimator = GetComponent<Animator>();
            deplacementPersonnage = new Deplacement();

        }
        // Start is called before the first frame update
        void Start()
        {
            _posDepart = _persoTransfo.position;
            _vitesseInitial = vitesse;
            _delaiInitial = delai;
        }

        private void OnEnable()
        {
            GameEvents.PersonnageArriveLimiteDeplacement += CalculeNombreDeplacement;
            GameEvents.PersonnageArriveLimiteDeplacement += UpdateTimer;
            GameEvents.PersonnageArriveLimiteDeplacement += ArretPersonnage;
        }

        // Update is called once per frame
        void Update()
        {
            time = Time.time;
            _pos = _persoTransfo.position;
            
            switch (typeDeplacement)
            {
                case TypeDeplacement.Avant:
                    deplacementPersonnage.Execute(_persoTransfo, Vector3.right, vitesse);
                    CalculeDeplacement();
                    break;
                case TypeDeplacement.Arriere:
                    deplacementPersonnage.Execute(_persoTransfo, Vector3.back, vitesse);
                    break;
                
            }
            
            if (nmbrDeplacement >= nombreMaxDeplacement)
            {
                DestroyImmediate(gameObject);
            }
        }

        private void OnDisable()
        {
            GameEvents.PersonnageArriveLimiteDeplacement -= CalculeNombreDeplacement;
            GameEvents.PersonnageArriveLimiteDeplacement -= UpdateTimer;
            GameEvents.PersonnageArriveLimiteDeplacement -= ArretPersonnage;
        }

        #endregion

        #region Deplacement

        /// <summary>
        /// Fonction de calcule le déplacement du personnage
        /// </summary>
        private void CalculeDeplacement()
        {
            //Si à la limite du déplacement
            // if (_pos.x >= limiteX)
            // {
            //     
            //     CalculeNombreDeplacement();
            //     UpdateTimer();
            //     ArretPersonnage();
            // }
            //
            if (Time.time >= delai)
            {
                DepartPersonnage();
            }
            
        }
        #endregion

        private void DepartPersonnage()
        {
            _persoAnimator.enabled = true;
            vitesse = _vitesseInitial;
            delai = _delaiInitial;
        }
        private void ArretPersonnage()
        {
            _persoTransfo.position = _posDepart;
            vitesse = ZERO;
            _persoAnimator.enabled = false;
        }

        private void CalculeNombreDeplacement()
        {
            nmbrDeplacement++;
        }

        private void UpdateTimer()
        {
            delai += Time.time;
        }

    }
}
