using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTester : MonoBehaviour
{
    void Start()
    {
        //1) �̰� �ϳ� �־�� �ؿ�. �ٵ� main scene���� �����Ұ���
        //stringList = new StringList();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //2) ��� ��û ������ ��ü �����ϸ� �˾Ƽ� �������� ��������ϴ�.
            stQuest quest = new stQuest(3);

            //3) sqQuest.questMaterial�� stMaterial ����Ʈ�Դϴ�.
            //4) stMaterial.matColor�� ��� ����, stMaterial.matType�� ��� Ÿ��(��, ����...)�Դϴ�.
            for (int i = 0; i < 3; i++)
                Debug.Log(quest.questMaterials[i].matColor.ToString() + " " + quest.questMaterials[i].matType.ToString());

            //5) sqQuest.questText�� ������ �� ���ù��Դϴ�.
            Debug.Log(quest.questText);
        }
    }
}
