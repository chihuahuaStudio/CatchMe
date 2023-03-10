using System;


public class GameEvents 
{
    public static Action PersonnageTraverseCollider { get; set; }
    public static Action CommenceDeplacementVertical { get; set; }
    public static Action EndOfFilm { get; set; }
    

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
    
    

}
