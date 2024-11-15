using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
   [SerializeField] Button PlayButton;
   [SerializeField] Button ExitButton;

   private void Start()
   {
      PlayButton.onClick.AddListener(LoadGame);
      ExitButton.onClick.AddListener(ExitGame);
   }

   private void LoadGame()
   {
      SceneManager.LoadScene(1);
   }

   private void ExitGame()
   {
      Application.Quit();
   }
}
