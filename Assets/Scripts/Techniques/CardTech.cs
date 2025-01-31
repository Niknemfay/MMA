using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardTech : MonoBehaviour
{
    [SerializeField] TechniqueSOData techniques;
    [SerializeField] Image iconTech;
    [SerializeField] GameObject maxLevel;
    [SerializeField] Image usingTech;
    [SerializeField] GameObject usingActive;
    [SerializeField] TMP_Text textNameTech;
    [SerializeField] TMP_Text textLevelTech;
    [SerializeField] TMP_Text textPrice;
    [SerializeField] PlayerUISOData playerData;
    [SerializeField] Button buttonLevelUp;
    [SerializeField] Button buttonUsingTechniques;
    Color colorAlfa;
    [Header("Window Level Up")]
    [SerializeField] GameObject windowLevelUp;
    [SerializeField] Image iconLevelUp;
    [SerializeField] TMP_Text nameTechLevelUp;
    [SerializeField] TMP_Text priceTechLevelUp;
    [SerializeField] TMP_Text levelTechLevelUp;
    [SerializeField] Button buttonLevelsUp;

    void Start()
    {
        UpdateInfoTech();
        InitializeButton();
    }

    void InitializeButton()
    {
        buttonLevelUp.onClick.AddListener(() =>
        {
            if (playerData.hits >= techniques.priceHitsTechnique)
            {
                windowLevelUp.SetActive(true);
                OpenWindow(techniques);
            }
        });
        buttonUsingTechniques.onClick.AddListener(() =>
        {
            UsingTehcActive();
        });
    }

    private void UsingTehcActive()
    {

        if (techniques.activeTech)
        {
            if (playerData.countTech <= 3 && playerData.countTech > 0)
            {
                playerData.countTech--;
                colorAlfa.a = 0f;
                usingTech.color = colorAlfa;
                usingActive.SetActive(false);
                techniques.activeTech = false;
            }
        }
        else
        {
            if (playerData.countTech < 3)
            {
                playerData.countTech++;
                colorAlfa = Color.white;
                colorAlfa.a = 255f;
                usingTech.color = colorAlfa;
                usingActive.SetActive(true);
                techniques.activeTech = true;
            }
        }
    }

    void OpenWindow(TechniqueSOData techniques)
    {
        iconLevelUp.sprite = techniques.imageTechnique;
        levelTechLevelUp.text = $"{++techniques.levelTechnique}";
        nameTechLevelUp.text = $"{techniques.nameTechnique}";
        priceTechLevelUp.text = $"{techniques.priceHitsTechnique}";
        buttonLevelsUp.onClick.AddListener(() =>
        {
            if (playerData.hits >= techniques.priceHitsTechnique)
            {
                playerData.hits -= techniques.priceHitsTechnique;
                // рост цены
                techniques.priceHitsTechnique = techniques.priceHitsTechnique + techniques.priceHitsTechnique * 0.3f;
                //
                PlayerUpdateInfo.Instance.UpdateCoinAndHits();
                UpdateInfoTech();
                windowLevelUp.SetActive(false);
            }
        });
    }

    void UpdateInfoTech()
    {
        iconTech.sprite = techniques.imageTechnique;
        textLevelTech.text = $"{techniques.levelTechnique}";
        textNameTech.text = $"{techniques.nameTechnique}";
        textPrice.text = $"{techniques.priceHitsTechnique}";
        if (techniques.levelTechnique >= 25)
        {
            maxLevel.SetActive(true);
        }
        if (techniques.activeTech)
        {
            colorAlfa = Color.white;
            colorAlfa.a = 255f;
            usingTech.color = colorAlfa;
            usingActive.SetActive(true);
        }
    }
}
