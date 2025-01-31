using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingGame : MonoBehaviour
{
    [SerializeField] Sprite sprtLoading;
    [SerializeField] Image imageProgressLoadingBar, imageBG;
    private void Start()
    {
        StartCoroutine(TimeLoading());
    }

    IEnumerator TimeLoading()
    {
        while (imageProgressLoadingBar.fillAmount < 0.98f)
        {
            yield return new WaitForSeconds(2f);
            imageProgressLoadingBar.fillAmount += 0.2f;
            if (imageProgressLoadingBar.fillAmount > .5f)
            {
                imageBG.sprite = sprtLoading;
            }
        }
        gameObject.SetActive(false);
    }
}
