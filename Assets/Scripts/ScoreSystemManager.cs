using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystemManager : MonoBehaviour
{
    public bool triggered = false;

    private void OnTriggerEnter()
    {
        if (gameObject.tag == "Destroy")
        {
            triggered = true;
        }
    }
}
