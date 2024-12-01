using UnityEngine;

namespace Script.Enemy
{
   public class EnemyPositionContainer : MonoBehaviour
   {
      [SerializeField] Transform maxPoint;
      [SerializeField] Transform minPoint;

      public Vector3 GetRandomPosition()
      {
         return new Vector3(Random.Range(minPoint.position.x, maxPoint.position.x),Random.Range(minPoint.position.y, maxPoint.position.y),Random.Range(minPoint.position.z, maxPoint.position.z));
      }
   }
}
