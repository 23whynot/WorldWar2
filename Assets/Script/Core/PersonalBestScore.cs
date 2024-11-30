using TMPro;
using UnityEngine;


public class PersonalBestScore : MonoBehaviour
{
    [SerializeField] private SaveLoad load;
    [SerializeField] private PBScoreUI pBScoreUI;

    private void Awake()
    {
        load.OnLoaded += SetCount;
    }

    private void SetCount()
    {
        pBScoreUI.SetCount(load.loadedData);
    }

    private void OnDisable()
    {
        load.OnLoaded -= SetCount;
    }
}
