using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private Text nickname = null;
    [SerializeField] private Text time = null;

    private void Awake()
    {
        nickname.text = MainMenu.playerName;
        time.text = GameManager.timeFromStart.ToString();
        Cursor.visible = true;
    }

    public void EndGame()
    {
        Application.Quit();
    }
    public void Replay()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
