using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Splines;

public class PlayerHand : MonoBehaviour
{
    public int maxHandSize;
    public GameObject CardPrefab;
    public SplineContainer splineContainer;
    public Transform spawnPoint;
    public Canvas canvas;
    public List<GameObject> handCards = new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DrawCard();
        }
    }
    private void DrawCard()
    {
        if (handCards.Count >= maxHandSize) return;
        GameObject g = Instantiate(CardPrefab, spawnPoint.position, spawnPoint.rotation, canvas.transform);
        handCards.Add(g);
        UpdateCardPositions();
    }

    private void UpdateCardPositions()
    {
        if (handCards.Count == 0) return;

        float cardSpacing = 1f / maxHandSize;
        float firstCardPosition = 0.5f - (handCards.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < handCards.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;

            // Get the position directly in spline space (already in canvas space)
            Vector3 localPos = spline.EvaluatePosition(p);

            Debug.Log("wrking");

            RectTransform rt = handCards[i].GetComponent<RectTransform>();
            if (rt != null)
            {
                // Directly move to the position within canvas space
                StartCoroutine(MoveCardSmoothly(rt, (Vector2)localPos, 0.25f));
            }
        }
    }
    private IEnumerator<WaitForSeconds> MoveCardSmoothly(RectTransform rt, Vector2 targetPosition, float duration)
    {
        Vector2 startPos = rt.anchoredPosition;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            rt.anchoredPosition = Vector2.Lerp(startPos, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        rt.anchoredPosition = targetPosition;
    }
}
