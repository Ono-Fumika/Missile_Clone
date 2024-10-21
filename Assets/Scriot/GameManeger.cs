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
    private float instantiateTimer = 0;
    private float instantiateSpeed = 1.0f;
    private float meteoSpeed_ = 2.0f;

    // タワー
    List<Tower> tawerList = new List<Tower>(); //Listを定義
    List<Tower> toRemove = new List<Tower>(); // 一時リスト（削除用）
    [SerializeField] public Tower tawerCenter;
    [SerializeField] public Tower tawerLeft;
    [SerializeField] public Tower tawerRigth;
    // グラウンド
    [SerializeField] SpriteRenderer groundRenderer_; // 床のレンダラー取得
    private float widthMin_; // 床の左端
    private float widthMax_; // 床の右端
    // レティクル
    [SerializeField] public Reticle reticle_;
    private Vector3 moucePosition; // マウスポジション(ワールド)
    // シェイク
    [SerializeField] public Shake shake_;
    // ライフバー
    [SerializeField] public LifeSlider life_;
    // スコア
    [SerializeField] public Score score_;
    // ゲームオーバー
    [SerializeField] public GameOver gameOver_;

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
        widthMin_ = groundRenderer_.bounds.min.x;
        widthMax_ = groundRenderer_.bounds.max.x;
    }   

    // Update is called once per frame
    void Update()
    {
       
        // ミサイルが発射出来るか確認
        TawerStart();
        // タワーが壊れる処理
        TawerDie();
        // hoが0だったらゲームオーバーを呼ぶ
        if(life_.currentHp <= 0)
        {
            gameOver_.gameOver(score_.scoreCount);
        }
        else
        {
            // メテオの生成
            MeteoStart();
        }
    }

    public void MeteoStart()
    {
        instantiateTimer += instantiateSpeed * Time.deltaTime;

        // タイマーが規定値以上ならメテオを生成
        if(instantiateTimer >= 1.0f)
        {
            // スポナーをランダムで選択
            int randomIndex = Random.Range(0, meteoSponerList.Count);
            GameObject selectedMeteo = meteoSponerList[randomIndex];
            // メテオを生成
            Meteo Meteo = Instantiate(meteo_, selectedMeteo.transform);
            Meteo.SetUp(widthMin_, widthMax_, meteoSpeed_, this);
            // タイマーリセット
            instantiateTimer = 0;
        }
       
    }
    void TawerStart()
    {
        // 左ボタンクリック
        if (Input.GetMouseButtonUp(0))
        {
            // マウスのクリック座標を取得
            moucePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            // タワーに発射指令を出す
            foreach (Tower tawer in tawerList)
            {
                // 撃てる奴から1つ呼び出す
                if (tawer.isShot_)
                {
                    // クリック地点にレティクル生成
                    Reticle reticle = Instantiate(reticle_, moucePosition, Quaternion.identity);
                    // Shot();呼び出し
                    tawer.Shot(reticle.transform.position);
                    tawer.isShot_ = false;
                    // 1つ見つけたらループを抜ける
                    break;
                }

            }
        }
    }
    void TawerDie()
    {
        // タワーが生きているか確認
        foreach (Tower tawer in tawerList)
        {
            if (tawer.isDie_)
            {
                // シェイクする
                shake_.StartShake(2.0f, 1.0f);
                // 一時リストに追加
                toRemove.Add(tawer);
            }
        }
        // 一時リストからタワーを削除
        foreach (Tower tawer in toRemove)
        {
            tawerList.Remove(tawer);
        }
        // タワーが全部なくなったら
        if (tawerList.Count == 0)
        {
            // メテオ生成を速くする
            instantiateSpeed = 2.0f;
            meteoSpeed_ = 4.0f;
        }
    }
    public void Damage()
    {
        // ライフを減らす
        life_.CurrentHp();
        // シェイクする
        shake_.StartShake(0.5f, 0.5f);
    }
    public void AddScore()
    {
        // スコア加算
        score_.AddScore();
    }
}
