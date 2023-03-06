/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * Modifié Fév 2023 pour implementer le Command Pattern
 */

using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Texte : MonoBehaviour
{
    #region Déclaration des Variables
    
    [FormerlySerializedAs("_vitesse")]
    [Tooltip("Vitesse de déplacement du texte")]
    [SerializeField] float vitesse;

    [FormerlySerializedAs("_delai")]
    [Tooltip("Délai avant de l'apparition du texte")]
    [SerializeField] float delai;

    [FormerlySerializedAs("_time")]
    [Tooltip("Temps depuis le début du programme")]
    [SerializeField] float time;

    [FormerlySerializedAs("_limiteY")]
    [Tooltip("Limite du déplacement")]
    [SerializeField] float limiteY;

    //Variables privées
    private const float SCALE_AUGM = 0.01f;
    private float _scaleX = 1.0f;
    private float _scaleY = 1.0f;
    private Transform monTransfo;
    
    //Variable Command Pattern
    private Deplacement _deplacementLettre;


    #endregion

    #region Methode Mono

    private void Awake()
    {
        _deplacementLettre = new Deplacement();
        monTransfo = gameObject.transform;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        //Le temps en secondes arrondis
        time = Mathf.Round(Time.time);

        //condition du déplacement du texte
        if(time >= delai)
        {
            AgrandissementLettre();
            _deplacementLettre.Execute(monTransfo, Vector3.up, vitesse);

        }
    }
    
    #endregion

    #region Custom methods
    
    private void AgrandissementLettre()
    {
        monTransfo.localScale = new Vector2(_scaleX += SCALE_AUGM, _scaleY += SCALE_AUGM );
    }

    #endregion
}
