using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FlowerMesh : MonoBehaviour
{
    // 꽃잎 개수와 모양 설정
    public int petalCount = 5;
    public float innerRadius = 0.12f;
    public float outerRadius = 0.45f;
    public float petalWidth = 0.18f;
    public int petalSegments = 12;

    void Start()
    {
        CreateFlower();
    }

    void CreateFlower()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        int count = Mathf.Max(3, petalCount);
        int segments = Mathf.Max(2, petalSegments);

        // 꽃잎 개수만큼 반복하여 각각의 꽃잎 생성
        for (int i = 0; i < count; i++)
        {
            // 꽃잎이 원형으로 고르게 배치되도록 각도 계산
            float angle = 2f * Mathf.PI * i / count;

            // 꽃 중심에서 바깥쪽으로 향하는 방향
            Vector3 direction = new Vector3(
                Mathf.Cos(angle),
                Mathf.Sin(angle),
                0f
            );

            // 꽃잎의 좌우 너비를 결정하는 수직 방향
            Vector3 side = new Vector3(
                -Mathf.Sin(angle),
                Mathf.Cos(angle),
                0f
            );

            int start = vertices.Count;

            // 꽃잎의 시작점 (중심 쪽)
            vertices.Add(direction * innerRadius);

            // 꽃잎의 좌우 가장자리를 곡선 형태로 생성
            for (int j = 0; j <= segments; j++)
            {
                float t = (float)j / segments;

                // 시작점과 끝점은 좁고 중간 부분은 넓어짐
                float distance = Mathf.Lerp(
                    innerRadius, outerRadius, t
                );

                float width = Mathf.Sin(t * Mathf.PI)
                    * petalWidth;

                // 왼쪽과 오른쪽 정점 생성
                vertices.Add(
                    direction * distance - side * width
                );

                vertices.Add(
                    direction * distance + side * width
                );
            }

            // 인접한 정점 4개를 삼각형 2개로 연결
            for (int j = 0; j < segments; j++)
            {
                int a = start + 1 + j * 2;
                int b = a + 1;
                int c = a + 2;
                int d = a + 3;

                triangles.Add(a);
                triangles.Add(c);
                triangles.Add(b);

                triangles.Add(b);
                triangles.Add(c);
                triangles.Add(d);
            }
        }

        // 계산한 정점과 삼각형으로 Mesh 생성
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}