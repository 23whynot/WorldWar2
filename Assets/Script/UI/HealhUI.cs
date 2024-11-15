using Script.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class HealhUI : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image[] healthImages;
    
        private int currentHealthIndex;

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
