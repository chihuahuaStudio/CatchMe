/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */

using UnityEngine;



public class DeplacementAvantPlan : MonoBehaviour
{
    #region Déclarations des Variables
    
    [Header("Paramètres")]
    [Tooltip("Vitesse de Déplacement du Personnage")]
    [SerializeField] float vitesse = 5.0f;
    
    [Tooltip("Limite Déplacement X")]
    [SerializeField] float limiteX;
    
    [Tooltip("Limite de déplacement avant disparaître")]
    [SerializeField] int limiteDeplacement;
    
    [Tooltip("Delai de Départ")]
    [SerializeField] float delai;

    [Header("Référence Seulement")]
    [Tooltip("Affichage du temps écoulé depuis le début du programme")]
    [SerializeField] float time;
    
    [Tooltip("Nombre de déplacement")]
    [SerializeField] int nmbrDeplacement;
    
    [Tooltip("Est-ce que le son joue présentement")]
    [SerializeField] bool çaJoue;

    private AudioClip cris;
    private Animator _persoAnimator;
    private Transform _persoTransfo;
    private Vector3 _pos;
    private Vector3 _posDepart;
    private float _vitesseInitial;
    private float _delaiInitial;

    private const float ZERO = 0;

    #endregion

    #region Methode Mono

    private void Awake()
    {
        _persoTransfo = gameObject.transform;
        _persoAnimator = gameObject.GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        _posDepart = _persoTransfo.position;
        _vitesseInitial = vitesse;
        _delaiInitial = delai;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        _pos = _persoTransfo.position;

        CalculeDeplacement();
        
        if (nmbrDeplacement >= limiteDeplacement)
        {
            DestroyImmediate(gameObject);
        }
    }

    #endregion

    #region Deplacement

    /// <summary>
    /// Fonction de calcule le déplacement du personnage
    /// </summary>
    private void CalculeDeplacement()
    {
        _persoTransfo.Translate(Vector3.right * (vitesse * Time.deltaTime));
        
        //Si à la limite du déplacement
        if (_pos.x >= limiteX)
        {
            nmbrDeplacement++;
            delai += Time.time;
            _persoTransfo.position = _posDepart;
            vitesse = ZERO;
            _persoAnimator.enabled = false;
        }

        if (Time.time >= delai)
        {
            _persoAnimator.enabled = true;
            vitesse = _vitesseInitial;
            delai = _delaiInitial;
        }

    

    }
    #endregion


}
