using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpdateInfo : MonoBehaviour
{
    public static PlayerUpdateInfo Instance { get; private set; }
    [SerializeField] PlayerUISOData playerData;

    [SerializeField] TMP_Text[] namePlayer;
    [SerializeField] Image[] bodyPlayer;
    [SerializeField] Image[] headPlayer;
    [SerializeField] Image[] hairPlayer;
    [SerializeField] Image[] glovesPlayer;
    [SerializeField] Image[] shortsPlayer;

    [Header("Coin and Hits")]
    [SerializeField] TMP_Text[] coins;
    [SerializeField] TMP_Text[] hits;
    private void Awake()
    {
        Instance = this;
        UpdatePlayer();
        UpdateCoinAndHits();
    }

    public void UpdatePlayer()
    {
        for (int i = 0; i < namePlayer.Length; i++)
        {
            namePlayer[i].text = playerData.nameUser;
        }
        for (int i = 0; i < bodyPlayer.Length; i++)
        {
            bodyPlayer[i].sprite = playerData.body;
            headPlayer[i].sprite = playerData.head;
            hairPlayer[i].sprite = playerData.hair;
            glovesPlayer[i].sprite = playerData.gloves;
            shortsPlayer[i].sprite = playerData.shorts;
        }
    }

    public void UpdateCoinAndHits()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].text = $"{playerData.coins}";
            hits[i].text = $"{playerData.hits}";
        }
    }

}
