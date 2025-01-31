using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipCharacterView : MonoBehaviour
{
    public static EquipCharacterView Instance { get; private set; }
    [SerializeField] PlayerUISOData playerData;
    [SerializeField] private int currentIndexBody;
    [SerializeField] private int currentIndexGloves = 0;
    [SerializeField] private int currentIndexShorts = 0;
    [Space(10)]
    [Header("Text Element")]
    [SerializeField] TMP_Text[] textElements;
    [SerializeField] Color colorWhite, colorGreen;
    [Space(10)]
    [Header("Apply Element")]
    [SerializeField] GameObject applyWindow;
    [Space(10)]
    [Header("Player Element")]
    [SerializeField] Image bodyPlayer;
    [SerializeField] Image headPlayer;
    [SerializeField] Image hairPlayer;
    [SerializeField] Image glovesPlayer;
    [SerializeField] Image shortsPlayer;

    [Header("Player Visual Main Element")]
    [SerializeField] Image body;
    [SerializeField] Image head;
    [SerializeField] Image hair;
    [SerializeField] Image gloves;
    [SerializeField] Image shorts;
    [Space(10)]
    [Header("Player Visual Prev Element")]
    [SerializeField] Image bodyPrev;
    [SerializeField] Image headPrev;
    [SerializeField] Image hairPrev;
    [SerializeField] Image glovesPrev;
    [SerializeField] Image shortsPrev;
    [Space(10)]
    [Header("Player Visual Next Element")]
    [SerializeField] Image bodyNext;
    [SerializeField] Image headNext;
    [SerializeField] Image hairNext;
    [SerializeField] Image glovesNext;
    [SerializeField] Image shortsNext;
    [Space(20)]
    [Header("SO")]
    [SerializeField] GlovesEquipSO[] glovesEquips;
    [SerializeField] ShortsEquipSO[] shortsEquips;

    private void Awake()
    {
        Instance = this;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        UpdateInfoVisualBodyElement();
        gameObject.SetActive(true);
    }

    private void UpdateInfoVisualBodyElement()
    {
        bodyPlayer.sprite = playerData.body;
        headPlayer.sprite = playerData.head;
        hairPlayer.sprite = playerData.hair;
        body.sprite = playerData.body;
        head.sprite = playerData.head;
        hair.sprite = playerData.hair;
        bodyPrev.sprite = playerData.body;
        headPrev.sprite = playerData.head;
        hairPrev.sprite = playerData.hair;
        bodyNext.sprite = playerData.body;
        headNext.sprite = playerData.head;
        hairNext.sprite = playerData.hair;
    }

    public void NextButton(int indexCell)
    {
        switch (indexCell)
        {
            case 0: // gloves
                currentIndexGloves = (currentIndexGloves + 1) % glovesEquips[currentIndexBody].gloves.Length;
                UpdateVisualGlovesElements();
                break;
            case 1: // shorts
                currentIndexShorts = (currentIndexShorts + 1) % shortsEquips[currentIndexBody].shorts.Length;
                UpdateVisualShortsElements();
                break;
        }
    }

    public void PrevButton(int indexCell)
    {
        switch (indexCell)
        {
            case 0: // gloves
                currentIndexGloves = (currentIndexGloves - 1 + glovesEquips[currentIndexBody].gloves.Length) % glovesEquips[currentIndexBody].gloves.Length;
                UpdateVisualGlovesElements();
                break;
            case 1: // shorts
                currentIndexShorts = (currentIndexShorts - 1 + shortsEquips[currentIndexBody].shorts.Length) % shortsEquips[currentIndexBody].shorts.Length;
                UpdateVisualShortsElements();
                break;
        }
    }


    public void ChangeColor(int index)
    {
        for (int i = 0; i < textElements.Length; i++)
        {
            textElements[i].color = colorGreen;
        }
        textElements[index].color = colorWhite;
    }

    public void UpdateVisualGlovesElements()
    {
        // Обновляем Main элемент
        gloves.sprite = glovesEquips[currentIndexBody].gloves[currentIndexGloves];
        // head.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        glovesPlayer.sprite = glovesEquips[currentIndexBody].gloves[currentIndexGloves];
        // headPlayer.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        // Save
        playerData.gloves = glovesEquips[currentIndexBody].gloves[currentIndexGloves];
        // playerData.head = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        // Обновляем Prev элемент
        int prevIndex = (currentIndexGloves - 1 + glovesEquips[currentIndexBody].gloves.Length) % glovesEquips[currentIndexBody].gloves.Length;
        glovesPrev.sprite = glovesEquips[currentIndexBody].gloves[prevIndex];
        // headPrev.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[prevIndex];

        // Обновляем Next элемент
        int nextIndex = (currentIndexGloves + 1) % glovesEquips[currentIndexBody].gloves.Length;
        glovesNext.sprite = glovesEquips[currentIndexBody].gloves[nextIndex];
        // headNext.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[nextIndex];
    }

    public void UpdateVisualShortsElements()
    {
        // Обновляем Main элемент
        shorts.sprite = shortsEquips[currentIndexBody].shorts[currentIndexShorts];
        // head.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        shortsPlayer.sprite = shortsEquips[currentIndexBody].shorts[currentIndexShorts];
        // headPlayer.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        // Save
        playerData.shorts = shortsEquips[currentIndexBody].shorts[currentIndexShorts];
        // playerData.head = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        // Обновляем Prev элемент
        int prevIndex = (currentIndexShorts - 1 + shortsEquips[currentIndexBody].shorts.Length) % shortsEquips[currentIndexBody].shorts.Length;
        shortsPrev.sprite = shortsEquips[currentIndexBody].shorts[prevIndex];
        // headPrev.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[prevIndex];

        // Обновляем Next элемент
        int nextIndex = (currentIndexShorts + 1) % shortsEquips[currentIndexBody].shorts.Length;
        shortsNext.sprite = shortsEquips[currentIndexBody].shorts[nextIndex];
        // headNext.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[nextIndex];
    }
    public void ShowApplyWindow()
    {
        applyWindow.SetActive(true);
    }

    public void HideApplyWindow()
    {
        applyWindow.SetActive(false);
    }

}