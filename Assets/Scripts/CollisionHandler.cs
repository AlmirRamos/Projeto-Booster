
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;

     void OnCollisionEnter(Collision other) 
    {
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
    }

    void StartCrashSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
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
