using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    // メテオ
    List<GameObject> meteoSponerList = new List<GameObject>();//Listを定義
    [SerializeField] public GameObject sponerRigth; // リストの要素
    [SerializeField] public GameObject sponerLeft;
    [SerializeField] public GameObject sponerCenter;
    [SerializeField] public Meteo meteo_;

    // タワー
    List<Tower> tawerList = new List<Tower>(); //Listを定義
    List<Tower> toRemove = new List<Tower>(); // 一時リスト（削除用）
    [SerializeField] public Tower tawerCenter;
    [SerializeField] public Tower tawerLeft;
    [SerializeField] public Tower tawerRigth;

    // グラウンド
    [SerializeField] SpriteRenderer groundRenderer_; // 床のレンダラー取得
    private float min_; // 床の左端
    private float max_; // 床の右端

    // 

    // Start is called before the first frame update
    void Start()
    {
        // スポナーリストに要素を入れる
        meteoSponerList.Add(sponerRigth);
        meteoSponerList.Add(sponerLeft);
        meteoSponerList.Add(sponerCenter);
        // タワーリストに要素を入れる
        tawerList.Add(tawerRigth);
        tawerList.Add(tawerLeft);
        tawerList.Add(tawerCenter);
        // Groundの両端を取得
        min_ = groundRenderer_.bounds.min.x;
        max_ = groundRenderer_.bounds.max.x;
    }

    // Update is called once per frame
    void Update()
    {
        // メテオの生成
        MeteoStart();
    }

    public void MeteoStart()
    {
        // スポナーをランダムで選択
        int randomIndex = Random.Range(0, meteoSponerList.Count);
        GameObject selectedMeteo = meteoSponerList[randomIndex];
        // メテオを生成
        Meteo Meteo = Instantiate(meteo_, selectedMeteo.transform);
        Meteo.SetUp(min_, max_);
    }
    public void Reticle()
    {
        // 左ボタンクリック
        if (Input.GetMouseButtonUp(0))
        {
            // マウスのクリック座標を取得
            Vector3 mousePosition = Input.mousePosition;
            // スクリーン座標をワールド座標に変換
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
            // クリック地点にレティクル生成
            //Instantiate(reticle, worldPosition, Quaternion.identity);

        }
    }
}
