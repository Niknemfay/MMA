using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeName : MonoBehaviour
{
    [SerializeField] PlayerUISOData playerData;
    [SerializeField] TMP_InputField inputFieldName;
    [SerializeField] Button buttonApply;

    private void Start()
    {
        if (!playerData.firstName)
        {
            buttonApply.onClick.AddListener(() =>
            {
                SaveName();
                CustomizeCharacterView.Instance.Show();
                Hide();
            });
        }
        else
        {
            Hide();
        }
    }

    void SaveName()
    {
        playerData.firstName = true;
        playerData.nameUser = inputFieldName.text;
        PlayerUpdateInfo.Instance.UpdatePlayer();
    }
    void Hide()
    {
        gameObject.SetActive(false);
    }
}
