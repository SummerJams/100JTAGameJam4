using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


public class WaveSpawnPoint : MonoBehaviour
{
   [SerializeField] private Transform _point;
   [SerializeField] private float _timeOnOnePosition;
   private float _timeOnOnePositionRemain;

   private void Update()
   {
      if (_timeOnOnePositionRemain <= 0)
      {
         MoveToNewPosition();
      }
      else
      {
         _timeOnOnePositionRemain -= Time.deltaTime;
      }
      
   }
   
   
   private void OnBecameVisible()
   {
      Debug.Log("OnBecameVisible");
      MoveToNewPosition();
   }

   private void MoveToNewPosition()
   {
      transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, Random.Range(-2f, 2f),
         transform.rotation.w);
      _timeOnOnePositionRemain = _timeOnOnePosition;
   }
}

   