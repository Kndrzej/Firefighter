using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    private InputField inputField;
    private Button startGame;
    public static string playerName;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void OnEndEdit()
    {
        inputField = GetComponentInChildren<InputField>();
        startGame = GetComponentInChildren<Button>();
        playerName = inputField.text;
        Debug.Log(playerName);
        startGame.interactable = true;
    }
    public void OnClick()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("FireLevel");
    }
}
