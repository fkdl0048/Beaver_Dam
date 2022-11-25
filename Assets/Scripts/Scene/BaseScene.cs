using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSCENE_ID
{
    Title = 0,
    Main
}

public abstract class BaseScene : MonoBehaviour
{
    [SerializeField] private eSCENE_ID m_eScene = eSCENE_ID.Title;

    protected virtual void Start()
    {
        BeaverGameManager.Instance.SaveScene(this);
    }
}
