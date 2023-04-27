/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */

using CoreDesign;
using UnityEngine;

namespace GamePlay.Personnages
{
    [RequireComponent(typeof(Animator))]
    public class PersonnagesArriere : MonoBehaviour, IDeplacement
    {
        #region Déclarations des Variables

        [Header("Paramètres")] 
        [Tooltip("Le type de deplacement")] 
        [SerializeField] private TypeDeplacement typeDeplacement;
        
        [Tooltip("Vitesse de Déplacement du Personnage")]
        [SerializeField] private float vitesseDeplacement;

        [Tooltip("Limite X du deplacement")] 
        [SerializeField] private float limitePositionX;
        
        [Tooltip("Delai de Départ")]
        [SerializeField] private float delaiProchainDeplacement;
        
        [Tooltip("Nombre Maximum de deplacement")]
        [SerializeField] private int nombreMaxDeplacement;
        
        [Tooltip("Nombre de deplacement effectuer")]
        [SerializeField] private int nombreDeplacementEffectue;

        [Header("Référence Seulement")]
        [Tooltip("Affichage du temps écoulé depuis le début du programme")]
        [SerializeField] private float time;
        
        
        //Fields privée
        private Animator _persoAnimator;
        private Transform _transform;
        private Vector3 _positionDepart;
        private float _vitesseInitial;
        private float _delaiInitial;
        private Vector3 _directionPersonnage;
        
        // Script refereneces
        private Animations _deplacementPersonnage;


        private const float VITESSE_NULL = 0;

        #endregion

        #region Methode Mono


        private void Awake()
        {
            _transform = transform;
            _persoAnimator = GetComponent<Animator>();
            _deplacementPersonnage = new Deplacement();
        }

        
        void Start()
        {
            _positionDepart = _transform.position;
            _vitesseInitial = vitesseDeplacement;
            _delaiInitial = delaiProchainDeplacement;
            
            _directionPersonnage = SelectionTypeDeDeplacement();

        }
        

        void Update()
        {
            time = Time.time;
            
            if (Time.time >= delaiProchainDeplacement && 
                nombreDeplacementEffectue < nombreMaxDeplacement)
            {
                Deplacement(_transform, _directionPersonnage, vitesseDeplacement);
                SetDepartPersonnage();
            }
            CalculeLimiteDeplacement(_transform.position.x, limitePositionX);
        }


        #endregion

        #region Methode custom

        /// <summary>
        /// Cette methode determine le type de deplacement du personnage
        /// </summary>
        private Vector3 SelectionTypeDeDeplacement()
        {
            Vector3 direction = new Vector3();
            
            switch (typeDeplacement)
            {
                case TypeDeplacement.Avant:
                    direction = Vector3.right;
                    break;
                case TypeDeplacement.Arriere:
                    direction = Vector3.left;
                    break;
                case TypeDeplacement.Verticale:
                    direction = Vector3.up;
                    break;
            }
        
            return direction;
        }
        
        /// <summary>
        /// Cette methode gere le timer des departs
        /// </summary>
        private void UpdateTimer()
        {
            delaiProchainDeplacement += Time.time;
        }
        
 

        #endregion

        #region Methode Interface
        
        //Implementation Interface IDeplacement
        
        public void SetDepartPersonnage()
        {
            _persoAnimator.enabled = true;
            vitesseDeplacement = _vitesseInitial;
            delaiProchainDeplacement = _delaiInitial;
        }

        public void SetPausePersonnage()
        {
            _transform.position = _positionDepart;
            CompteNombreDeDeplacement();
            UpdateTimer();
            vitesseDeplacement = VITESSE_NULL;
            _persoAnimator.enabled = false;
        }

        public void Deplacement(Transform transfo, Vector3 direction, float vitesse)
        {
            _deplacementPersonnage.Execute(transfo, direction, vitesse);
        }

        public void CompteNombreDeDeplacement()
        {
            nombreDeplacementEffectue++;

        }

        public void CalculeLimiteDeplacement(float xPosition, float limiteXPosition)
        {
            if (xPosition <= limiteXPosition)
            {
                SetPausePersonnage();
            }
        }

        public void SetArretPersonnages(int nombreDeplacements, int maxDeplacements)
        {
            if (nombreDeplacements >= maxDeplacements)
            {
                _persoAnimator.enabled = false;
                vitesseDeplacement = VITESSE_NULL;
            }
        }

        
        

        #endregion



    }
}
