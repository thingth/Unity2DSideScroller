using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public float xMin = -2000;
    public float xMax = 2000;
    public float yMin;
    public float yMax = 1;

    private Transform targetP;

	void LateUpdate () //Good for camera
    {
        if (targetP == null)
        {
            targetP = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(targetP.position.x, xMin, xMax), Mathf.Clamp(targetP.position.y, yMin, yMax), transform.position.z);
        }
    }
}
