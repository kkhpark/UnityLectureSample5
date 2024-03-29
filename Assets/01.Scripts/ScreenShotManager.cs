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
        //이 데이터 패스는 어디냐? 사용하고 있는 기기마다 지정이 되어 있대  windows, android 등등..
        Directory.CreateDirectory(Application.persistentDataPath + "/Photo");

        //RenderTexture는 텍스쳐를 어딘가 임시로 상을 맺히게 해줄 수 있는 객체.  거울 같은 건가?
        // 이 친구의 가로와 세로 값은 스크린의 크기와 동일하게 지정을 해줌.  24는 퀄리티
        RenderTexture renderTexture = new RenderTexture((int)Screen.width, (int)Screen.height, 24);

        Texture2D texture = new Texture2D((int)Screen.width, (int)Screen.height, TextureFormat.RGB24, false);
        yield return new WaitForEndOfFrame(); // 마지막 프레임 까지 기다린다.  완전히 Render 하기를 기다리는건가?

        Camera.main.targetTexture = renderTexture;  //camera 창의 inspector 창에 있는 항목임.  버튼을 누르면 타겟 텍스쳐에 뭔가가 입혀짐
        //이걸 컴포넌트 창에서 눌러보면 RenderTexture가 맺혀 있는거를 볼 수 있음.  (대신에 아랫줄의 Camera.main.targetTexture = null을 주석 해줘야 보임) 안그러면 잠깐 들어갔다가 다시 사라짐.

        Camera.main.Render(); //

        RenderTexture.active = renderTexture; //이게 무슨 프레임 버퍼 같은건가?
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0); // 요 사이즈 만큼 모두 읽는다
        texture.Apply();  //

        PhotoDownload.texture = texture;


        //그리고 다시 초기화를 해주기 때문에 그 뒤로는 다시 정상적으로 카메라가 찍고 있는 화면을 랜더링 하게 됨.
        Camera.main.targetTexture = null;
        RenderTexture.active = null;

        //근데 메인 카메라를 찍으면 Ui들은 카메라에 맺히지가 않음.
        //왜냐 Canvasw가 overlay타입이기 때문에.   camera-overlay거나 world면 카메라에 맺힘.
    }




}
