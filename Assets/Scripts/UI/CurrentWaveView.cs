using System;
using TMPro;
using UnityEngine;

public class CurrentWaveView : MonoBehaviour
{
   [SerializeField] private WaveSpawner _waveSpawner;
   
   private TextMeshProUGUI _TMP;

   private void OnEnable()
   {
      _waveSpawner.WaveStart += ctx => PrintNewWaveInfoNumber(ctx);
   }

   private void OnDisable()
   {
      _waveSpawner.WaveStart -= PrintNewWaveInfoNumber;
   }

   private void Awake()
   {
      _TMP = GetComponent<TextMeshProUGUI>();
   }

   private void PrintNewWaveInfoNumber(int waveNumber)
   {
      _TMP.text = "Wave " + waveNumber;
   }
}
