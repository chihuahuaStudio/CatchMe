/*
*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * 
 */


using CoreDesign;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Personnages
{
    public class DeplacementArrierePlan : MonoBehaviour
    {
        #region Déclarations des Variables
        
        [Header("Paramètre de Déplacement")]
        [Tooltip("Vitesse de déplacement")]
        [SerializeField] float vitesse;
        
        [Tooltip("Limite déplcement X")]
        [SerializeField] float limiteX;
        
        [Tooltip("Limite de déplacement avant disparaître")]
        [SerializeField] int limiteDeplacement;
        
        [Tooltip("Delai de départ")]
        [SerializeField] float delaiDeplacement;
        
        [Header("Référence Seulementt")]
        [Tooltip("Affichage du temps écoulé depuis le début du programme")]
        [SerializeField] float time;
        
        [Tooltip("Nombre de déplacement")]
        [SerializeField] int nmbrDeplacement = 0;
        
        //Référence des composants
        private Transform _persoTransfo;
        private Animator _persoAnimator;
        private Vector3 _pos;
        private Vector3 _posDepart;

        //Valeurs Initiale
        private const float ZERO = 0;
        private float _vitesseInitiale;
        private float _delaiInitial;
        private float _delaiSonInitial;
        private Animations deplcacement;

        #endregion

        #region Méthode Mono

        private void Awake()
        {
            _persoTransfo = transform;
            _persoAnimator = GetComponent<Animator>();

        }

        void Start()
        {
            _posDepart = _persoTransfo.position; //position de départ
            _vitesseInitiale = vitesse; //Vitesse de départ
            _delaiInitial = delaiDeplacement; //délai du déplacement de départ
     

        }

        // Update is called once per frame
        void Update()
        {
            time = Mathf.Round(Time.time);

            Deplacement();
        }

        #endregion

        #region Methode Custom


        /// <summary>
        /// Calcule le déplacement en boucle des personnages.
        /// </summary>
        private void Deplacement()
        {

            //condition pour chaque  déplacement
            if (Time.time >= delaiDeplacement)
            {
                vitesse = _vitesseInitiale;
                _persoTransfo.Translate(Vector3.right 
                                        * (vitesse * Time.deltaTime));
                _pos = _persoTransfo.position;
                delaiDeplacement = _delaiInitial;

            
                //condition d'arret
                if (_pos.x <= limiteX)
                {
                    nmbrDeplacement++;
                    vitesse = ZERO;
                    RetourPositionInitiale();
                }
            
            }
            
            //calcule limite déplacement
            if (nmbrDeplacement >= limiteDeplacement)
            {
                Destroy(gameObject);
            }
        
        }
        
        private void RetourPositionInitiale()
        {
            _persoTransfo.position = _posDepart;
            ResetTimerDeplacement();
        }

        private void ResetTimerDeplacement()
        {
            delaiDeplacement += Time.time;
        }

        #endregion


    
    }
}
