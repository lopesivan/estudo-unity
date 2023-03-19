using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    public int numVertices = 32; // número de vértices do círculo
    public float radius = 1f; // raio do círculo

    void Start()
    {
        // cria um novo objeto e adiciona um componente de malha
        GameObject circle = new GameObject("Circle");
        MeshFilter meshFilter = circle.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = circle.AddComponent<MeshRenderer>();

        // cria um novo objeto Mesh
        Mesh mesh = new Mesh();

        // define os vértices do círculo
        Vector3[] vertices = new Vector3[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            float angle = i * Mathf.PI * 2f / numVertices;
            vertices[i] = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);
        }

        // define os triângulos da malha para formar o círculo
        int[] triangles = new int[numVertices * 3];
        for (int i = 0; i < numVertices; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 1) % numVertices + 1;
        }

        // define a normal e os UVs da malha
        Vector3[] normals = new Vector3[numVertices];
        Vector2[] uv = new Vector2[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            normals[i] = Vector3.forward;
            uv[i] = new Vector2(vertices[i].x, vertices[i].y);
        }

        // define a malha com os vértices, triângulos, normal e UVs
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // define a malha do filtro de malha
        meshFilter.mesh = mesh;

        // define o material do renderer de malha
        meshRenderer.material = new Material(Shader.Find("Standard"));
    }
}
