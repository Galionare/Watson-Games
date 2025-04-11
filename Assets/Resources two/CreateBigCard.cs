using UnityEngine;
using UnityEngine.EventSystems;

public class CreateBigCard : MonoBehaviour
{
    public RectTransform ThisCard;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {

            if (!IsPointerOverUIObject(gameObject))
            {
                Destroy(gameObject);
            }
        }
    }
    bool IsPointerOverUIObject(GameObject target)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        foreach (var result in raycastResults)
        {
            if (result.gameObject == target || result.gameObject.transform.IsChildOf(target.transform))
            {
                return true;
            }
        }

        return false;
    }
}
