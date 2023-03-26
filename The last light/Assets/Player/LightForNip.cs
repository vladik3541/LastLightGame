using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightForNip : MonoBehaviour
{
    public SolarL sol;
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "SolarLamp")
        {
            sol.solarUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "SolarLamp")
        {
            sol.solarUp = false;
        }
    }
}
