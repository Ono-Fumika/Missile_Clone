using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private float hp_ = 3.0f; // �̗�
    private float damage_ = 1.0f; // �󂯂�_���[�W��
    public float cooldownTimer_ = 3.0f; // ���ˉ\�ɂȂ�܂ł̎���(3�b)
    public bool isShot_ = true; // ���ˏo���邩�̃t���O
    public bool isDie_ = false; // ���񂾂��̃t���O
    Vector3 worldMoucePosition_; // �}�E�X�|�W�V����(���[���h)

    // �~�T�C��
    [SerializeField] public Missile missile;

    // �����G�t�F�N�g
    [SerializeField] public GameObject explosion_;

    // �J���[�֘A
    private Renderer towerRenderer;
    private Color originalColor;
    private Color cooldownColor = Color.red;

    public void Shot(Vector3 worldMoucePosition)
    {
        worldMoucePosition_ = worldMoucePosition;
        if (isShot_)
        {
            // �^���[���琶��
            Missile missileInstence_ = Instantiate(missile, transform.position, Quaternion.identity);
            missileInstence_.SetUp(worldMoucePosition_);
            // ���������猂�ĂȂ��Ȃ�
            isShot_ = false;
        }
    }

    void Start()
    {
        towerRenderer = GetComponent<Renderer>();
        if (towerRenderer != null)
        {
            originalColor = towerRenderer.material.color;
        }
    }

    void Update()
    {
        // ���ĂȂ���ԂɂȂ�����
        if (!isShot_)
        {
            // �N�[���^�C���̃J�E���g
            cooldownTimer_ -= Time.deltaTime;

            // �N�[���^�C�����ɐF��ω�������
            float lerpFactor = 1.0f - (cooldownTimer_ / 3.0f); // �J�E���g�_�E���̊���
            towerRenderer.material.color = Color.Lerp(cooldownColor, originalColor, lerpFactor);

            // �N�[���^�C����0�ɂȂ����猂�Ă��Ԃɂ���
            if (cooldownTimer_ <= 0)
            {
                isShot_ = true;
                cooldownTimer_ = 3.0f;
                towerRenderer.material.color = originalColor; // �F�����ɖ߂�
            }
        }

        // ������0�ɂȂ�����
        if (hp_ <= 0)
        {
            isDie_ = true;
            // �����𐶐�
            //Instantiate(explosion_, transform.position, Quaternion.identity);
            // ���󂷂�
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        // ���e�I�ƏՓ˂����ꍇ
        if (collider.gameObject.tag == "Meteo")
        {
            // �^���[�Ƀ_���[�W
            hp_ -= damage_;
        }
    }
}
