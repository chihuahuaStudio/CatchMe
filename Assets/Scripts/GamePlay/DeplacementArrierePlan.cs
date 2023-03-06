/*
*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * 
 */


using UnityEngine;
using UnityEngine.Serialization;

public class DeplacementArrierePlan : MonoBehaviour
{
    #region Déclarations des Variables

    [FormerlySerializedAs("_vitesse")]
    [Header("Paramètre de Déplacement")]
    [Tooltip("Vitesse de déplacement")]
    [SerializeField] float vitesse;

    [FormerlySerializedAs("_limiteX")]
    [Tooltip("Limite déplcement X")]
    [SerializeField] float limiteX;

    [FormerlySerializedAs("_limiteDeplacement")]
    [Tooltip("Limite de déplacement avant disparaître")]
    [SerializeField] int limiteDeplacement;

    [FormerlySerializedAs("delai")]
    [FormerlySerializedAs("_delai")]
    [Tooltip("Delai de départ")]
    [SerializeField] float delaiDeplacement;

    [FormerlySerializedAs("_delaiSon")]
    [Tooltip("Delai de déclenchement des sons")]
    [SerializeField] float delaiSon;

    [FormerlySerializedAs("_time")]
    [Header("Référence Seulementt")]
    [Tooltip("Affichage du temps écoulé depuis le début du programme")]
    [SerializeField] float time;

    [FormerlySerializedAs("_nmbrDeplacement")]
    [Tooltip("Nombre de déplacement")]
    [SerializeField] int nmbrDeplacement = 0;

    [FormerlySerializedAs("_çaJoue")]
    [Tooltip("Est-ce que le son joue?")]
    [SerializeField] bool çaJoue = false;

    //Référence des composants
    private AudioSource _audioSource;
    private Transform _persoTransfo;
    private Animator _persoAnimator;
    private Vector3 _pos;
    private Vector3 _posDepart;

    //Valeurs Initiale
    private const float ZERO = 0;
    private float _vitesseInitiale;
    private float _delaiInitial;
    private float _delaiSonInitial;

    #endregion

    #region Méthode Mono

    private void Awake()
    {
        _persoTransfo = transform;
        _persoAnimator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

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

    #region Déplacement


    /// <summary>
    /// Calcule le déplacement en boucle des personnages.
    /// </summary>
    private void Deplacement()
    {

        //condition pour chaque  déplacement
        if (Time.time >= delaiDeplacement)
        {
            vitesse = _vitesseInitiale;
            // _persoAnimator.enabled = true; ;
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
            // _vitesse = ZERO;
            // _persoAnimator.enabled = false;
            // _çaJoue = true;
        }
        
    }

    #endregion

    #region Audio
    
    private void RetourPositionInitiale()
    {
        _persoTransfo.position = _posDepart;
        ResetTimerDeplacement();
        çaJoue = false; //ajouter une autre classe pour le son
        // _persoAnimator.enabled = false;
    }

    private void ResetTimerDeplacement()
    {
        delaiDeplacement += Time.time;
    }

    #endregion
    
}
