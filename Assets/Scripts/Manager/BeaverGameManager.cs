using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeaverGameManager : MonoBehaviour
{
    private static string STR_NAME = "Manager";

    private static BeaverGameManager sInstance = null;
    public static BeaverGameManager Instance
    {
        get
        {
            if(sInstance == null)
            {
                GameObject gobj = GameObject.FindGameObjectWithTag(STR_NAME);
                if(gobj == null)
                {
                    gobj = GameObject.Instantiate(new GameObject());
                    DontDestroyOnLoad(gobj);
                }
                sInstance = gobj.AddComponent<BeaverGameManager>();
            }
            return sInstance;
        }
    }

    #region "Scene"
    private BaseScene m_currScene { get; set; }
    public T GetCurrScene<T>() where T : BaseScene
    {
        return this.m_currScene as T;
    }

    public void SaveScene(BaseScene scene)
    {
        this.m_currScene = scene;
    }

    public void ChangeScene(eSCENE_ID eSceneID)
    {
        SceneManager.LoadScene((int)eSceneID);
    }
    #endregion
}