using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    private UIDocument _uiDocument;

    private Button _optionButton;
    private Button _exitButton;

    private VisualElement _optionContainer;
    
    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();

        var root = _uiDocument.rootVisualElement;

        _optionContainer = root.Q<VisualElement>("Container-Option");
        _optionButton = root.Q<Button>("OptionButton");
        _exitButton = root.Q<Button>("ExitButton");
        
        
        _optionButton.RegisterCallback<ClickEvent>(OptionButtonClick);
        _exitButton.RegisterCallback<ClickEvent>(ExitButtonClick);

        //_optionContainer
    }

    private void OptionButtonClick(ClickEvent evt)
    {
        _optionContainer.style.display = DisplayStyle.Flex;
    }

    private void ExitButtonClick(ClickEvent evt)
    {
        _optionContainer.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
