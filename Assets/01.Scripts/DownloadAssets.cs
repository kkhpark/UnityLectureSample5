using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownloadAssets : MonoBehaviour
{
    public Text DownloadProgress;
    public Slider ProgressBar;
    public GameObject SceneButton;


    public string LabelForBundle;
    AsyncOperationHandle DownloadHandle;




    // Start is called before the first frame update
    void Start()
    {
        DownloadProgress.text = "0 %";
        ProgressBar.value = 0;
        DownloadBundle();
    }

    void DownloadBundle()
    {
        DownloadHandle = Addressables.DownloadDependenciesAsync(LabelForBundle);
        //label 이 달려 있는 애들은 싹 다운로드 하겠다.  label이 뭐냐면 그 addressable 창에서 맨 오른쪽에 dropdown으로 선택하던거.

        //DownloadProgress
        StartCoroutine(CoDonwloadProgress());
        //다운로드 완료 시 이벤트 추가.
        DownloadHandle.Completed += (Handle) =>
        {
            //Change Scene
            SceneButton.SetActive(true);
        };

    }

    IEnumerator CoDonwloadProgress()
    {
        while (true)
        {
            DownloadProgress.text = string.Concat(DownloadHandle.PercentComplete * 100, "%");
            ProgressBar.value = DownloadHandle.PercentComplete;
            yield return null;// 한 프레임을 기다려 주는 역할.
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
