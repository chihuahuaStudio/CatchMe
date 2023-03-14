using CoreDesign;
using UnityEngine;

namespace GamePlay.Personnages
{
    public class Collision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            GameEvents.RaisePersonnageTraverseColliderAction();
        }
    }
}
