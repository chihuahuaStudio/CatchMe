/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */

using CoreDesign;
using UnityEngine;

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
        private Vector3 _posDepart;
        private float _vitesseInitial;
        private float _delaiInitial;

        private Animations deplacementPersonnage;
        private CalculeDeplacement _calculeDeplacement;

        private const float ZERO = 0;

        #endregion

        #region Methode Mono

        private void Awake()
        {
            _persoTransfo = transform;
            _persoAnimator = GetComponent<Animator>();
            deplacementPersonnage = new Deplacement();
            _calculeDeplacement = GetComponent<CalculeDeplacement>();

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
            // GameEvents.PersonnageArriveLimiteDeplacement += CalculeNombreDeplacement;
            GameEvents.PersonnageArriveLimiteDeplacement += UpdateTimer;
            GameEvents.PersonnageArriveLimiteDeplacement += ArretPersonnage;
        }

        // Update is called once per frame
        void Update()
        {
            time = Time.time;
            
            SelectionTypeDeDeplacement();
            
            if (_calculeDeplacement.NombreDeplacementEffectue >= _calculeDeplacement.NombreMaxDeplacement)
            {
                DetruirePersonnage();
            }
        }

        private void OnDisable()
        {
            // GameEvents.PersonnageArriveLimiteDeplacement -= CalculeNombreDeplacement;
            GameEvents.PersonnageArriveLimiteDeplacement -= UpdateTimer;
            GameEvents.PersonnageArriveLimiteDeplacement -= ArretPersonnage;
        }

        #endregion

        #region Methode custom

        private void SelectionTypeDeDeplacement()
        {
            switch (typeDeplacement)
            {
                case TypeDeplacement.Avant:
                    deplacementPersonnage.Execute(_persoTransfo, Vector3.right, vitesse);
                    CalculeDeplacement();
                    break;
                case TypeDeplacement.Arriere:
                    deplacementPersonnage.Execute(_persoTransfo, Vector3.back, vitesse);
                    CalculeDeplacement();
                    break;
                case TypeDeplacement.Verticale:
                    deplacementPersonnage.Execute(_persoTransfo, Vector3.up, vitesse);
                    break;
            }
        }

        /// <summary>
        /// Fonction de calcule le déplacement du personnage
        /// </summary>
        private void CalculeDeplacement()
        {
            if (Time.time >= delai)
            {
                DepartPersonnage();
            }
        }
        
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

        // private void CalculeNombreDeplacement()
        // {
        //     nmbrDeplacement++;
        // }

        private void UpdateTimer()
        {
            delai += Time.time;
        }

        private void DetruirePersonnage()
        {
            Destroy(gameObject);
        }
        
        #endregion

     

    }
}
