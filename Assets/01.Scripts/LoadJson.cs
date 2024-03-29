using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

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
            }
        }
    }











    // Update is called once per frame
    void Update()
    {

    }
}