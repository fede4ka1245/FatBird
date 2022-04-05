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

            // ����� ����� �� ������ ������������� ���� ������ �������� closing:
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

            // ����� ���� ��������� ������� ����� ������� SceneManager.LoadScene, �� ����������� �������� opening:
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
        // ����� ��� �������� �����, ���� �� �������������, ����������� �������� opening:
        shouldPlayOpeningAnimation = true;

        loadingSceneOperation.allowSceneActivation = true;
    }
}