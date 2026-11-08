
using UnityEngine;

public class FlowerSway : MonoBehaviour
{
    public float swayAngle = 5f;
    public float swaySpeed = 1.5f;
    public float moveAmount = 0.03f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        float wave = Mathf.Sin(Time.time * swaySpeed);

        // 1. 이동 행렬
        Matrix4x4 moveMatrix = Matrix4x4.Translate(
            new Vector3(wave * moveAmount, 0f, 0f)
        );

        // 2. 회전 행렬
        Matrix4x4 rotateMatrix = Matrix4x4.Rotate(
            Quaternion.Euler(0f, 0f, wave * swayAngle)
        );

        // 3. 이동 + 회전 행렬 결합
        Matrix4x4 result = moveMatrix * rotateMatrix;

        // 4. 계산한 변환 적용
        transform.localPosition =
            originalPosition + result.MultiplyPoint3x4(Vector3.zero);

        transform.localRotation =
            originalRotation * rotateMatrix.rotation;
    }
}
