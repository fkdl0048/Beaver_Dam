using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTester : MonoBehaviour
{
    QuestGenerator questGenerator;
    void Start()
    {
        //1) 이거 하나 있어야 해요
        questGenerator = new QuestGenerator();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //2) 이 함수 쓰면 QuestGenerator.stQuest 를 반환합니다.
            QuestGenerator.stQuest quest = questGenerator.GenerateQuest(3);


            //3) sqQuest.questMaterial는 stMaterial 리스트입니다.
            //4) stMaterial.matColor이 재료 색깔, stMaterial.matType이 재료 타입(돌, 가지...)입니다.
            for (int i = 0; i < 3; i++)
                Debug.Log(quest.questMaterials[i].matColor.ToString() + " " + quest.questMaterials[i].matType.ToString());

            //5) sqQuest.questText가 유저가 볼 지시문입니다.
            Debug.Log(quest.questText);
        }
    }
}
