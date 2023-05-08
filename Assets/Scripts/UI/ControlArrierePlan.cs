/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * Modifiée Fév 2023
 */

using CoreDesign;
using UnityEngine;

namespace CatchMeIfYouCan.UI
{
    public class ControlArrierePlan : MonoBehaviour
    {
        #region Déclaration des Variables

        private SpriteRenderer _panel;
        private float _alpha;
        private float _time;
        private const float VITESSE_FADE = 0.5f;

        #endregion

        #region Methode Mono

        private void Awake()
        {
            _panel = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            GameEvents.BackgroundFade += ExecuteFade;
        }

        private void OnDisable()
        {
            GameEvents.BackgroundFade -= ExecuteFade;
        }
        
        /// <summary>
        /// Cette methode effectue un fade in du panel de bakground
        /// </summary>
        private void ExecuteFade()
        {
            //Changement d'opacité pour la fin du film
            _panel.color = new Color(1, 1, 1, _alpha += VITESSE_FADE * Time.deltaTime);
        }

        #endregion

    }
}
