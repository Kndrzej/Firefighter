using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fire = null;
    [SerializeField] private GameObject errorMessage = null;
    [SerializeField] private Text time = null;
    public static float timeFromStart;
    public static string playerName;
    public static AudioSource audioSource;
    public delegate void CountTimeDelegate();
    public CountTimeDelegate CountTime = delegate { };

    void Start()
    {
        timeFromStart = 0;
        DontDestroyOnLoad(this);
        StartCoroutine(playFireAlarm());
        StartCoroutine(startFire());
    }

    public IEnumerator playFireAlarm()
    {
        yield return new WaitForSeconds(3f);
        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.Play();
    }
    public IEnumerator startFire()
    {
        yield return new WaitForSeconds(3f);
        fire.SetActive(true);
        var particleSystem = fire.GetComponent<ParticleSystem>();
        particleSystem.Play();
    }
   
      
    

    // Update is called once per frame
    void Update()
    {
        if(time != null)
        {
            timeFromStart += Time.deltaTime;
            time.GetComponentInChildren<Text>().text = timeFromStart.ToString();
        }
    }
}
