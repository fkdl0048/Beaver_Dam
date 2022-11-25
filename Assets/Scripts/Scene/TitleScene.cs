using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    public void OnGameStartClicked()
    {
        BeaverGameManager.Instance.ChangeScene(eSCENE_ID.Main);
    }
}
