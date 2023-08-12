using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
        public AudioSource audioSource;
        public GameObject mute,unMute;
    void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("Music"));
    }
    

    public void LoadScene(){
         SceneManager.LoadScene("Level1");
    }

    public void Mute()
    {
            audioSource.mute = !audioSource.mute;
            mute.SetActive(false);
            unMute.SetActive(true);
    }
    public void UnMute()
    {
            
            audioSource.mute = !audioSource.mute;
            mute.SetActive(true);
            unMute.SetActive(false);
    }
   

}
