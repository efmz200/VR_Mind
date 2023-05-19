using UnityEngine;

public class BoxDetection : MonoBehaviour
{
    public Material boxMaterial;
    public GameObject planeObject;
    public GameObject bolas;

    private void OnCollisionEnter(Collision collision)
    {
        Renderer objectRenderer = collision.gameObject.GetComponent<Renderer>();
        if (objectRenderer != null && objectRenderer.sharedMaterial == boxMaterial && collision.gameObject == planeObject)
        {
            Destroy(gameObject);
            
            int count = GetRemainingBallsCount();
            
            Debug.Log("Bolas faltantes: " + count);
            if (count == 0)
            {
                Debug.Log("Juego Completado");
            }
        }
    }
    private int GetRemainingBallsCount()
    {
        int count = 0;
        if (bolas != null)
        {
            count = bolas.transform.childCount - 1;
        }
        return count;
    }
}