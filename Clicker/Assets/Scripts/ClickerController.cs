using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class ManaStone
{
    public enum STONE_MANA_TYPE
    {
        FIRE,
        WATER,
        WOOD,
    }

    public STONE_MANA_TYPE stoneManaType;
    public Sprite manaStoneSpriteList;
}

public class ClickerController : MonoBehaviour
{
    ManaStone manaStone;
    [SerializeField] List<ManaStone> manaStones;
    
    GameObject targetObj;
    public float clickrate = 0.5f;

    ResourceManager resourceManager;

    // ���z�΂��Z�b�g
    void SetManaStone(ManaStone stone)
    {
        manaStone = stone;
    }

    private void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
        SetManaStone(manaStones[0]);
    }

    // Update is called once per frame
    void Update()
    {
        ManaStoneSprite();
        Click();        
    }

    // �N���b�N���̏���
    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                targetObj = hit.collider.gameObject;

                if (targetObj == this.gameObject)
                {
                    resourceManager.ClickStone(manaStone);
                    StartCoroutine(ClickAnim());
                }
            }
        }
    }
    
    // ���z�΂̃X�v���C�g��ύX
    void ManaStoneSprite()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = manaStone.manaStoneSpriteList;
    }

    // �N���b�N���̃A�j���[�V����
    IEnumerator ClickAnim()
    {
        float time = 0;//�A�j���[�V�����̎��Ԃ��L�^.
        float scale = 0.7f;//�N�b�L�[�T�C�Y.
        while (time < clickrate / 2)
        {//�A�j���[�V�����̔����̎��Ԃ��g��Ɏg��.
            time += Time.fixedDeltaTime;//���Ԃ��t���[���̑�������.
            scale = 0.7f + time / clickrate / 8;
            gameObject.transform.localScale = new Vector2(scale, scale);//�N�b�L�[�̃T�C�Y��ς���.
            yield return new WaitForSeconds(Time.deltaTime);//�t���[���̏I���܂ő҂�.
        }
        //��̋t�o�[�W�����i���x�͏k�������j.
        while (time < clickrate / 2)
        {
            time += Time.fixedDeltaTime;
            scale -= time / clickrate / 8;
            gameObject.transform.localScale = new Vector2(scale, scale);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        gameObject.transform.localScale = new Vector2(0.7f, 0.7f);//�X�P�[���Ɍ덷�����邩������Ȃ��̂ŁA������(1,1)�ɖ߂�.
    }
}
