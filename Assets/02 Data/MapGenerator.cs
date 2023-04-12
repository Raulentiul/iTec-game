using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;

public class MapGenerator : MonoBehaviour {
    public Transform playertransf;
    float playerX, playerY;
    int centernowX = 64, centernowY = 64;

    public static int[,] MapMatrix = new int[128, 128];
    string botstr = "Ground";
    string topstr = "Top";
    int mapcenterX = 64;
    int mapcenterY = 64;

    private void Start() {



        for (int i = -3; i < 4; i++)
            for (int j = -3; j < 4; j++) {
                if (i == 0 && j == 0) continue;
                MapMatrix[mapcenterX - i, mapcenterY - j] = Random.Range(1, 9);

                GameObject botprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (botstr + MapMatrix[mapcenterX - i, mapcenterY - j].ToString()) + ".prefab");
                GameObject topprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (topstr + MapMatrix[mapcenterX - i, mapcenterY - j].ToString()) + ".prefab");

                Instantiate(botprefab, new Vector3((mapcenterX - i) * 32, (mapcenterY - j) * 32, 0), Quaternion.identity, transform);
                Instantiate(topprefab, new Vector3((mapcenterX - i) * 32, (mapcenterY - j) * 32, 0), Quaternion.identity, transform);
            }
    }

    private void FixedUpdate() {
        playerX = playertransf.position.x;
        playerY = playertransf.position.y;

        Debug.Log(playerX + " " + playerY);
        if (playerX > (mapcenterX * 32 + 20)) {
            for (int j = -3; j < 4; j++) {
                if (MapMatrix[mapcenterX + 4, mapcenterY + j] == 0) { MapMatrix[mapcenterX + 4, mapcenterY + j] = Random.Range(1, 9); }
                GameObject botprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (botstr + MapMatrix[mapcenterX + 4, mapcenterY + j].ToString()) + ".prefab");
                GameObject topprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (topstr + MapMatrix[mapcenterX + 4, mapcenterY + j].ToString()) + ".prefab");

                Instantiate(botprefab, new Vector3((mapcenterX + 4) * 32, (mapcenterY + j) * 32, 0), Quaternion.identity, transform);
                Instantiate(topprefab, new Vector3((mapcenterX + 4) * 32, (mapcenterY + j) * 32, 0), Quaternion.identity, transform);
            }
            mapcenterX += 1;
        } else if (playerX < (mapcenterX * 32 - 20)) {
            for (int j = -3; j < 4; j++) {
                if (MapMatrix[mapcenterX - 4, mapcenterY + j] == 0) { MapMatrix[mapcenterX - 4, mapcenterY + j] = Random.Range(1, 9); }
                GameObject botprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (botstr + MapMatrix[mapcenterX - 4, mapcenterY + j].ToString()) + ".prefab");
                GameObject topprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (topstr + MapMatrix[mapcenterX - 4, mapcenterY + j].ToString()) + ".prefab");

                Instantiate(botprefab, new Vector3((mapcenterX - 4) * 32, (mapcenterY + j) * 32, 0), Quaternion.identity, transform);
                Instantiate(topprefab, new Vector3((mapcenterX - 4) * 32, (mapcenterY + j) * 32, 0), Quaternion.identity, transform);
            }
            mapcenterX -= 1;
        } else if (playerY > (mapcenterY * 32 + 20)) {
            for (int i = -3; i < 4; i++) {
                if (MapMatrix[mapcenterX + i, mapcenterY + 4] == 0) { MapMatrix[mapcenterX + i, mapcenterY + 4] = Random.Range(1, 9); }
                GameObject botprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (botstr + MapMatrix[mapcenterX + i, mapcenterY + 4].ToString()) + ".prefab");
                GameObject topprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (topstr + MapMatrix[mapcenterX + i, mapcenterY + 4].ToString()) + ".prefab");

                Instantiate(botprefab, new Vector3((mapcenterX + i) * 32, (mapcenterY + 4) * 32, 0), Quaternion.identity, transform);
                Instantiate(topprefab, new Vector3((mapcenterX + i) * 32, (mapcenterY + 4) * 32, 0), Quaternion.identity, transform);
            }
            mapcenterY += 1;
        } else if (playerY < (mapcenterY * 32 - 20)) {
            for (int i = -3; i < 4; i++) {
                if (MapMatrix[mapcenterX + i, mapcenterY - 4] == 0) { MapMatrix[mapcenterX + i, mapcenterY - 4] = Random.Range(1, 9); }
                GameObject botprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (botstr + MapMatrix[mapcenterX + i, mapcenterY - 4].ToString()) + ".prefab");
                GameObject topprefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Chunks/" + (topstr + MapMatrix[mapcenterX + i, mapcenterY - 4].ToString()) + ".prefab");

                Instantiate(botprefab, new Vector3((mapcenterX + i) * 32, (mapcenterY - 4) * 32, 0), Quaternion.identity, transform);
                Instantiate(topprefab, new Vector3((mapcenterX + i) * 32, (mapcenterY - 4) * 32, 0), Quaternion.identity, transform);
            }
            mapcenterY -= 1;
        }
    }
}
