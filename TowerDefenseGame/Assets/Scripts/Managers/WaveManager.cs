using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
namespace Managers
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager instance;
        [SerializeField]
        private Transform startWaveButtonTransform;
        private Button startWaveButton;
        [SerializeField]
        private Transform waveTextTransform;
        private TextMeshProUGUI waveText;
        [SerializeField]
        private int waveAmount;
        private int waveIndex;
        private float waveMinimumDuration = 10;
        private float waveTimer;
        private bool waveStarted;
        public static event Action<int> waveStartedEvent;
        public static event Action<int> waveEndedEvent;
        public static event Action wavesFinishedEvent;
        void Awake()
        {
            if (instance == null)
                    instance = this;
                else if (instance != this)
                    Destroy(instance);

            startWaveButton = startWaveButtonTransform.GetComponent<Button>();
            startWaveButton.onClick.AddListener(StartWave);

            waveText = waveTextTransform.GetComponent<TextMeshProUGUI>();
        }
        void Start()
        {
            SetWaveText();
        }

        // Update is called once per frame
        void Update()
        {
            if (waveStarted)
            {
                waveTimer += Time.deltaTime;
                if (EnemyManager.instance.GetEnemyNumbers() <= 0 && waveTimer > waveMinimumDuration)
                {
                    if (waveIndex >= waveAmount-1)
                    {
                        wavesFinishedEvent?.Invoke();
                    }
                    else
                    {
                        waveEndedEvent?.Invoke(waveIndex);
                        waveIndex++;
                        SetWaveText();
                        startWaveButtonTransform.gameObject.SetActive(true);
                    }
                    waveTimer = 0;
                    waveStarted = false;
                }
            }
        }
        private void StartWave()
        {
            if (!waveStarted)
            {
                waveStartedEvent?.Invoke(waveIndex);
                waveStarted = true;
                startWaveButtonTransform.gameObject.SetActive(false);
            }
        }
        private void SetWaveText()
        {
            waveText.text = "Wave " + (waveIndex+1);
        }

    }
}
