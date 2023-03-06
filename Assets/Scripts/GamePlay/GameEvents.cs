using System;


public class GameEvents 
{
    public static Action _personnageTraverseCollider;

    public static void RaisePersonnageTraverseColliderAction()
    {
       _personnageTraverseCollider?.Invoke();
    }

}
