using System;
using TMPro;
using UnityEngine;

public class CurrentWaveView : MonoBehaviour
{

   private TextMeshProUGUI _TMP;
   
   private void Awake()
   {
      GlobalEventManager.OnWaveStart.AddListener(PrintNewWaveInfoNumber);
      _TMP = GetComponent<TextMeshProUGUI>();
   }

   private void PrintNewWaveInfoNumber(int waveNumber)
   {
      _TMP.text = "Wave " + waveNumber;
   }
}
