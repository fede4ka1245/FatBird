using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{

    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false;
    private static bool isLoading;

    [SerializeField]
    private GameObject blockScreen;


    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        if (!isLoading)
        {
            instance.BlockClicks();
            isLoading = true;
            instance.componentAnimator.SetTrigger("SceneEnd");

            instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

            // Чтобы сцена не начала переключаться пока играет анимация closing:
            instance.loadingSceneOperation.allowSceneActivation = false;
        }
    }

    private void Start()
    {
        instance = this;

        componentAnimator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            instance.BlockClicks();
            componentAnimator.SetTrigger("SceneStart");

            // Чтобы если следующий переход будет обычным SceneManager.LoadScene, не проигрывать анимацию opening:
            shouldPlayOpeningAnimation = false;
        }
    }
    public void BlockClicks()
    {
        instance.blockScreen.SetActive(true);
    }

    public void UnBlockClicks()
    {
        instance.blockScreen.SetActive(false);
    }
    public void OnAnimationOver()
    {
        isLoading = false;
        // Чтобы при открытии сцены, куда мы переключаемся, проигралась анимация opening:
        shouldPlayOpeningAnimation = true;

        loadingSceneOperation.allowSceneActivation = true;
    }
}