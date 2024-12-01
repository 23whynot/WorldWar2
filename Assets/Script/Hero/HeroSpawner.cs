using UnityEngine;

namespace Script.Hero
{
    public class HeroSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnLocation;
        public Transform GetHeroSpawnPointTransform()
        {
            return spawnLocation;
        }
    }
}