// public class RandomTilemapFiller : MonoBehaviour
// {
//     public Tilemap tilemap;
//     public TileBase[] tilesetTiles;
//     public int width = 10;
//     public int height = 10;

//     void Start()
//     {
//         if (tilemap == null || tilesetTiles == null || tilesetTiles.Length == 0)
//         {
//             Debug.LogError("Please assign the Tilemap and Tileset Tiles in the inspector.");
//             return;
//         }

//         FillTilemapRandomly();
//     }

//     void FillTilemapRandomly()
//     {
//         for (int x = 0; x < width; x++)
//         {
//             for (int y = 0; y < height; y++)
//             {
//                 Vector3Int tilePosition = new Vector3Int(x, y, 0);
//                 TileBase randomTile = tilesetTiles[Random.Range(0, tilesetTiles.Length)];
//                 tilemap.SetTile(tilePosition, randomTile);
//             }
//         }
//     }
// }