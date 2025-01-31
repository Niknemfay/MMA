using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipCharacterController : MonoBehaviour
{

    [Header("Buttons")]
    [SerializeField] Button glovesButton;
    [SerializeField] Button shortsButton;
    [SerializeField] Button nextButton;
    [SerializeField] Button prevButton;
    [SerializeField] Button applyButton;
    [SerializeField] Button buttonClose;
    [SerializeField] Button applyButtonYes;
    [SerializeField] Button applyButtonNo;

    // [Header("Game Objects")]
    // [SerializeField] GameObject[] gloves;
    // [SerializeField] GameObject[] shorts;

    public void Initialize()
    {
        InitializeButton();
        EquipCharacterView.Instance.Hide();
    }

    private void InitializeButton()
    {
        nextButton.onClick.AddListener(() =>
        {
            SelectNext(0);
            SoundController.Instance.PlaySwipeButton();
        });
        prevButton.onClick.AddListener(() =>
        {
            SelectPrev(0);
            SoundController.Instance.PlaySwipeButton();
        });
        glovesButton.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySecondaryButton();
            EquipCharacterView.Instance.ChangeColor(0);
            // for (int i = 0; i < gloves.Length; i++)
            // {
            //     gloves[i].SetActive(true);
            //     shorts[i].SetActive(false);
            // }
            ResetAllButton();
            nextButton.onClick.AddListener(() =>
            {
                SelectNext(0);
                SoundController.Instance.PlaySwipeButton();
            });
            prevButton.onClick.AddListener(() =>
            {
                SelectPrev(0);
                SoundController.Instance.PlaySwipeButton();
            });
        });
        shortsButton.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySecondaryButton();
            EquipCharacterView.Instance.ChangeColor(1);

            // for (int i = 0; i < gloves.Length; i++)
            // {
            //     gloves[i].SetActive(false);
            //     shorts[i].SetActive(true);
            // }

            ResetAllButton();
            nextButton.onClick.AddListener(() =>
            {
                SelectNext(1);
                SoundController.Instance.PlaySwipeButton();
            });
            prevButton.onClick.AddListener(() =>
            {
                SelectPrev(1);
                SoundController.Instance.PlaySwipeButton();
            });
        });
        buttonClose.onClick.AddListener(() =>
       {
           SoundController.Instance.PlaySoundButtonClose();
           EquipCharacterView.Instance.ShowApplyWindow();
       });
        applyButton.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySecondaryButton();
            EquipCharacterView.Instance.ShowApplyWindow();
        });
        applyButtonNo.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySoundButtonNo();
            EquipCharacterView.Instance.HideApplyWindow();
        });
        applyButtonYes.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySoundButtonYes();
            PlayerUpdateInfo.Instance.UpdatePlayer();
            EquipCharacterView.Instance.HideApplyWindow();
            EquipCharacterView.Instance.Hide();
        });
    }

    void SelectNext(int index)
    {
        EquipCharacterView.Instance.NextButton(index);
    }
    void SelectPrev(int index)
    {
        EquipCharacterView.Instance.PrevButton(index);
    }
    void ResetAllButton()
    {
        nextButton.onClick.RemoveAllListeners();
        prevButton.onClick.RemoveAllListeners();
    }
}