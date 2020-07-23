using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    private InputField inputField;
    private Button startGame;
    public static string PlayerName;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void OnEndEdit()
    {
        inputField = GetComponentInChildren<InputField>();
        startGame = GetComponentInChildren<Button>();
        PlayerName = inputField.text;
        Debug.Log(PlayerName);
        startGame.interactable = true;
    }
    public void OnClick()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("FireLevel");
    }
}
