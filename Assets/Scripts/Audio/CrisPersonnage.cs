using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisPersonnage : MonoBehaviour
{
    public static CrisPersonnage Instance { get; private set; }

    [SerializeField] AudioSource monAs;
    [SerializeField] AudioClip monClip;
    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    public void Cris()
    {
        monAs.PlayOneShot(monClip, 1.0f);
    }
}
