using System;
using System.Collections.Generic;
using _Main.Scripts.PlayerScripts;
using _Main.Scripts.ScriptableObjects.UpgradesSystem;
using TMPro;
using UnityEngine;

namespace _Main.Scripts.UI
{
    public class UpgradeScreenController : MonoBehaviour
    {
        [SerializeField] private UpgradeDataPool pool;
        [SerializeField] private GameObject screenObj;
        [SerializeField] private int upgradesCount;
        [SerializeField] private List<TMP_Text> namesTxt = new List<TMP_Text>();
        [SerializeField] private List<TMP_Text> descriptionTxt = new List<TMP_Text>();

        private List<UpgradeData> m_currUpgradeDatas = new List<UpgradeData>();
        private List<UpgradeData> m_previusUpgradeDatas = new List<UpgradeData>();

        private PlayerModel m_model;

        private void Awake()
        {
            screenObj.SetActive(false);
        }

        public void ActivateUpgradeScreen()
        {
            for (int i = 0; i < upgradesCount; i++)
            {
                m_currUpgradeDatas.Add(pool.GetRandomUpgradeFromPool(m_previusUpgradeDatas)); 
                m_previusUpgradeDatas.Add(m_currUpgradeDatas[i]);
                
                namesTxt[i].text = m_currUpgradeDatas[i].Name;
                descriptionTxt[i].text = m_currUpgradeDatas[i].Description;
            }
            
            screenObj.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnPressedButton(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                OnPressedButton(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                OnPressedButton(2);
            }
        }

        public void OnPressedButton(int p_buttonId)
        {
            if (m_model == default)
                return;
            m_currUpgradeDatas[p_buttonId].ApplyEffects(m_model);
            m_previusUpgradeDatas.Clear();
            m_currUpgradeDatas.Clear();
            screenObj.SetActive(false);
        }

        public void SetPlayerModel(PlayerModel p_model) => m_model = p_model;

    }
}