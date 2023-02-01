/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementVertical : MonoBehaviour
{
    #region Déclarations des variables

    [Header("Paramètre du contrôleur")]
    [Tooltip("Vitesse de déplacement")]
    [SerializeField] float _vitesse;

    [Tooltip("Temps écoulé depuis le début de l'application")]
    [SerializeField] float _time;

    [Tooltip("Délai avant le début du déplacement")]
    [SerializeField] float _delai;

    [Tooltip("Limite du déplacement vertical")]
    [SerializeField] float _limiteY;

    private Animator persoAnimator;
    private const float Vitesse_Null = 0.0f;

    #endregion

    #region Méthode Mono

    private void Awake()
    {
        persoAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        persoAnimator.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        _time = Mathf.Round(Time.time);

        if(Time.time >= _delai)
        {
            transform.Translate(Vector3.up * _vitesse * Time.deltaTime);

            if(transform.position.y >= _limiteY)
            {
                _vitesse = Vitesse_Null;
              
            }

        }
    }

    #endregion

}
