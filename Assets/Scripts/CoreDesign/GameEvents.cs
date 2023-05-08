using System;
using UnityEngine;

namespace CoreDesign
{
    public static class GameEvents 
    {
        public static Action PersonnageTraverseColliderSon { get; set; }
        public static Action EndOfFilm { get; set; }
        public static Action BackgroundFade { get; set; }

        //Invocation des Actions
        public static void RaisePersonnageTraverseColliderSonAction() =>
            PersonnageTraverseColliderSon?.Invoke();
        
        public static void RaiseEndOfFilmAction() =>
            EndOfFilm?.Invoke();
        
        public static void RaiseBackgroundFadeAction() =>
            BackgroundFade?.Invoke();
        
        
    }
}
