using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button buttonDayReward;
    [SerializeField] Button buttonShop;
    [SerializeField] Button buttonTechniqs;
    [SerializeField] Button buttonEquip;
    [SerializeField] Button buttonAchivment;
    [SerializeField] Button buttonFight;
    [SerializeField] Button buttonDailyMission;
    [SerializeField] Button buttonMenu;
    [SerializeField] Button buttonTopPlayer;
    [SerializeField] Button buttonAddCoin;
    [SerializeField] Button buttonAddHits;

    public void Initialize()
    {
        InitializeButton();
    }
    void InitializeButton()
    {
        buttonAchivment.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
        buttonAddCoin.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
        buttonAddHits.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
        buttonDailyMission.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
        buttonDayReward.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
        buttonEquip.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
            EquipCharacterView.Instance.Show();
        });
        buttonFight.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
            SearchView.Instance.Show();
        });
        buttonMenu.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
        buttonShop.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
        buttonTechniqs.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
        buttonTopPlayer.onClick.AddListener(() =>
        {
            SoundController.Instance.PlayMainButtons();
        });
    }
}
