using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class AddressableLoad : MonoBehaviour
{
    int index;

    public void CreateObj()
    {
        Addressables.InstantiateAsync("Cube", new Vector3(0,0,0), Quaternion.identity); //Adressable�� �̸��� ��ġ
        //ù���� ���ڴ� Ű���ε� name, ��ġ, ��������� ȸ����
        //Quaternion.identity - �� ��ü�� ������ �ִ� �⺻ ȸ����

        GameObject.Find("Cube(Clone").name = "Cube" + index;
        index++;
    }


}
