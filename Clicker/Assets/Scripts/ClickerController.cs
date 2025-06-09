using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClickerController : MonoBehaviour
{
    FacilityShop facilityShop;

    public enum STONE_MANA_TYPE
    {
        FIRE,
        WATER,
        WOOD,
    }

    [SerializeField] STONE_MANA_TYPE stoneManaType;
    [SerializeField] List<Sprite> manaStoneSpriteList;

    public int fireManaCnt { get; private set; } = 0;
    public int waterManaCnt { get; private set; } = 0;
    public int woodManaCnt { get; private set; } = 0;
    public int elementCnt { get; private set; } = 0;

    GameObject targetObj;
    public float clickrate = 0.5f;

    public STONE_MANA_TYPE GetStoneManaType()
    {
        return stoneManaType;
    }

    public void AddClickCnt()
    {
        facilityShop.facilityLv[0]++;
    }

    public void RemoveElementCnt(int cnt)
    {
        elementCnt -= cnt;
    }

    public void AddElementCnt(int cnt)
    {
        elementCnt += cnt;
    }

    private void Start()
    {
        facilityShop = GameObject.Find("UI").GetComponent<FacilityShop>();
    }

    // Update is called once per frame
    void Update()
    {
        ManaStoneSprite();

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                //Debug.Log("レイの衝突を検知");
                targetObj = hit.collider.gameObject;
                //Debug.Log($"{targetObj.name} に衝突");

                if(targetObj == this.gameObject)
                {
                    StartCoroutine(ClickAnim());
                    AddElementCnt(2 + facilityShop.facilityLv[0]);
                    AddManaCnt();
                    //Debug.Log("カウントをプラスしました");
                }
            }
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.UpArrow))
        {
            elementCnt++;
        }
    }

    // 対応する各属性のマナを増加
    void AddManaCnt()
    {
        switch (stoneManaType)
        {
            case STONE_MANA_TYPE.FIRE:
                fireManaCnt += facilityShop.facilityLv[0];
                break;
            case STONE_MANA_TYPE.WATER:
                waterManaCnt += facilityShop.facilityLv[0];
                break;
            case STONE_MANA_TYPE.WOOD:
                woodManaCnt += facilityShop.facilityLv[0];
                break;
        }
    }

    // 魔鉱石のスプライトを変更
    void ManaStoneSprite()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = manaStoneSpriteList[(int)stoneManaType];
    }

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
