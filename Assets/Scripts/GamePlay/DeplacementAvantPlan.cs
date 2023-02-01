/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeplacementAvantPlan : MonoBehaviour
{
    #region Déclarations des Variables

    [Header("Paramètres")]
    [Tooltip("Vitesse de Déplacement du Personnage")]
    [SerializeField] float _vitesse = 5.0f;

    [Tooltip("Limite Déplacement X")]
    [SerializeField] float _limiteX;

    [Tooltip("Limite de déplacement avant disparaître")]
    [SerializeField] int _limiteDeplacement;

    [Tooltip("Delai de Départ")]
    [SerializeField] float _delai;

    [Tooltip("Delai des déclenchement des son")]
    [SerializeField] float _delaiSon;

    [Header("Référence Seulement")]
    [Tooltip("Affichage du temps écoulé depuis le début du programme")]
    [SerializeField] float _time;

    [Tooltip("Nombre de déplacement")]
    [SerializeField] int _nmbrDeplacement = 0;

    [Tooltip("Est-ce que le son joue présentement")]
    [SerializeField] bool _çaJoue = false;

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
        _vitesseInitial = _vitesse;
        _delaiInitial = _delai;
        _delaiSonInitial = _delaiSon;
    }

    // Update is called once per frame
    void Update()
    {
        _time = Time.time;
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
        _persoTransfo.Translate(Vector3.right * _vitesse * Time.deltaTime);

        //Condition pour éviter que le son soit déclencher à chaque boucle
        if (!_çaJoue && Time.time >= _delaiSon)
        {
            _çaJoue = true;
            DeclenchementSon();
        }

        //Si à la limite du déplacement
        if (_pos.x >= _limiteX)
        {
            _nmbrDeplacement++;
            _delai += Time.time;
            _persoTransfo.position = _posDepart;
            _vitesse = ZERO;
            _çaJoue = false;
            _delaiSon += Time.time + _delaiInitial;
            _persoAnimator.enabled = false;

        }

        if (Time.time >= _delai)
        {
            _persoAnimator.enabled = true;
            
            _vitesse = _vitesseInitial;
            _delai = _delaiInitial;
            _persoAnimator.enabled = true;
        }

        if(Time.time >= _delaiSon)
        {
            _delaiSon = _delaiSonInitial;
        }

        if (_nmbrDeplacement >= _limiteDeplacement)
        {
            _çaJoue = true;
            _vitesse = ZERO;
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

        if(tag == "Player")
        {
            CrisPersonnage.Instance.Cris();
        }
    }

    #endregion
}
