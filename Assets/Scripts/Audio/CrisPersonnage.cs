

using UnityEngine;

public class CrisPersonnage : MonoBehaviour
{
    private AudioSource monAs;
    
    public void Awake()
    {
        monAs = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("TriggerSon"))
        {
            DeclencheCrisPersonnage();
            GameEvents.RaisePersonnageTraverseColliderAction();
        }
            
    }

    private void DeclencheCrisPersonnage()
    {
        monAs.Play();
    }

}
