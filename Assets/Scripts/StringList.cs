using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringList
{
    public static List<List<int>> typeColorTable;  //재료 - 색깔
    public static List<List<string>> floorStrings; //층 - 요청 텍스트
    public static List<List<string>> typeStrings;  //재료 종류 - 요청 텍스트
    public static List<List<string>> colorStrings; //색깔 - 요청 텍스트

    public StringList()
    {
        //재료 - 색깔 매칭
        typeColorTable = new List<List<int>>();
        typeColorTable.Add(new List<int>() { 0, 3, 4 });
        typeColorTable.Add(new List<int>() { 3, 4, 5 });
        typeColorTable.Add(new List<int>() { 0, 1, 2 });

        //층 - 요청 텍스트 매칭
        floorStrings = new List<List<string>>();
        floorStrings.Add(new List<string>() { "1층에", "첫 번째로", "바닥에", "하늘과 가장 먼 곳에", "8의 0제곱 칸에", "시작 할 때는", "맨 처음엔" });
        floorStrings.Add(new List<string>() { "2층에", "두 번째로", "첫째 재료 위에", "1+3+5-7번째에", "바닥과 가장 가깝지는 않은 곳에", "첫 번째의 다음 순서에", "바닥이 아닌 곳에" });
        floorStrings.Add(new List<string>() { "3층에", "세 번째로", "맨 마지막에", "맨 위에", "9×⅓칸에", "하늘과 가장 가까운 곳에", "바닥과 가장 먼 곳에" });

        //색깔 - 요청 텍스트 매칭
        colorStrings = new List<List<string>>();
        colorStrings.Add(new List<string>() { "초록색", "green", "사이다 맛", "라임 껍질 색", "샐러리 색", "네잎 클로버가 떠오르는", "오이 향기가 나는" });
        colorStrings.Add(new List<string>() { "빨간색", "red", "딸기 맛이 날 것 같은", "케찹 같은", "체리 향기가 날 것 같은", "와인이 마시고 싶어지는", "피가 떠오르는", "노을과 같은" });
        colorStrings.Add(new List<string>() { "노란색", "yellow", "병아리 같은", "머스타드 색의", "3원색 중 봄을 대표하는 색의", "유치원생이 떠오르는", "이무진이 좋아하는", "충치를 치료하면 볼 수 있는 색의", "레몬" });
        colorStrings.Add(new List<string>() { "회색", "gray", "먹구름 같은", "검정과 흰색을 섞은", "금방이라도 비가 올 것 같은", "가장 밝지는 않은 무채색" });
        colorStrings.Add(new List<string>() { "갈색", "brown", "시나몬을 닮은", "커피 맛이 날 듯한", "흙탕물과 비슷한", "통나무가 떠오르는 " });
        colorStrings.Add(new List<string>() { "흰색", "white", "모든 빛을 합친", "북극곰을 닮은", "겨울에 많이 보이는 날도 있는 색의", "버닝 비버 후드티를 닮은" });

        //재료 타입 - 요청 텍스트 매칭
        typeStrings = new List<List<string>>();
        typeStrings.Add(new List<string>() { "나뭇가지를 놔줘.", "나뭇가지를 쌓아줘.", "횃불으로 쓸 수 있는 재료를 두자.", "이파리가 달려 있는 것을 놓고 싶어.", "꽃이 달려있을 때도 있는 것을 쌓아줘." });
        typeStrings.Add(new List<string>() { "돌을 놔줘.", "가장 밀도가 큰 것을 놔줘.", "불에 타지 않는 것을 쌓고 싶어.", "맞으면 죽는 재료를 올려줘.", "화산 폭발할 때 생기는 것을 놔줘." });
        typeStrings.Add(new List<string>() { "이파리를 놔줘.", "가장 얇은 것을 놔줘.", "어느 계절엔 색이 변하는 것을 쌓아줘.", "쉽게 찢어지는 것을 놓고 싶어." });
    }
}
