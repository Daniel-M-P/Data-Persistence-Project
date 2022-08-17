using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text BestScore;
    [SerializeField] private InputField playerName;

    private void Start()
    {
        if(DataManager.Instance.pData.playerName != null)
        {
            playerName.text = DataManager.Instance.pData.playerName;
        }
        if(DataManager.Instance.pData.bestScore > 0)
        {
            BestScore.text = "Best Score " + DataManager.Instance.pData.bestScore;
        }
    }
    public void StartScene()
    {
        SceneManager.LoadScene(1);
        DataManager.Instance.pData.playerName = playerName.text;
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
#else
				        Application.Quit(); // original code to quit Unity player
#endif
        DataManager.Instance.SaveData();
    }
}
