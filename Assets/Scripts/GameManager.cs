using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fire = null;
    [SerializeField] private GameObject errorMessage = null;
    [SerializeField] private Text time = null;

    public static float TimeFromStart;
    public static string PlayerName;
    public static AudioSource AudioSource;
    public delegate void CountTimeDelegate();
    public CountTimeDelegate CountTime = delegate { };

    void Start()
    {
        TimeFromStart = 0;
        DontDestroyOnLoad(this);
        StartCoroutine(PlayFireAlarm());
        StartCoroutine(StartFire());
    }
    void Update()
    {
        if(time != null)
        {
            TimeFromStart += Time.deltaTime;
            time.GetComponentInChildren<Text>().text = TimeFromStart.ToString();
        }
    }

    public IEnumerator PlayFireAlarm()
    {
        yield return new WaitForSeconds(3f);
        AudioSource = GetComponentInChildren<AudioSource>();
        AudioSource.Play();
    }
    public IEnumerator StartFire()
    {
        yield return new WaitForSeconds(3f);
        fire.SetActive(true);
        var particleSystem = fire.GetComponent<ParticleSystem>();
        particleSystem.Play();
    }
}
