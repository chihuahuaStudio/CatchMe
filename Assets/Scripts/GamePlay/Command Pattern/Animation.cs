/*
 * 
 */
using UnityEngine;


/// <summary>
/// This is the base class for all animation classes
/// </summary>
public abstract class Animation
{
    public abstract void Execute(Transform transform, Vector3 direction, float vitesse);
}

public class Deplacement : Animation
{
    public override void Execute(Transform transform, Vector3 direction, float vitesse)
    {
        transform.Translate(direction * (vitesse * Time.deltaTime));
        
    }
}


