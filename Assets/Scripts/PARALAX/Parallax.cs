using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private ParallaxSprite[] _parallaxSprites;
    void Update()
    {
        for (int i = 0; i < _parallaxSprites.Length; i++)
        {
            _parallaxSprites[i].TargetSprite.transform.position =
            _playerCamera.transform.position / _parallaxSprites[i].SpeedDiv;

            _parallaxSprites[i].TargetSprite.sortingOrder = i;
        }
    }
    [System.Serializable]
    public class ParallaxSprite
    {
        [SerializeField] private float _SpeedDiv = 2f;
        [SerializeField] private SpriteRenderer _targetSprite;

        public float SpeedDiv => _SpeedDiv;
        public SpriteRenderer TargetSprite => _targetSprite;

    }
}
