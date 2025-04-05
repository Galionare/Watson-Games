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
            // Skip if clicking over another UI element (like a button)
            /*if (EventSystem.current.IsPointerOverGameObject())
            {
                    // Check if the click is inside this UI element
                Vector2 mousePos = Input.mousePosition;
                if (RectTransformUtility.RectangleContainsScreenPoint(ThisCard, mousePos, null))
                {
                        // Clicked inside the UI element — do nothing
                    return;
                }
            }

            else // Clicked outside — destroy the UI prefab
            {
                Destroy(gameObject);
            }*/

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
