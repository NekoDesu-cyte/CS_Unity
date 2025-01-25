using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelDelay = 0;
    [SerializeField] AudioClip SuccessSFX;
    [SerializeField] AudioClip CrashSFX;
    [SerializeField] ParticleSystem SuccessParticles;
    [SerializeField] ParticleSystem CrashParticles;

    
    bool isControllAble = true;
    bool isCollideAble = true;

    AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        RespondToDebugKeys();
    }
    void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            NextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollideAble = !isCollideAble;
            Debug.Log("C is pressed");
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (!isControllAble || !isCollideAble) {return;}

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hello!, welcome!!!");
                break;

            case "Finish":
                StartSucceedSeqeunce();
                break;

            case "Fuel":
                Debug.Log("bro... i didn't exist in this game!");
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSucceedSeqeunce()
    {
        isControllAble = false;
        audioSource.Stop();
        audioSource.PlayOneShot(SuccessSFX);
        SuccessParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", levelDelay);
    }

    private void StartCrashSequence()
    {
        // add SFX
        isControllAble = false;
        audioSource.Stop();
        audioSource.PlayOneShot(CrashSFX);
        CrashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelDelay);
    }

    private void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }



    
}
