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

    // 魔鉱石をセット
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

    // クリック時の処理
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
    
    // 魔鉱石のスプライトを変更
    void ManaStoneSprite()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = manaStone.manaStoneSpriteList;
    }

    // クリック時のアニメーション
    IEnumerator ClickAnim()
    {
        float time = 0;//アニメーションの時間を記録.
        float scale = 0.7f;//クッキーサイズ.
        while (time < clickrate / 2)
        {//アニメーションの半分の時間を拡大に使う.
            time += Time.fixedDeltaTime;//時間をフレームの増分足す.
            scale = 0.7f + time / clickrate / 8;
            gameObject.transform.localScale = new Vector2(scale, scale);//クッキーのサイズを変える.
            yield return new WaitForSeconds(Time.deltaTime);//フレームの終わりまで待つ.
        }
        //上の逆バージョン（今度は縮小処理）.
        while (time < clickrate / 2)
        {
            time += Time.fixedDeltaTime;
            scale -= time / clickrate / 8;
            gameObject.transform.localScale = new Vector2(scale, scale);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        gameObject.transform.localScale = new Vector2(0.7f, 0.7f);//スケールに誤差があるかもしれないので、ここで(1,1)に戻す.
    }
}
