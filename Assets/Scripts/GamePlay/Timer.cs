using System;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private float timer;
    [SerializeField] private float endOfFilmTimer;
    [SerializeField] private float debutDeplacementVertical;

    // Update is called once per frame
    void Update()
    {
        timer = MathF.Round(Time.time);
        
        if(timer >= endOfFilmTimer)
            GameEvents.RaiseEndOfFilmAction();
        
        if(timer >= debutDeplacementVertical)
            GameEvents.RaiseCommenceDeplacementVerticalAction();
    }
}
