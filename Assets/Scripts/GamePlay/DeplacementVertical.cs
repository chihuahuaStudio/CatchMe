/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * This script was mmodified Feb 23 2023
 * I implemented the Command Pattern without the undo function
 */

using UnityEngine;

public class DeplacementVertical : MonoBehaviour
{
    #region Déclarations des variables
    
    [Header("Paramètre du contrôleur")]
    [Tooltip("Vitesse de déplacement")]
    [SerializeField] float vitesse;
    
    [Tooltip("Délai avant le début du déplacement")]
    [SerializeField] float delai;
    
    [Tooltip("Limite du déplacement vertical")]
    [SerializeField] float limiteY;
    
    //private variables
    private Animator persoAnimator;
    private const float VITESSE_NULL = 0.0f;
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
    
    
    void Start()
    {
        _transform = transform;
        persoAnimator.enabled = false;
        
    }
    
    
    void Update()
    {
        
        if(Time.time >= delai)
        {
            TranslationVertical();
            CheckYPosition();
        }
    }

    #endregion


    #region Custom methods

    private void TranslationVertical()
    {
        // transform.Translate(Vector3.up * (vitesse * Time.deltaTime));
        _deplacementVertical.Execute(_transform, Vector3.up, vitesse);

    }

    #endregion

    #region Custom Methods

    private void CheckYPosition()
    {
        if(transform.position.y >= limiteY)
        {
            vitesse = VITESSE_NULL;
        }
    }

    #endregion

}
