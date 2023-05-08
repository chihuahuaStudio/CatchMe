using System;
using CoreDesign;
using UnityEngine;

namespace GamePlay.Controle
{
    /// <summary>
    /// Cette 
    /// </summary>
    public class Timer : MonoBehaviour
    {

        [SerializeField] private float timer;
        [SerializeField] private float timerArretFilm;
        [SerializeField] private float backgoundFade;
        
        void Update()
        {
            timer = MathF.Round(Time.time);
        
            if(timer >= timerArretFilm)
                GameEvents.RaiseEndOfFilmAction();
            
            if (timer >= backgoundFade)
                GameEvents.RaiseBackgroundFadeAction();
        }
    }
}
