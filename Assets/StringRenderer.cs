using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StringRenderer : MonoBehaviour
{

    public Transform point1;
    public Transform point2;
    public Transform point3;
    public LineRenderer lineRenderer;

    public int vertexCount = 12;

    private void Update()
    {
        var middlePoint = Vector3.Lerp(point1.transform.position, point3.transform.position, 0.5f);
        point2.transform.position = Vector3.Lerp(point2.transform.position, middlePoint, 0.1f);
        var list = new List<Vector3>();
        for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
        {
            var tanV1 = Vector3.Lerp(point1.position, point2.position, ratio);
            var tanV2 = Vector3.Lerp(point2.position, point3.position, ratio);
            var bezP = Vector3.Lerp(tanV1, tanV2, ratio);
            list.Add(bezP);
        }
        lineRenderer.positionCount = list.Count;
        lineRenderer.SetPositions(list.ToArray());
    }

    public void centerString()
    {
        point2.transform.position = Vector3.Lerp(point1.transform.position, point3.transform.position, 0.5f);
    }
}
