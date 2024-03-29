using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

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
            }
        }
    }











    // Update is called once per frame
    void Update()
    {

    }
}