using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    private UIDocument _uiDocument;

    // stage 
    private Button _quesButton;
    private VisualElement _inGameOne;
    private VisualElement _inGameTwo;
    
    // Option
    private Button _optionButton;
    private Button _exitButton;
    private VisualElement _optionContainer;
    
    // Quest Button
    private Button _branchButton;
    private Button _stoneButton;
    private Button _leafButton;
    private VisualElement _branchContainer;
    private VisualElement _stoneContainer;
    private VisualElement _leafContainer;
    private Button _branchGreen;
    private Button _branchGray;
    private Button _branchBrown;
    private Button _stoneGray;
    private Button _stoneBrown;
    private Button _stoneWhite;
    private Button _leafGreen;
    private Button _leafRed;
    private Button _leafYellow;

    private int currentIdx, prevIdx;

    void Start()
    {
        // UIDoucment Init
        _uiDocument = GetComponent<UIDocument>();
        prevIdx = -1;

        var root = _uiDocument.rootVisualElement;

        // Option Init
        _optionContainer = root.Q<VisualElement>("Container-Option");
        _optionButton = root.Q<Button>("OptionButton");
        _exitButton = root.Q<Button>("ExitButton");
        
        // Option Event Add
        _optionButton.RegisterCallback<ClickEvent>(OptionButtonClick);
        _exitButton.RegisterCallback<ClickEvent>(ExitButtonClick);
        
        // InGame
        _quesButton = root.Q<Button>("QuestText");
        _inGameOne = root.Q<VisualElement>("InGameOne");
        _inGameTwo = root.Q<VisualElement>("InGameTwo");
        _quesButton.RegisterCallback<ClickEvent>(OnChange);

        // Quest Button Init
        _branchButton = root.Q<Button>("BranchButton");
        _stoneButton = root.Q<Button>("StoneButton");
        _leafButton = root.Q<Button>("LeafButton");
        _branchContainer = root.Q<VisualElement>("BranchList");
        _stoneContainer = root.Q<VisualElement>("StoneList");
        _leafContainer = root.Q<VisualElement>("LeafList");
        
        _branchGreen = root.Q<Button>("BranchGreen");
        _branchGray = root.Q<Button>("BranchGray");
        _branchBrown = root.Q<Button>("BranchBrown");
        _stoneGray = root.Q<Button>("StoneGray");
        _stoneBrown = root.Q<Button>("StoneBrown");
        _stoneWhite = root.Q<Button>("StoneWhite");
        _leafGreen = root.Q<Button>("LeafGreen");
        _leafRed = root.Q<Button>("LeafRed");
        _leafYellow = root.Q<Button>("LeafYellow");
        
        // Quest Button Event Add
        _branchButton.RegisterCallback<ClickEvent>(OpenQuestContainerBracnch);
        _stoneButton.RegisterCallback<ClickEvent>(OpenQuestContainerStone);
        _leafButton.RegisterCallback<ClickEvent>(OpenQuestContainerLeaf);
        
        _branchGreen.RegisterCallback<ClickEvent>(OnbranchGreen);
        _branchGray.RegisterCallback<ClickEvent>(OnbranchGray);
        _branchBrown.RegisterCallback<ClickEvent>(OnbranchBrown);
        _stoneGray.RegisterCallback<ClickEvent>(OnStoneGray);
        _stoneBrown.RegisterCallback<ClickEvent>(OnStoneBrown);
        _stoneWhite.RegisterCallback<ClickEvent>(OnStoneWhite);
        _leafGreen.RegisterCallback<ClickEvent>(OnLeafGreen);
        _leafRed.RegisterCallback<ClickEvent>(OnLeafRed);
        _leafYellow.RegisterCallback<ClickEvent>(OnLeafYellow);
        
        
    }

    #region Option

    private void OptionButtonClick(ClickEvent evt)
    {
        _optionContainer.style.display = DisplayStyle.Flex;
    }

    private void ExitButtonClick(ClickEvent evt)
    {
        _optionContainer.style.display = DisplayStyle.None;
    }

    #endregion

    #region QuestButton

    private void OpenQuestContainerBracnch(ClickEvent evt)
    {
        QuestContainerReset();
        
        _branchContainer.style.display = DisplayStyle.Flex;
    }

    private void OpenQuestContainerStone(ClickEvent evt)
    {
        QuestContainerReset();
        
        _stoneContainer.style.display = DisplayStyle.Flex;
    }
    
    private void OpenQuestContainerLeaf(ClickEvent evt)
    {
        QuestContainerReset();
        
        _leafContainer.style.display = DisplayStyle.Flex;
    }

    private void OnbranchGreen(ClickEvent evt)
    {
        _branchContainer.style.display = DisplayStyle.None;
    }
    
    private void OnbranchGray(ClickEvent evt)
    {
        _branchContainer.style.display = DisplayStyle.None;
    }
    
    private void OnbranchBrown(ClickEvent evt)
    {
        _branchContainer.style.display = DisplayStyle.None;
    }
    
    private void OnStoneGray(ClickEvent evt)
    {
        _stoneContainer.style.display = DisplayStyle.None;
    }

    private void OnStoneBrown(ClickEvent evt)
    {
        _stoneContainer.style.display = DisplayStyle.None;
    }
    
    private void OnStoneWhite(ClickEvent evt)
    {
        _stoneContainer.style.display = DisplayStyle.None;
    }

    private void OnLeafGreen(ClickEvent evt)
    {
        _leafContainer.style.display = DisplayStyle.None;
    }
    
    private void OnLeafRed(ClickEvent evt)
    {
        _leafContainer.style.display = DisplayStyle.None;
    }
    
    private void OnLeafYellow(ClickEvent evt)
    {
        _leafContainer.style.display = DisplayStyle.None;
    }

    private void QuestContainerReset()
    {
        _branchContainer.style.display = DisplayStyle.None;
        _stoneContainer.style.display = DisplayStyle.None;
        _leafContainer.style.display = DisplayStyle.None;
    }

    #endregion

    #region InGame

    private void OnChange(ClickEvent evt)
    {
        if (_inGameOne.style.display == DisplayStyle.Flex)
        {
            _inGameOne.style.display = DisplayStyle.None;
            _inGameTwo.style.display = DisplayStyle.Flex;
        }
        else
        {
            _inGameOne.style.display = DisplayStyle.Flex;
            _inGameTwo.style.display = DisplayStyle.None;
        }

        
    } 

    #endregion


    private void Update()
    {
        //currentIdx = BeaverGameManager.Instance.GetCurrScene<MainScene>().currentQuestIdx;
        
        
        currentIdx = BeaverGameManager.Instance.GetCurrScene<MainScene>().currentQuestIdx;
        if (currentIdx != prevIdx)
        {
            prevIdx = currentIdx;
            _quesButton.text = BeaverGameManager.Instance.GetCurrScene<MainScene>().GetAskText();
        }
        // Debug.Log(BeaverGameManager.Instance.GetCurrScene<MainScene>());
        
    }

    private void Test()
    {
        

    }
}
