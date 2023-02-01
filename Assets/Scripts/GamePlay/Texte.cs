/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texte : MonoBehaviour
{
    #region Déclaration des Variables
    [Tooltip("Vitesse de déplacement du texte")]
    [SerializeField] float _vitesse;

    [Tooltip("Délai avant de l'apparition du texte")]
    [SerializeField] float _delai;

    [Tooltip("Temps depuis le début du programme")]
    [SerializeField] float _time;

    [Tooltip("Limite du déplacement")]
    [SerializeField] float _limiteY;

    private const float VITESSE_NULL = 0.0f;
    private const float SCALE_AUGM = 0.01f;
    private float _scaleX = 1.0f;
    private float _scaleY = 1.0f;
    private Transform monTransfo;


    #endregion

    #region Methode Mono

    private void Awake()
    {
        monTransfo = gameObject.transform;
    }
    // Update is called once per frame
    void Update()
    {
        //Le temps en secondes arrondis
        _time = Mathf.Round(Time.time);

        //condition du déplacement du texte
        if(_time >= _delai)
        {
            monTransfo.localScale = new Vector2(_scaleX += SCALE_AUGM, _scaleY += SCALE_AUGM );
            monTransfo.Translate(Vector3.up * _vitesse * Time.deltaTime);

            if(monTransfo.position.y >= _limiteY)
            {
                _vitesse = VITESSE_NULL;
            }
        }
    }

    #endregion
}
