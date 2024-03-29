using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Loadjson : MonoBehaviour
{
    [Serializable] // android에서의 그 serializable , bytearray등으로 parsing해서 전송이 가능한 형태
    public struct Images
    {
        public string Name;
        public string URL;
    }

    [SerializeField]
    public Images[] bannerImage;

    public MeshRenderer[] Quad;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetJson()); // 이렇게 해야함.
    }

    IEnumerator GetJson()
    {
        string url = "https://addressableproject.s3.ap-northeast-2.amazonaws.com/JSON/ImageJSON.json";//Json 의 주소

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();  //요청과 함께 양보 한다는 의미

        if (UnityWebRequest.Result.ConnectionError == request.result)
        {
            //"There is no internet"
        }
        else
        {
            if (request.isDone)
            {
                bannerImage = JsonHelper.GetArray<Images>(request.downloadHandler.text);
                StartCoroutine(GetImage());
            }
        }
    }


    IEnumerator GetImage()
    {
        for (int i = 0; i < bannerImage.Length; i++)
        {
            using (UnityWebRequest w = UnityWebRequestTexture.GetTexture(bannerImage[i].URL))
            {
                yield return w.SendWebRequest();

                if (w.result != UnityWebRequest.Result.Success)
                {
                    //Failed.
                    Debug.Log(w.error);
                }
                else
                {
                    Texture2D tx = DownloadHandlerTexture.GetContent(w);
                    Quad[i].material.mainTexture = tx;
                    // apply texture.
                }

            }
        }

    }








    // Update is called once per frame
    void Update()
    {

    }
}