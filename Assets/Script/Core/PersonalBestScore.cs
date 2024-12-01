using Script.SaveLoadSystem;
using Script.UI;
using UnityEngine;
using Zenject;

namespace Script.Core
{
    public class PersonalBestScore : MonoBehaviour
    {
        [SerializeField] private PBScoreUI pBScoreUI;

        private SaveLoad _load;

        [Inject]
        public void Construct(SaveLoad saveLoad)
        {
            _load = saveLoad;
            _load.OnLoaded += SetCount;
        }

        private void SetCount()
        {
            pBScoreUI.SetCount(_load.loadedData);
        }

        private void OnDisable()
        {
            _load.OnLoaded -= SetCount;
        }
    }
}