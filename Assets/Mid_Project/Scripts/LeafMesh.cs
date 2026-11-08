using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class LeafMesh : MonoBehaviour
{
    public int segments = 12;
    public float leafLength = 0.6f;
    public float leafWidth = 0.2f;

    void Start()
    {
        CreateLeaf();
    }

    void CreateLeaf()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        // 나뭇잎 중심선과 양쪽 가장자리 생성
        for (int i = 0; i <= segments; i++)
        {
            float t = (float)i / segments;

            float y = t * leafLength;
            float width = Mathf.Sin(t * Mathf.PI) * leafWidth;

            vertices.Add(new Vector3(-width, y, 0f));
            vertices.Add(new Vector3(width, y, 0f));
        }

        // 삼각형들을 연결해 나뭇잎 표면 생성
        for (int i = 0; i < segments; i++)
        {
            int index = i * 2;

            triangles.Add(index);
            triangles.Add(index + 1);
            triangles.Add(index + 2);

            triangles.Add(index + 1);
            triangles.Add(index + 3);
            triangles.Add(index + 2);
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}