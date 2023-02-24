/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */

using UnityEngine;
using UnityEngine.Serialization;


public class DeplacementAvantPlan : MonoBehaviour
{
    #region Déclarations des Variables

    [FormerlySerializedAs("_vitesse")]
    [Header("Paramètres")]
    [Tooltip("Vitesse de Déplacement du Personnage")]
    [SerializeField] float vitesse = 5.0f;

    [FormerlySerializedAs("_limiteX")]
    [Tooltip("Limite Déplacement X")]
    [SerializeField] float limiteX;

    [FormerlySerializedAs("_limiteDeplacement")]
    [Tooltip("Limite de déplacement avant disparaître")]
    [SerializeField] int limiteDeplacement;

    [FormerlySerializedAs("_delai")]
    [Tooltip("Delai de Départ")]
    [SerializeField] float delai;

    [FormerlySerializedAs("_delaiSon")]
    [Tooltip("Delai des déclenchement des son")]
    [SerializeField] float delaiSon;

    [FormerlySerializedAs("_time")]
    [Header("Référence Seulement")]
    [Tooltip("Affichage du temps écoulé depuis le début du programme")]
    [SerializeField] float time;

    [FormerlySerializedAs("_nmbrDeplacement")]
    [Tooltip("Nombre de déplacement")]
    [SerializeField] int nmbrDeplacement;

    [FormerlySerializedAs("_çaJoue")]
    [Tooltip("Est-ce que le son joue présentement")]
    [SerializeField] bool çaJoue;

    private AudioClip cris;
    private Animator _persoAnimator;
    private Transform _persoTransfo;
    private AudioSource _audioSource;
    private Vector3 _pos;
    private Vector3 _posDepart;
    private float _vitesseInitial;
    private float _delaiInitial;
    private float _delaiSonInitial;

    private const float ZERO = 0;

    #endregion

    #region Methode Mono

    private void Awake()
    {
        _persoTransfo = gameObject.transform;
        _persoAnimator = gameObject.GetComponent<Animator>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _posDepart = _persoTransfo.position;
        _vitesseInitial = vitesse;
        _delaiInitial = delai;
        _delaiSonInitial = delaiSon;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        CalculeDeplacement();
    }

    #endregion

    #region Deplacement

    /// <summary>
    /// Fonction de calcule du éplacement du personnage
    /// </summary>
    private void CalculeDeplacement()
    {
        _pos = _persoTransfo.position;
        _persoTransfo.Translate(Vector3.right * (vitesse * Time.deltaTime));

        //Condition pour éviter que le son soit déclencher à chaque boucle
        if (!çaJoue && Time.time >= delaiSon)
        {
            çaJoue = true;
            DeclenchementSon();
        }

        //Si à la limite du déplacement
        if (_pos.x >= limiteX)
        {
            nmbrDeplacement++;
            delai += Time.time;
            _persoTransfo.position = _posDepart;
            vitesse = ZERO;
            çaJoue = false;
            delaiSon += Time.time + _delaiInitial;
            _persoAnimator.enabled = false;

        }

        if (Time.time >= delai)
        {
            _persoAnimator.enabled = true;
            
            vitesse = _vitesseInitial;
            delai = _delaiInitial;
            // _persoAnimator.enabled = true;
        }

        if(Time.time >= delaiSon)
        {
            delaiSon = _delaiSonInitial;
        }

        if (nmbrDeplacement >= limiteDeplacement)
        {
            çaJoue = true;
            vitesse = ZERO;
            _persoAnimator.enabled = false;
        }

    }
    #endregion

    #region Audio
    /// <summary>
    /// Fonction qui déclenche les sons des personnages.
    /// </summary>
    private void DeclenchementSon()
    {
        _audioSource.Play();

        if(CompareTag("Player"))
        {
            CrisPersonnage.Instance.Cris();
        }
    }

    #endregion
}
