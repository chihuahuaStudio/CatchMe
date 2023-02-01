/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlArrierePlan : MonoBehaviour
{
    #region Déclaration des Variables

    private SpriteRenderer _panel;
    private float _alpha = 0;
    private float _time;
    private const float DELAI = 60.0f;
    private const float VITESSE_FADE = 0.3f;

    #endregion

    #region Methode Mono

    // Start is called before the first frame update
    void Start()
    {
        _panel = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Compteur
        _time = Mathf.Round(Time.time);

        //Condition de déclenchement de l'arrière plan.
        if(_time > DELAI)
        {
            //Changement de d'opacité pour la fin du film
            _panel.color = new Color(1, 1, 1, _alpha += VITESSE_FADE * Time.deltaTime);
        }
    }

    #endregion

}
