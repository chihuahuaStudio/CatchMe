/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMoulin : MonoBehaviour
{

    #region Déclaration des Variables

    private const float VITESSE_DE_ROTATION = -80;
    private Transform monTransfo;

    #endregion

    #region Methode Mono

    private void Awake()
    {
     
        monTransfo = gameObject.transform;
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        monTransfo.Rotate(Vector3.forward * VITESSE_DE_ROTATION *Time.deltaTime, Space.World);   
    }

    #endregion

}
