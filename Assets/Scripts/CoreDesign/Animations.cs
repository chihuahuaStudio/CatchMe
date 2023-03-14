/*
 * 
 */

using UnityEngine;

namespace CoreDesign
{
    /// <summary>
    /// This is the base class for the Comamnd Pattern to
    /// all animation classes.
    /// </summary>
    public abstract class Animations
    {
        public abstract void Execute(Transform transform, Vector3 direction, float vitesse);
    }

    public class Deplacement : Animations
    {
        public override void Execute(Transform transform, Vector3 direction, float vitesse)
        {
            transform.Translate(direction * (vitesse * Time.deltaTime));
        
        }
    }
}