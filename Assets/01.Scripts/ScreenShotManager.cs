using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotManager : MonoBehaviour
{

    public RawImage PhotoDownload;
    public void TakeScreenShot()
    {
        StartCoroutine(CoTakeScreenShot());
    }


    IEnumerator CoTakeScreenShot()
    {
        //�� ������ �н��� ����? ����ϰ� �ִ� ��⸶�� ������ �Ǿ� �ִ�  windows, android ���..
        Directory.CreateDirectory(Application.persistentDataPath + "/Photo");

        //RenderTexture�� �ؽ��ĸ� ��� �ӽ÷� ���� ������ ���� �� �ִ� ��ü.  �ſ� ���� �ǰ�?
        // �� ģ���� ���ο� ���� ���� ��ũ���� ũ��� �����ϰ� ������ ����.  24�� ����Ƽ
        RenderTexture renderTexture = new RenderTexture((int)Screen.width, (int)Screen.height, 24);

        Texture2D texture = new Texture2D((int)Screen.width, (int)Screen.height, TextureFormat.RGB24, false);
        yield return new WaitForEndOfFrame(); // ������ ������ ���� ��ٸ���.  ������ Render �ϱ⸦ ��ٸ��°ǰ�?

        Camera.main.targetTexture = renderTexture;  //camera â�� inspector â�� �ִ� �׸���.  ��ư�� ������ Ÿ�� �ؽ��Ŀ� ������ ������
        //�̰� ������Ʈ â���� �������� RenderTexture�� ���� �ִ°Ÿ� �� �� ����.  (��ſ� �Ʒ����� Camera.main.targetTexture = null�� �ּ� ����� ����) �ȱ׷��� ��� ���ٰ� �ٽ� �����.

        Camera.main.Render(); //

        RenderTexture.active = renderTexture; //�̰� ���� ������ ���� �����ǰ�?
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0); // �� ������ ��ŭ ��� �д´�
        texture.Apply();  //

        PhotoDownload.texture = texture;


        //�׸��� �ٽ� �ʱ�ȭ�� ���ֱ� ������ �� �ڷδ� �ٽ� ���������� ī�޶� ��� �ִ� ȭ���� ������ �ϰ� ��.
        Camera.main.targetTexture = null;
        RenderTexture.active = null;

        //�ٵ� ���� ī�޶� ������ Ui���� ī�޶� �������� ����.
        //�ֳ� Canvasw�� overlayŸ���̱� ������.   camera-overlay�ų� world�� ī�޶� ����.
    }




}
