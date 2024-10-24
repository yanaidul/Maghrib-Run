using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPageController : MonoBehaviour
{
    public GameObject[] pages;

    private int currentPageIndex = 0;

    void Start()
    {
        UpdateUI();
    }

    public void ShowNextPage()
    {
        currentPageIndex = (currentPageIndex + 1) % pages.Length;
        UpdateUI();
    }

    public void ShowPreviousPage()
    {
        currentPageIndex = (currentPageIndex - 1 + pages.Length) % pages.Length;
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPageIndex);
        }
    }
}
