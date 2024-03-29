using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class AddressableLoad : MonoBehaviour
{
    int index;

    public void CreateObj()
    {
        Addressables.InstantiateAsync("Cube", new Vector3(0,0,0), Quaternion.identity); //Adressable의 이름과 위치
        //첫번쨰 인자는 키값인데 name, 위치, 사원수값의 회전값
        //Quaternion.identity - 그 객체가 가지고 있는 기본 회전값

        GameObject.Find("Cube(Clone").name = "Cube" + index;
        index++;
    }


}
