/***********************************************************************
*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * 
 **********************************************************************
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementArrierePlan : MonoBehaviour
{
    #region Déclarations des Variables

    [Header("Paramètre de Déplacement")]
    [Tooltip("Vitesse de déplacement")]
    [SerializeField] float _vitesse;

    [Tooltip("Limite déplcement X")]
    [SerializeField] float _limiteX;

    [Tooltip("Limite de déplacement avant disparaître")]
    [SerializeField] int _limiteDeplacement;

    [Tooltip("Delai de départ")]
    [SerializeField] float _delai;

    [Tooltip("Delai de déclenchement des sons")]
    [SerializeField] float _delaiSon;

    [Header("Référence Seulementt")]
    [Tooltip("Affichage du temps écoulé depuis le début du programme")]
    [SerializeField] float _time;

    [Tooltip("Nombre de déplacement")]
    [SerializeField] int _nmbrDeplacement = 0;

    [Tooltip("Est-ce que le son joue?")]
    [SerializeField] bool _çaJoue = false;

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
        _vitesseInitiale = _vitesse; //Vitesse de départ
        _delaiInitial = _delai; //délai du déplacement de départ
        _delaiSonInitial = _delaiSon; //délai de déclenchement sonore

    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
    }

    #endregion

    #region Déplacement


    /// <summary>
    /// Calcule le déplacement en boucle des personnages.
    /// </summary>
    private void Deplacement()
    {
        _time = Mathf.Round(Time.time);

        //condition pour le premier déplacement
        if (Time.time >= _delai)
        {
            _pos = _persoTransfo.position;
            _persoTransfo.Translate(Vector3.right 
                                    * (_vitesse * Time.deltaTime));

            //Condition pour éviter un son en boucle dans update
            if (!_çaJoue && Time.time >= _delaiSon)
            {
                _çaJoue = true;
                DeclenchementSon();
            }

            //condition d'arret
            if (_pos.x <= _limiteX)
            {
                _nmbrDeplacement++;
                _persoTransfo.position = _posDepart;
                _vitesse = ZERO;
                _delai += Time.time;
                _çaJoue = false;
                _delaiSon += Time.time;
                _persoAnimator.enabled = false;

            }
        }

        //calcule délai déplacement
        if (Time.time >= _delai)
        {
            _vitesse = _vitesseInitiale;
            _delai = _delaiInitial;
            _persoAnimator.enabled = true; ;
        }
        //Calcule délai son
        if (Time.time >= _delaiSon)
        {
            _delaiSon = _delaiSonInitial;
        }
        //calcule limite déplacement
        if (_nmbrDeplacement >= _limiteDeplacement)
        {
            _vitesse = ZERO;
            _persoAnimator.enabled = false;
            _çaJoue = true;
        }
    }

    #endregion

    #region Audio

    /// <summary>
    /// Foncition pour le déclenchement des sons.
    /// </summary>
    private void DeclenchementSon()
    {
        _audioSource.Play();
    }

    #endregion
}
