using UnityEngine;
[ExecuteAlways]

public class Pointer : MonoBehaviour
{
    public LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit hit;

        Vector3 origin = transform.position + transform.forward;
        Vector3 direction = transform.forward;

        Vector3 p1 = transform.position + transform.forward;
        Vector3 p2 = transform.position + transform.forward * 3f;

        Vector3[] positions = new Vector3[2];

        positions[0] = p1;
        positions[1] = p2;

        if (Physics.Raycast(origin, direction, out hit, 35f))
        {
            positions[1] = hit.point;

            Debug.DrawRay(origin, direction * hit.distance, Color.green);

            line.startColor = Color.white;
            line.endColor = Color.white;
        }
        else
        {
            positions[1] = origin + direction * 20f;

            Debug.DrawRay(origin, direction * 20f, Color.red);

            line.startColor = Color.blue;
            line.endColor = Color.blue;
        }
        line.SetPositions(positions);
    }
}