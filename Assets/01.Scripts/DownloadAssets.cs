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
        //label �� �޷� �ִ� �ֵ��� �� �ٿ�ε� �ϰڴ�.  label�� ���ĸ� �� addressable â���� �� �����ʿ� dropdown���� �����ϴ���.

        //DownloadProgress
        StartCoroutine(CoDonwloadProgress());
        //�ٿ�ε� �Ϸ� �� �̺�Ʈ �߰�.
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
            yield return null;// �� �������� ��ٷ� �ִ� ����.
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
