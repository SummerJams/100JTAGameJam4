using UnityEngine;
using System;

public class EnemySpawnPoint : MonoBehaviour
{
   [SerializeField] private Transform[] _points;
   private bool _pointIs0;

   private void Awake()
   {
      transform.position = _points[0].position;
      _pointIs0 = true;
   }

   private void OnBecameVisible()
   {
      Debug.Log("OnBecameVisible");

      if (_pointIs0)
      {
         transform.position = _points[1].position;
         _pointIs0 = false;
      }
      else
      {
         transform.position = _points[0].position;
         _pointIs0 = true;
      }
      
   }
}
