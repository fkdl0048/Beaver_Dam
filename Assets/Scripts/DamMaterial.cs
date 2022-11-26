using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DamMaterial : MonoBehaviour
{
    [SerializeField] private SpriteAtlas m_SpriteAtlas;
    [SerializeField] private eCOLOR clr;
    SpriteRenderer spriteRenderer;
    Animation anim;

    string[] typeName = { "branch", "stone", "leaf" };
    string[] colorName = { "_green", "_red", "_yellow", "_gray", "_brown", "_white" };

    public stMaterial material;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animation>();
    }

    public void InitMaterial(stMaterial _mat, int _floor)
    {
        material = _mat;
        spriteRenderer.sprite = m_SpriteAtlas.GetSprite(typeName[material.matType] + colorName[material.matColor]);
        //�ִϸ��̼� ���� ��ġ ����
        anim.Play();
    }

    public void RemoveFromScene()
    {
        transform.position = new Vector2(100, 100);
    }
}