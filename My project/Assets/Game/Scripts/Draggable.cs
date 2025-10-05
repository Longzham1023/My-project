using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public Image image;
    public string itemId;
    public bool isLocked = false;
    void Start()
    {
        string currentItem = PlayerPrefs.GetString("CurrentItemId", "");
        int isLockedInt = PlayerPrefs.GetInt("IsItemLocked", 0);

        if (itemId == currentItem && isLockedInt == 1)
        {
            isLocked = true;
        }
        else
        {
            isLocked = false;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        if (!isLocked)
        {
            PlayerPrefs.SetString("CurrentItemId", itemId);
            PlayerPrefs.SetInt("IsItemLocked", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("SmallTask");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
