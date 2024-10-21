using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    // ���e�I
    List<GameObject> meteoSponerList = new List<GameObject>();//List���`
    [SerializeField] public GameObject sponerRigth; // ���X�g�̗v�f
    [SerializeField] public GameObject sponerLeft;
    [SerializeField] public GameObject sponerCenter;
    [SerializeField] public Meteo meteo_;
    private float instantiateTimer = 0;
    private float instantiateSpeed = 1.0f;
    private float meteoSpeed_ = 2.0f;

    // �^���[
    List<Tower> tawerList = new List<Tower>(); //List���`
    List<Tower> toRemove = new List<Tower>(); // �ꎞ���X�g�i�폜�p�j
    [SerializeField] public Tower tawerCenter;
    [SerializeField] public Tower tawerLeft;
    [SerializeField] public Tower tawerRigth;
    // �O���E���h
    [SerializeField] SpriteRenderer groundRenderer_; // ���̃����_���[�擾
    private float widthMin_; // ���̍��[
    private float widthMax_; // ���̉E�[
    // ���e�B�N��
    [SerializeField] public Reticle reticle_;
    private Vector3 moucePosition; // �}�E�X�|�W�V����(���[���h)
    // �V�F�C�N
    [SerializeField] public Shake shake_;
    // ���C�t�o�[
    [SerializeField] public LifeSlider life_;
    // �X�R�A
    [SerializeField] public Score score_;
    // �Q�[���I�[�o�[
    [SerializeField] public GameOver gameOver_;

    void Start()
    {
        // �X�|�i�[���X�g�ɗv�f������
        meteoSponerList.Add(sponerRigth);
        meteoSponerList.Add(sponerLeft);
        meteoSponerList.Add(sponerCenter);
        // �^���[���X�g�ɗv�f������
        tawerList.Add(tawerRigth);
        tawerList.Add(tawerLeft);
        tawerList.Add(tawerCenter);
        // Ground�̗��[���擾
        widthMin_ = groundRenderer_.bounds.min.x;
        widthMax_ = groundRenderer_.bounds.max.x;
    }   

    // Update is called once per frame
    void Update()
    {
       
        // �~�T�C�������ˏo���邩�m�F
        TawerStart();
        // �^���[�����鏈��
        TawerDie();
        // ho��0��������Q�[���I�[�o�[���Ă�
        if(life_.currentHp <= 0)
        {
            gameOver_.gameOver(score_.scoreCount);
        }
        else
        {
            // ���e�I�̐���
            MeteoStart();
        }
    }

    public void MeteoStart()
    {
        instantiateTimer += instantiateSpeed * Time.deltaTime;

        // �^�C�}�[���K��l�ȏ�Ȃ烁�e�I�𐶐�
        if(instantiateTimer >= 1.0f)
        {
            // �X�|�i�[�������_���őI��
            int randomIndex = Random.Range(0, meteoSponerList.Count);
            GameObject selectedMeteo = meteoSponerList[randomIndex];
            // ���e�I�𐶐�
            Meteo Meteo = Instantiate(meteo_, selectedMeteo.transform);
            Meteo.SetUp(widthMin_, widthMax_, meteoSpeed_, this);
            // �^�C�}�[���Z�b�g
            instantiateTimer = 0;
        }
       
    }
    void TawerStart()
    {
        // ���{�^���N���b�N
        if (Input.GetMouseButtonUp(0))
        {
            // �}�E�X�̃N���b�N���W���擾
            moucePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            // �^���[�ɔ��ˎw�߂��o��
            foreach (Tower tawer in tawerList)
            {
                // ���Ă�z����1�Ăяo��
                if (tawer.isShot_)
                {
                    // �N���b�N�n�_�Ƀ��e�B�N������
                    Reticle reticle = Instantiate(reticle_, moucePosition, Quaternion.identity);
                    // Shot();�Ăяo��
                    tawer.Shot(reticle.transform.position);
                    tawer.isShot_ = false;
                    // 1�������烋�[�v�𔲂���
                    break;
                }

            }
        }
    }
    void TawerDie()
    {
        // �^���[�������Ă��邩�m�F
        foreach (Tower tawer in tawerList)
        {
            if (tawer.isDie_)
            {
                // �V�F�C�N����
                shake_.StartShake(2.0f, 1.0f);
                // �ꎞ���X�g�ɒǉ�
                toRemove.Add(tawer);
            }
        }
        // �ꎞ���X�g����^���[���폜
        foreach (Tower tawer in toRemove)
        {
            tawerList.Remove(tawer);
        }
        // �^���[���S���Ȃ��Ȃ�����
        if (tawerList.Count == 0)
        {
            // ���e�I�����𑬂�����
            instantiateSpeed = 2.0f;
            meteoSpeed_ = 4.0f;
        }
    }
    public void Damage()
    {
        // ���C�t�����炷
        life_.CurrentHp();
        // �V�F�C�N����
        shake_.StartShake(0.5f, 0.5f);
    }
    public void AddScore()
    {
        // �X�R�A���Z
        score_.AddScore();
    }
}
