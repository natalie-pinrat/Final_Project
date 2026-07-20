using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;

}
