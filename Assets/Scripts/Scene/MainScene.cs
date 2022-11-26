using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    StringList stringList = new StringList();

    List<stQuest> questList = new List<stQuest>(); //비버들이 요청할 내용들
    int currentQuestIdx;    //현재 스테이지에서 작업중인 퀘스트 인덱스
    int userWorkingFloor;   //현재 퀘스트에서 작업중인 층(0부터)
    bool isQuestSuccess;
    int failCnt;

    public List<DamMaterial> chosenMaterials;  //유저가 택한 재료들

    void StartGame()
    {
        failCnt = 0;
        StartStage();
    }

    //스테이지 시작
    //퀘스트들을 만들고 첫번째 비버 입장
    void StartStage()
    {
        currentQuestIdx = -1;
        for (int i = 0; i < 5; i++) questList.Add(new stQuest());
        FadeInOut();
        BeaverEnter();
    }

    //손님 비버 입장(인게임 1)
    void BeaverEnter()
    {
        currentQuestIdx++;
        ResetMaterials();
        /*
        1. 카메라 위치를 인게임 1용 오브젝트 있는 곳으로 바꿈.
        2. 비버 통통 등장하는 애니메이션
        3. UI에서 텍스트 뜸
        */

    }

    //제작 장소로 이동(인게임 2)
    void MoveToIngame2()
    {
        isQuestSuccess = true;
        /*
        1. 카메라 위치를 인게임 2용 오브젝트 있는 곳으로 바꿈. 
        */
    }

    //유저가 재료 완성했을 때(재료 추가할 때) 불림
    void AddUserChosenMaterial(stMaterial material)
    {
        isQuestSuccess &= questList[currentQuestIdx].CheckRightMaterial(material, userWorkingFloor);
        chosenMaterials[userWorkingFloor].InitMaterial(material, userWorkingFloor);
        userWorkingFloor++;
    }

    //재료 모두 초기화(유저가 직접 제거할 때, 다음 주문 받을려고 자동으로 넘어갈 때 쓰임)
    void ResetMaterials()
    {
        for (int i = 0; i < chosenMaterials.Count; i++) chosenMaterials[i].RemoveFromScene();
        userWorkingFloor = 0;
    }

    //완성품 제출.
    void SubmitDam()
    {
        if (!isQuestSuccess) failCnt++;
        BeaverLeave();
    }

    //손님 비버 퇴장(다시 인게임 1로 돌아올 때)
    void BeaverLeave()
    {
        if (isQuestSuccess)
        {

        }
        else
        {

        }
        /*
        1. 카메라 위치를 인게임 1용 오브젝트 있는 곳으로 바꿈.
        2. 비버 통통 떠나는 애니메이션
        */
        currentQuestIdx++;

        if (currentQuestIdx == 5) EndStage();
    }

    //스테이지 종료
    void EndStage()
    {
        //다음 스테이지 넘어가는 UI 띄우기
    }

    void FadeInOut()
    {

    }
}