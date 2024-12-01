using Script.Core;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Script.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image[] healthImages;
    
        private int currentHealthIndex;
        private Health _health;

        [Inject]
        public void Construct(Health health)
        {
            _health = health;
        }

        private void Start()
        {
            _health.OnHealthChanged += TakeDamage;

            currentHealthIndex = healthImages.Length - 1;
        }

        private void TakeDamage()
        {
            if (currentHealthIndex >= 0)
            {
                healthImages[currentHealthIndex].gameObject.SetActive(false);
                currentHealthIndex--;
            }
        }

        private void OnDestroy()
        {
            _health.OnHealthChanged -= TakeDamage;
        }
    }
}
