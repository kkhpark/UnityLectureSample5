using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Loadjson : MonoBehaviour
{
    [Serializable] // android������ �� serializable , bytearray������ parsing�ؼ� ������ ������ ����
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
        StartCoroutine(GetJson()); // �̷��� �ؾ���.
    }

    IEnumerator GetJson()
    {
        string url = "https://addressableproject.s3.ap-northeast-2.amazonaws.com/JSON/ImageJSON.json";//Json �� �ּ�

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();  //��û�� �Բ� �纸 �Ѵٴ� �ǹ�

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