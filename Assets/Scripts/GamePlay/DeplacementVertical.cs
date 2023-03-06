/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * This script was mmodified Feb 23 2023
 * I implemented the Command Pattern without the undo function
 */

using System;
using UnityEngine;

public class DeplacementVertical : MonoBehaviour
{
    #region Déclarations des variables
    
    [Header("Paramètre du contrôleur")]
    [Tooltip("Vitesse de déplacement")]
    [SerializeField] float vitesse;
    
    [Tooltip("Limite du déplacement vertical")]
    [SerializeField] float limiteY;
    
    //private variables
    private Animator persoAnimator;
    private Transform _transform;
    
    //Command Pattern Objects
    private Deplacement _deplacementVertical;

    #endregion

    #region Mono

    private void Awake()
    {
        persoAnimator = GetComponent<Animator>();
        _deplacementVertical = new Deplacement();

    }

    private void OnEnable()
    {
        GameEvents.CommenceDeplacementVertical += TranslationVertical;
    }

    void Start()
    {
        _transform = transform;
        persoAnimator.enabled = false;
    }
    
    
    #endregion


    #region Custom methods

    private void TranslationVertical()
    {
        if(_transform.position.y <= limiteY)
         _deplacementVertical.Execute(_transform, Vector3.up, vitesse);
    }

    #endregion

}
