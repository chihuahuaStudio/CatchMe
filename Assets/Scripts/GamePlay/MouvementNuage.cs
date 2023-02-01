/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementNuage : MonoBehaviour
{
    #region Déclarations de Variables
    private float _vitesse;
    private const float Limite_X_Gauche = -20.0f;
    private const float Limite_X_Droite = 15.0f;
    private const float ZERO = 0;
    private const float VITESSE_MIN_ABS = 0.5f;
    private const float VITESSE_MIN = -1.0f;
    private const float VITESSE_MAX = 1.0f;


    private Transform transformNuages;
    private Vector2 posNuages;

    #endregion

    #region Methodes Mono

    private void Awake()
    {
        transformNuages = gameObject.transform;
    }

    void Start()
    {
        //Calcule un position aléatoire pour chaque nuage au début du programme.
        posNuages = new Vector2(Random.Range(Limite_X_Gauche, Limite_X_Droite),
                                                   transformNuages.position.y);
        transformNuages.position = posNuages;

        //Calcule une vitesse aléatoire.
        _vitesse = Random.Range(VITESSE_MIN, VITESSE_MAX);

        //Assure une vitesse !=0.
        if(_vitesse == ZERO)
        {
            _vitesse = VITESSE_MIN_ABS;
        }
    }


    void Update()
    {
        DeplacementNuages();   
    }

    #endregion

    #region Methode Custom
    /// <summary>
    /// Calcule le déplacement ping-pong des nuages
    /// </summary>
    private void DeplacementNuages()
    {
        transformNuages.Translate(Vector2.right * _vitesse * Time.deltaTime);

        if(transformNuages.position.x < Limite_X_Gauche || transformNuages.position.x > Limite_X_Droite)
        {
            _vitesse = -_vitesse;
        }
    }

    #endregion
}
