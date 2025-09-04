using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPaletteVisual : MonoBehaviour
{
    [SerializeField] public Transform playerPos;
    [SerializeField] public float AngularSpeed, RotationRadius;
    [SerializeField] private float posX, posY, angle = 0;
    public Sprite empty, red, blue, yellow;
    SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        render.sprite = null;
    }

    private void Update()
    {
        posX = playerPos.position.x + Mathf.Cos(angle) * RotationRadius;
        posY = playerPos.position.y + Mathf.Sin(angle) * RotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * AngularSpeed;

        if (angle >= 360)
        {
            angle = 0;
        }
    }

    public void SetManaColor(ManaColor color)
    {
        switch (color)
        {
            case ManaColor.Red:
                render.sprite = red;
                break;
            case ManaColor.Blue:
                render.sprite = blue;
                break;
            case ManaColor.Yellow:
                render.sprite = yellow;
                break;
            default:
                render.sprite = empty;
                break;
        }
    }
    


}
