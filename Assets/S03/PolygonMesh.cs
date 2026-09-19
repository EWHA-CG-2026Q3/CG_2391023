

using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PolygonMesh : MonoBehaviour
{
    void Start()
    {
        // 정점 5개로 오각형 만들기
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 1.5f, 0f),   // 0
            new Vector3(1.5f, 0.5f, 0f), // 1
            new Vector3(1f, -1f, 0f),    // 2
            new Vector3(-1f, -1f, 0f),   // 3
            new Vector3(-1.5f, 0.5f, 0f) // 4
        };

        // 정점 3개씩 묶어서 삼각형 3개 구성
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        GetComponent<MeshRenderer>().sharedMaterial =
            new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }
}
