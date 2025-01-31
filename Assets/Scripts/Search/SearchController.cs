using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button buttonBack;

    public void Initialize()
    {
        InitializeButton();
        SearchView.Instance.Hide();
    }

    private void InitializeButton()
    {
        buttonBack.onClick.AddListener(() =>
        {
            SearchView.Instance.Hide();
        });
    }

}
