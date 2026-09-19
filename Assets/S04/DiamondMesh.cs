using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class DiamondMesh : MonoBehaviour
{
    void Start()
    {
        // 다이아몬드 정점 6개 만들기
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f), // 0
            new Vector3(1f, 0f, 0f), // 1
            new Vector3(1f, 0f, 1f), // 2
            new Vector3(0f, 0f, 1f), // 3

            // 위/아래 꼭짓점
            new Vector3(0.5f, 1.5f, 0.5f),  // 4
            new Vector3(0.5f, -1.5f, 0.5f)  // 5
        };
        // 다이아몬드의 삼각형 8개
        int[] triangles = new int[]
        {
            // 위쪽 4면
            4, 1, 0,
            4, 2, 1,
            4, 3, 2,
            4, 0, 3,

            // 아래쪽 4면
            5, 0, 1,
            5, 1, 2,
            5, 2, 3,
            5, 3, 0
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