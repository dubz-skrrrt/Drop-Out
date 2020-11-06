using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public AudioSource Audio;
    public GameObject Current;
    public GameObject Panel;
    //public bool isMuted;
    // Start is called before the first frame update
    public void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Timer();
    }
    void Timer()
    {
        StartCoroutine (Seconds());
    }
    IEnumerator Seconds()
    {
        if(Panel != null)
        {
            yield return new WaitForSeconds (4);
            Audio.mute = !Audio.mute; 
            Current.SetActive(true);
            Panel.SetActive(true);
        }        
    }
}
