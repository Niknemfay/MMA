using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeCharacterController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button bodyButton;
    [SerializeField] Button skinButton;
    [SerializeField] Button faceButton;
    [SerializeField] Button hairButton;
    [SerializeField] Button nextButton;
    [SerializeField] Button prevButton;
    [SerializeField] Button applyButton;
    [SerializeField] Button buttonClose;
    [SerializeField] Button applyButtonYes;
    [SerializeField] Button applyButtonNo;

    [Header("Panel Customize")]
    [SerializeField] GameObject panelBodyAndSkin;
    [SerializeField] GameObject panelHeadAndHair;

    public void Initialize()
    {
        InitializeButton();
        panelHeadAndHair.SetActive(false);
        CustomizeCharacterView.Instance.Hide();
    }

    void InitializeButton()
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
        bodyButton.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySecondaryButton();
            CustomizeCharacterView.Instance.ChangeColor(0);

            panelBodyAndSkin.SetActive(true);
            panelHeadAndHair.SetActive(false);

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
        skinButton.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySecondaryButton();
            CustomizeCharacterView.Instance.UpdateVisualSkinsElements();

            CustomizeCharacterView.Instance.ChangeColor(1);

            panelBodyAndSkin.SetActive(true);
            panelHeadAndHair.SetActive(false);

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
        faceButton.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySecondaryButton();
            CustomizeCharacterView.Instance.UpdateVisualHeadElements();
            CustomizeCharacterView.Instance.ChangeColor(2);

            panelBodyAndSkin.SetActive(false);
            panelHeadAndHair.SetActive(true);
            ResetAllButton();
            nextButton.onClick.AddListener(() =>
            {
                SelectNext(2);
                SoundController.Instance.PlaySwipeButton();
            });
            prevButton.onClick.AddListener(() =>
            {
                SelectPrev(2);
                SoundController.Instance.PlaySwipeButton();
            });
        });
        hairButton.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySecondaryButton();
            CustomizeCharacterView.Instance.ChangeColor(3);

            panelBodyAndSkin.SetActive(false);
            panelHeadAndHair.SetActive(true);

            ResetAllButton();
            nextButton.onClick.AddListener(() =>
            {
                SelectNext(3);
                SoundController.Instance.PlaySwipeButton();
            });
            prevButton.onClick.AddListener(() =>
            {
                SelectPrev(3);
                SoundController.Instance.PlaySwipeButton();
            });
        });

        buttonClose.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySoundButtonClose();
            CustomizeCharacterView.Instance.ShowApplyWindow();
        });
        applyButton.onClick.AddListener(() =>
        {
            CustomizeCharacterView.Instance.ShowApplyWindow();
        });
        applyButtonNo.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySoundButtonNo();
            CustomizeCharacterView.Instance.HideApplyWindow();
        });
        applyButtonYes.onClick.AddListener(() =>
        {
            SoundController.Instance.PlaySoundButtonYes();
            PlayerUpdateInfo.Instance.UpdatePlayer();
            CustomizeCharacterView.Instance.HideApplyWindow();
            CustomizeCharacterView.Instance.Hide();
        });
    }

    void SelectNext(int index)
    {
        CustomizeCharacterView.Instance.NextButton(index);
    }
    void SelectPrev(int index)
    {
        CustomizeCharacterView.Instance.PrevButton(index);
    }
    void ResetAllButton()
    {
        nextButton.onClick.RemoveAllListeners();
        prevButton.onClick.RemoveAllListeners();
    }
}
