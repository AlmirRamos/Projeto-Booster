
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success, crash;
    [SerializeField] ParticleSystem successParticles, crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }

     void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning){return;}

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
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success); //Emite som quando encostar no quadrado final
        successParticles.Play();//Particulas ativam quando encosta no final
        GetComponent<Movement>().enabled = false; //Desabilita o movimento
        Invoke("LoadNextLevel", levelLoadDelay); //Vai para o proximo level após 2 segundos
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);//Emite som quando esbarra em algo
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;//Desabilita o movimento
        Invoke("ReloadLevel", levelLoadDelay);//Recarrega o jogo após 2 segundos
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
