using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPause : MonoBehaviour
{
    private ActivationMenu pause;
    private TimeChange time;
    private void Start()
    {
        pause = GetComponent<ActivationMenu>();
        time = GetComponent<TimeChange>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.ActiveMenu(!pause.active);
            time.Change(!pause.active);
        }
    }
}
