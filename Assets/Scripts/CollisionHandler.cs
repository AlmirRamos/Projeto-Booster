
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    public float levelLoadDelay = 2f;
    public AudioClip audioColision, audioFinish;

    AudioSource audioSource;

     void OnCollisionEnter(Collision other) 
    {

        audioSource = GetComponent<AudioSource>();

        switch (other.gameObject.tag)
        {
            case "Inicio":
                Debug.Log("Pronto para sair");
                break;
            case "Finish":
                Debug.Log("Voce chegou ao Final vivo!");
                StartSuccessSequence();
                break;
            default:
                Debug.Log("Voce explodiu! Tente novamente");
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
        audioSource.PlayOneShot(audioFinish);
    }

    void StartCrashSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
         audioSource.PlayOneShot(audioColision);
    }


    void LoadNextLevel()
    {
         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
         int nextSceneIndex = currentSceneIndex + 1;
         if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
         {
            nextSceneIndex = 0;
         }
         SceneManager.LoadScene(nextSceneIndex);
        
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
