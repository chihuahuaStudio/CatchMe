using System;

namespace CoreDesign
{
    public static class GameEvents 
    {
        public static Action PersonnageTraverseCollider { get; set; }
        public static Action PersonnageArriveLimiteDeplacement { get; set; }
        public static Action PersonnageRetourPositionInitiale { get; set; }
        public static Action NombreMaximumDeplacementAtteint { get; set; }
        public static Action CommenceDeplacementVertical { get; set; }
        public static Action EndOfFilm { get; set; }
        public static Action BackgroundFade { get; set; }
    

        public static void RaisePersonnageTraverseColliderAction()
        {
            PersonnageTraverseCollider?.Invoke();
        }

        public static void RaiseEndOfFilmAction()
        {
            EndOfFilm?.Invoke();
        }

        public static void RaiseCommenceDeplacementVerticalAction()
        {
            CommenceDeplacementVertical?.Invoke();
        }


        public static void RaiseBackgroundFadeAction()
        {
            BackgroundFade?.Invoke();
        }

        public static void RaisePersonageArriveLimiteDeplacement()
        {
            PersonnageArriveLimiteDeplacement?.Invoke();
        }

        public static void RaisePersonnageRetourPositionInitiale()
        {
            PersonnageRetourPositionInitiale?.Invoke();
        }

        public static void RaiseNombreMaximumDeplacementAtteint()
        {
            NombreMaximumDeplacementAtteint?.Invoke();
        }
    }
}
