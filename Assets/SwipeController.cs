using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SwipeController : MonoBehaviour, IEndDragHandler
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPosition;

    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPageRect;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;
    float dragThreshold;
    [SerializeField] Image[] barImages;
    [SerializeField] Sprite barActive, barInactive;

    [SerializeField] Button prevButton, nextButton;

    private void Awake()
    {
        currentPage = 1;
        targetPosition = levelPageRect.localPosition;
        dragThreshold = Screen.width / 15; // 20% of screen width
        UpdateBar();
        UpdateArrowbuttons();
    }
    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPosition += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPosition -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPageRect.LeanMoveLocal(targetPosition, tweenTime).setEase(tweenType);
        UpdateBar();
        UpdateArrowbuttons();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshold)
        {
            if (eventData.position.x > eventData.pressPosition.x) Previous();
            else Next();
        }
        else
        {
            MovePage();
        }
    }

    void UpdateBar()
    {
        foreach (var item in barImages)
        {
            item.sprite = barInactive;
        }
        barImages[currentPage - 1].sprite = barActive;
    }

    void UpdateArrowbuttons()
    {
        nextButton.interactable = true;
        prevButton.interactable = true;
        if (currentPage == 1)
        { 
            prevButton.interactable = false;
        }
        else if (currentPage == maxPage)
        {
            nextButton.interactable = false;
        }
    }
}
