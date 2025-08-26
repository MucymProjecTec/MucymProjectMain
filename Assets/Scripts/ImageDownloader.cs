using UnityEngine;
using UnityEngine.UI;

public class ExportarImagen : MonoBehaviour
{
    [Header("Si lo dejas vacío, buscará el Image automáticamente")]
    [SerializeField] private Image displayImage;

    [Header("Ruta dentro de Resources sin extensión")]
    [SerializeField] private string resourcePath = "Target"; // Assets/Resources/Target.jpg

    void Awake()
    {
        if (displayImage == null)
        {
            displayImage = GetComponent<Image>();
            if (displayImage == null)
                displayImage = GetComponentInChildren<Image>(true);
        }
    }

    // Asigna este método al OnClick del botón
    public void CargarImagen()
    {
        if (displayImage == null)
        {
            Debug.LogError("[ExportarImagen] No encontré ningún componente Image en este objeto ni en sus hijos.");
            return;
        }

        // 1) Intentar cargar como Sprite (si el import es Sprite 2D & UI)
        Sprite sprite = Resources.Load<Sprite>(resourcePath);

        if (sprite == null)
        {
            // 2) Intentar cargar como Texture2D (si el import es Default/Texture)
            Texture2D tex = Resources.Load<Texture2D>(resourcePath);
            if (tex == null)
            {
                Debug.LogError($"[ExportarImagen] No se encontró '{resourcePath}' en Assets/Resources/ (como Sprite ni como Texture2D).");
                return;
            }

            sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
        }

        displayImage.sprite = sprite;
        displayImage.preserveAspect = true;
        Debug.Log("[ExportarImagen] Imagen cargada correctamente.");
    }
}
