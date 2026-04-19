using UnityEngine;

namespace Signal.Core.Gameplay.Application
{
    internal static class OffscreenSpawnPositionGenerator
    {
        public static Vector2 Generate(Camera camera, float margin)
        {
            var halfHeight = camera.orthographicSize;
            var halfWidth = halfHeight * camera.aspect;

            var center = (Vector2)camera.transform.position;

            var minX = center.x - halfWidth;
            var maxX = center.x + halfWidth;
            var minY = center.y - halfHeight;
            var maxY = center.y + halfHeight;

            var side = Random.Range(0, 4);

            return side switch
            {
                0 => new Vector2(Random.Range(minX, maxX), maxY + margin), // top
                1 => new Vector2(Random.Range(minX, maxX), minY - margin), // bottom
                2 => new Vector2(minX - margin, Random.Range(minY, maxY)), // left
                _ => new Vector2(maxX + margin, Random.Range(minY, maxY)), // right
            };
        }
    }
}
