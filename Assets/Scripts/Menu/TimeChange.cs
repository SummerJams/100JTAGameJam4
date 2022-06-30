using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChange : MonoBehaviour
{
    public void Change(bool runOrStay)
    {
        if (runOrStay)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }
}
