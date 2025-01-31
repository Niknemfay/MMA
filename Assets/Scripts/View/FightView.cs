using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightView : MonoBehaviour
{
    public static FightView Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
