using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public float scrollSpeed = 40f;

    private RectTransform reactTransform;

    void Start()
    {
        reactTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        reactTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
