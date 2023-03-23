using CoreDesign;
using UnityEngine;

namespace GamePlay.Personnages
{
    public class DeclencheCrisPersonnage : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            GameEvents.RaisePersonnageTraverseColliderSonAction();
        }
    }
}
