using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchView : MonoBehaviour
{
    public static SearchView Instance { get; private set; }
    float time = 10f;
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
        gameObject.SetActive(true);
        StartCoroutine(SearchFight());
    }

    IEnumerator SearchFight()
    {
        while (time >= 0)
        {
            yield return new WaitForSecondsRealtime(1f);
            time--;
            if(time == -2){
                Debug.Log("Fihgt найден");
            }
        }
        Debug.Log("Реальный игрок не найден. Выбран бот");
        FightController.Instance.Show();
        FightController.Instance.SelectBot();
        Hide();
    }

}
