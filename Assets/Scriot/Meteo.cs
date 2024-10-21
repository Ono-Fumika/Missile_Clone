using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    public float speed_ = 2.0f;
    private float min_; // ���̍��[
    private float max_; // ���̉E�[
    private Vector3 targetPos_;

    // �Q�[���}�l�[�W���[
    [SerializeField] public GameManeger gameManeger_;
    // �^���[
    [SerializeField] public Tower tower_;
    // ����
    [SerializeField] public MeteoExplosion explosion_;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // �n�ʂɏՓ˂����ꍇ
        if (collider.gameObject.tag == "Ground")
        {
            // �n�ʂɃ_���[�W
            gameManeger_.Damage();
            // 覐΂��폜
            Destroy(gameObject);
        }
        // �����ɏՓ˂����ꍇ
        if (collider.gameObject.tag == "Explosion")
        {
            // �X�R�A�����Z
            gameManeger_.AddScore();
            // �����𐶐�
            Instantiate(explosion_, transform.position, Quaternion.identity);
            // 覐΂��폜
            Destroy(gameObject);
        }
        // �^���[�ɏՓ˂����ꍇ
        if (collider.gameObject.tag == "Tower")
        {
            // 覐΂��폜
            Destroy(gameObject);
        }
    }

    public void SetUp(float min, float max, GameManeger gameManeger)
    {
        min_ = min;
        max_ = max;
        gameManeger_ = gameManeger;
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
}
