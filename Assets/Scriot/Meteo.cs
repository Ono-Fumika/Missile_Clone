using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    private float speed_;
    private float min_; // ���̍��[
    private float max_; // ���̉E�[
    private Vector3 targetPos_;

    // �Q�[���}�l�[�W���[
    [SerializeField] public GameManeger gameManeger_;
    // �^���[
    [SerializeField] public Tower tower_;
    // ����
    [SerializeField] public MeteoExplosion explosion_;
    // �p�[�e�B�N��
    [SerializeField] ParticleSystem particleSystem_;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // �n�ʂɏՓ˂����ꍇ
        if (collider.gameObject.tag == "Ground")
        {
            // �n�ʂɃ_���[�W
            gameManeger_.Damage();
            // 覐΂��폜
            Destoroy();
        }
        // �����ɏՓ˂����ꍇ
        if (collider.gameObject.tag == "Explosion")
        {
            // �X�R�A�����Z
            gameManeger_.AddScore();
            // �����𐶐�
            Instantiate(explosion_, transform.position, Quaternion.identity);
            // 覐΂��폜
            Destoroy();
        }
        // �^���[�ɏՓ˂����ꍇ
        if (collider.gameObject.tag == "Tower")
        {
            // 覐΂��폜
            Destoroy();
        }
    }

    public void SetUp(float min, float max, float speed,GameManeger gameManeger)
    {
        min_ = min;
        max_ = max;
        gameManeger_ = gameManeger;
        speed_ = speed;
    }
    void Start()
    {
        // �ړI�n�������_���Ō��߂�
        targetPos_ = new Vector3(Random.Range(min_, max_), -5.0f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        // ���݂̈ʒu����ړI�n�ւ̕������v�Z
        Vector3 direction = (targetPos_ - transform.position).normalized;
        // �ړ�
        transform.position += (direction * speed_ * Time.deltaTime);
    }
    void Destoroy()
    {
        // �Q�b��ɏ���
        Destroy(gameObject, 2f);
        // �p�[�e�B�N���̐������~�߂�
        particleSystem_.Stop();
        // ���e�I�̕`�����߂�
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        // ���e�I�̓����蔻�������
        gameObject.GetComponent<Collider2D>().enabled = false; ;
    }

}
