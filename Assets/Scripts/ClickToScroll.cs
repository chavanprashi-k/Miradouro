using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickToScroll : MonoBehaviour, IPointerDownHandler
{
    public ScrollRect scrollRect; // The ScrollRect component that controls scrolling
    public float scrollAmount = 100f; // How much to scroll per click
    private bool isScrolling = false;

    // This will handle the click-to-scroll functionality
    public void OnPointerDown(PointerEventData eventData)
    {
        // Check if the click is within the bounds of the ScrollView (or the image area)
        if (RectTransformUtility.RectangleContainsScreenPoint(scrollRect.viewport, eventData.position))
        {
            // Determine the scroll direction based on the click position (top or bottom)
            Vector2 localPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(scrollRect.viewport, eventData.position, null, out localPos);

            // If the click is in the top half, scroll up, otherwise scroll down
            if (localPos.y > 0)
            {
                // Scroll up
                scrollRect.verticalNormalizedPosition = Mathf.Clamp(scrollRect.verticalNormalizedPosition + (scrollAmount / scrollRect.viewport.rect.height), 0f, 1f);
            }
            else
            {
                // Scroll down
                scrollRect.verticalNormalizedPosition = Mathf.Clamp(scrollRect.verticalNormalizedPosition - (scrollAmount / scrollRect.viewport.rect.height), 0f, 1f);
            }
        }
    }

    // Optional: Smooth Scroll to the top or bottom (if you want that feature)
    public void ScrollToTop()
    {
        scrollRect.verticalNormalizedPosition = 1f; // Scroll to the top
    }

    public void ScrollToBottom()
    {
        scrollRect.verticalNormalizedPosition = 0f; // Scroll to the bottom
    }
}
