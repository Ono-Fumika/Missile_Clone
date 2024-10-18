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

    // �^���[
    List<Tower> tawerList = new List<Tower>(); //List���`
    List<Tower> toRemove = new List<Tower>(); // �ꎞ���X�g�i�폜�p�j
    [SerializeField] public Tower tawerCenter;
    [SerializeField] public Tower tawerLeft;
    [SerializeField] public Tower tawerRigth;

    // �O���E���h
    [SerializeField] SpriteRenderer groundRenderer_; // ���̃����_���[�擾
    private float min_; // ���̍��[
    private float max_; // ���̉E�[

    // 

    // Start is called before the first frame update
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
        min_ = groundRenderer_.bounds.min.x;
        max_ = groundRenderer_.bounds.max.x;
    }

    // Update is called once per frame
    void Update()
    {
        // ���e�I�̐���
        MeteoStart();
    }

    public void MeteoStart()
    {
        // �X�|�i�[�������_���őI��
        int randomIndex = Random.Range(0, meteoSponerList.Count);
        GameObject selectedMeteo = meteoSponerList[randomIndex];
        // ���e�I�𐶐�
        Meteo Meteo = Instantiate(meteo_, selectedMeteo.transform);
        Meteo.SetUp(min_, max_);
    }
    public void Reticle()
    {
        // ���{�^���N���b�N
        if (Input.GetMouseButtonUp(0))
        {
            // �}�E�X�̃N���b�N���W���擾
            Vector3 mousePosition = Input.mousePosition;
            // �X�N���[�����W�����[���h���W�ɕϊ�
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
            // �N���b�N�n�_�Ƀ��e�B�N������
            //Instantiate(reticle, worldPosition, Quaternion.identity);

        }
    }
}
