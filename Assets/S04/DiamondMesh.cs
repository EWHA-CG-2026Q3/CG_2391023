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
            new Vector3(0.5f, 1f, 0.5f),  // 4
            new Vector3(0.5f, -1f, 0.5f)  // 5
        };
    }
}