using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeCharacterView : MonoBehaviour
{
    public static CustomizeCharacterView Instance { get; private set; }
    [SerializeField] PlayerVisualStartSO[] playerVisualStart;

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

    [Header("Skin Visual Element")]
    [SerializeField] BodyCostomizeSO[] bodyCostomizes;



    [Space(20)]
    [Header("Head Visual Element")]
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_1;
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_2;
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_3;
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_4;
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_5;
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_6;
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_7;
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_8;
    [SerializeField] HeadCustomizeSO[] customizationHeadArray_9;
    public List<HeadCustomizeSO[]> headCustomizations = new List<HeadCustomizeSO[]>();

    [Space(20)]
    [Header("Hair Visual Element")]
    [SerializeField] HairCustomizeSO[] customizationHairArray_1;
    [SerializeField] HairCustomizeSO[] customizationHairArray_2;
    [SerializeField] HairCustomizeSO[] customizationHairArray_3;
    [SerializeField] HairCustomizeSO[] customizationHairArray_4;
    [SerializeField] HairCustomizeSO[] customizationHairArray_5;
    [SerializeField] HairCustomizeSO[] customizationHairArray_6;
    [SerializeField] HairCustomizeSO[] customizationHairArray_7;
    [SerializeField] HairCustomizeSO[] customizationHairArray_8;
    [SerializeField] HairCustomizeSO[] customizationHairArray_9;
    public List<HairCustomizeSO[]> hairCustomizations = new List<HairCustomizeSO[]>();

    [SerializeField] Image facePrev;
    [SerializeField] Image faceMain;
    [SerializeField] Image faceNext;

    [SerializeField] Image hairFacePrev;
    [SerializeField] Image hairFaceMain;
    [SerializeField] Image hairFaceNext;

    [Space(20)]
    [SerializeField] private int currentIndexBody = 0;
    [SerializeField] private int currentIndexSkin = 0;
    [SerializeField] private int currentIndexHead = 0;
    [SerializeField] private int currentIndexHair = 0;


    [SerializeField] PlayerUISOData playerData;
    private void Awake()
    {
        Instance = this;
        ListAddArray();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        UpdateVisualElements();
        UpdateVisualHeadElements();
        gameObject.SetActive(true);
    }

    public void NextButton(int indexCell)
    {
        switch (indexCell)
        {
            case 0: // body
                currentIndexBody = (currentIndexBody + 1) % playerVisualStart.Length;
                UpdateVisualElements();
                break;
            case 1: // skin
                currentIndexSkin = (currentIndexSkin + 1) % bodyCostomizes[currentIndexBody].spritesSkinBody.Length;
                UpdateVisualSkinsElements();
                break;
            case 2:
                HeadCustomizeSO element = headCustomizations[currentIndexBody][currentIndexSkin];
                currentIndexHead = (currentIndexHead + 1) % element.headSprites.Length;
                UpdateVisualHeadElements();
                break;
            case 3:
                HairCustomizeSO elementHair = hairCustomizations[currentIndexBody][currentIndexHead];
                currentIndexHair = (currentIndexHair + 1) % elementHair.hairSprite.Length;
                UpdateVisualHairElements();
                break;
        }
    }

    public void PrevButton(int indexCell)
    {
        switch (indexCell)
        {
            case 0: // body
                currentIndexBody = (currentIndexBody - 1 + playerVisualStart.Length) % playerVisualStart.Length;
                UpdateVisualElements();
                break;
            case 1: // skin
                currentIndexSkin = (currentIndexSkin - 1 + bodyCostomizes[currentIndexBody].spritesSkinBody.Length) % bodyCostomizes[currentIndexBody].spritesSkinBody.Length;
                UpdateVisualSkinsElements();
                break;
            case 2:
                HeadCustomizeSO element = headCustomizations[currentIndexBody][currentIndexSkin];
                currentIndexHead = (currentIndexHead - 1 + element.headSprites.Length) % element.headSprites.Length;
                UpdateVisualHeadElements();
                break;
            case 3:
                HairCustomizeSO elementHair = hairCustomizations[currentIndexBody][currentIndexHead];
                currentIndexHair = (currentIndexHair - 1 + elementHair.hairSprite.Length) % elementHair.hairSprite.Length;
                UpdateVisualHairElements();
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
    public void UpdateVisualSkinsElements()
    {
        // Обновляем Main элемент
        body.sprite = bodyCostomizes[currentIndexBody].spritesSkinBody[currentIndexSkin];
        head.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        bodyPlayer.sprite = bodyCostomizes[currentIndexBody].spritesSkinBody[currentIndexSkin];
        headPlayer.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        // Save
        playerData.body = bodyCostomizes[currentIndexBody].spritesSkinBody[currentIndexSkin];
        playerData.head = bodyCostomizes[currentIndexBody].spritesSkinHead[currentIndexSkin];
        // Обновляем Prev элемент
        int prevIndex = (currentIndexSkin - 1 + bodyCostomizes[currentIndexBody].spritesSkinBody.Length) % bodyCostomizes[currentIndexBody].spritesSkinBody.Length;
        bodyPrev.sprite = bodyCostomizes[currentIndexBody].spritesSkinBody[prevIndex];
        headPrev.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[prevIndex];

        // Обновляем Next элемент
        int nextIndex = (currentIndexSkin + 1) % bodyCostomizes[currentIndexBody].spritesSkinBody.Length;
        bodyNext.sprite = bodyCostomizes[currentIndexBody].spritesSkinBody[nextIndex];
        headNext.sprite = bodyCostomizes[currentIndexBody].spritesSkinHead[nextIndex];
    }

    private void UpdateVisualElements()
    {
        // Обновляем Main элемент
        body.sprite = playerVisualStart[currentIndexBody].body;
        head.sprite = playerVisualStart[currentIndexBody].head;
        hair.sprite = playerVisualStart[currentIndexBody].hair;
        gloves.sprite = playerVisualStart[currentIndexBody].gloves;
        shorts.sprite = playerVisualStart[currentIndexBody].shorts;
        bodyPlayer.sprite = playerVisualStart[currentIndexBody].body;
        headPlayer.sprite = playerVisualStart[currentIndexBody].head;
        hairPlayer.sprite = playerVisualStart[currentIndexBody].hair;
        glovesPlayer.sprite = playerVisualStart[currentIndexBody].gloves;
        shortsPlayer.sprite = playerVisualStart[currentIndexBody].shorts;
        // Save
        playerData.body = playerVisualStart[currentIndexBody].body;
        playerData.head = playerVisualStart[currentIndexBody].head;
        playerData.hair = playerVisualStart[currentIndexBody].hair;
        playerData.indexBody = currentIndexBody;
        // Обновляем Prev элемент
        int prevIndex = (currentIndexBody - 1 + playerVisualStart.Length) % playerVisualStart.Length;
        bodyPrev.sprite = playerVisualStart[prevIndex].body;
        headPrev.sprite = playerVisualStart[prevIndex].head;
        hairPrev.sprite = playerVisualStart[prevIndex].hair;
        glovesPrev.sprite = playerVisualStart[prevIndex].gloves;
        shortsPrev.sprite = playerVisualStart[prevIndex].shorts;

        // Обновляем Next элемент
        int nextIndex = (currentIndexBody + 1) % playerVisualStart.Length;
        bodyNext.sprite = playerVisualStart[nextIndex].body;
        headNext.sprite = playerVisualStart[nextIndex].head;
        hairNext.sprite = playerVisualStart[nextIndex].hair;
        glovesNext.sprite = playerVisualStart[nextIndex].gloves;
        shortsNext.sprite = playerVisualStart[nextIndex].shorts;
    }


    public void UpdateVisualHeadElements()
    {
        HeadCustomizeSO element = headCustomizations[currentIndexBody][currentIndexSkin];
        HairCustomizeSO elementHair = hairCustomizations[currentIndexBody][currentIndexHead];
        faceMain.sprite = element.headSprites[currentIndexHead];
        hairFaceMain.sprite = elementHair.hairSprite[currentIndexHair];

        headPlayer.sprite = element.headSprites[currentIndexHead];
        hairPlayer.sprite = elementHair.hairSprite[currentIndexHair];
        // SAVE
        playerData.head = element.headSprites[currentIndexHead];
        playerData.hair = elementHair.hairSprite[currentIndexHair];

        int prevIndex = (currentIndexHead - 1 + element.headSprites.Length) % element.headSprites.Length;
        facePrev.sprite = element.headSprites[prevIndex];
        hairFacePrev.sprite = elementHair.hairSprite[prevIndex];

        int nextIndex = (currentIndexHead + 1) % element.headSprites.Length;
        faceNext.sprite = element.headSprites[nextIndex];
        hairFaceNext.sprite = elementHair.hairSprite[nextIndex];
    }
    private void UpdateVisualHairElements()
    {
        HairCustomizeSO elementHair = hairCustomizations[currentIndexBody][currentIndexHead];
        hairFaceMain.sprite = elementHair.hairSprite[currentIndexHair];

        hairPlayer.sprite = elementHair.hairSprite[currentIndexHair];

        facePrev.sprite = playerData.head;
        faceMain.sprite = playerData.head;
        faceNext.sprite = playerData.head;
        // Save

        playerData.hair = elementHair.hairSprite[currentIndexHair];

        // Обновляем Prev элемент

        int prevIndex = (currentIndexHair - 1 + elementHair.hairSprite.Length) % elementHair.hairSprite.Length;
        hairFacePrev.sprite = elementHair.hairSprite[prevIndex];

        // Обновляем Next элемент
        int nextIndex = (currentIndexHair + 1) % elementHair.hairSprite.Length;
        hairFaceNext.sprite = elementHair.hairSprite[nextIndex];
    }

    void ListAddArray()
    {
        headCustomizations.Add(customizationHeadArray_1);
        headCustomizations.Add(customizationHeadArray_2);
        headCustomizations.Add(customizationHeadArray_3);
        headCustomizations.Add(customizationHeadArray_4);
        headCustomizations.Add(customizationHeadArray_5);
        headCustomizations.Add(customizationHeadArray_6);
        headCustomizations.Add(customizationHeadArray_7);
        headCustomizations.Add(customizationHeadArray_8);
        headCustomizations.Add(customizationHeadArray_9);

        hairCustomizations.Add(customizationHairArray_1);
        hairCustomizations.Add(customizationHairArray_2);
        hairCustomizations.Add(customizationHairArray_3);
        hairCustomizations.Add(customizationHairArray_4);
        hairCustomizations.Add(customizationHairArray_5);
        hairCustomizations.Add(customizationHairArray_6);
        hairCustomizations.Add(customizationHairArray_7);
        hairCustomizations.Add(customizationHairArray_8);
        hairCustomizations.Add(customizationHairArray_9);
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
