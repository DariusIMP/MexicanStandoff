﻿using Logging;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class LogBoard : MonoBehaviour
    {
        public GameObject container;

        public GameObject inputLine;

        private GameObject _lastInputLine;

        private Vector3 _nextRecordPosition;

        void Awake()
        {
            StartNextRecordPosition();
        }

        private void StartNextRecordPosition()
        {
            _nextRecordPosition = new Vector3(0,
                ((RectTransform) container.transform).rect.height / 2 
                - ((RectTransform) inputLine.transform).rect.height / 2, 0); 
        }

        public void AddRecord(ActionEventInfo actionEventInfo)
        {
            _lastInputLine = inputLine;
            RectTransform rt = (RectTransform)_lastInputLine.transform;
            GameObject record = Instantiate(inputLine, container.transform, false) as GameObject;
            var recordLocalPosition = _nextRecordPosition - new Vector3(0, rt.rect.height, 0);
            Debug.Log(_lastInputLine.transform.localPosition);
            Debug.Log(_nextRecordPosition);
            Debug.Log(recordLocalPosition);
            record.transform.localPosition = recordLocalPosition;
            record.transform.GetChild(0).GetComponent<Text>().text = actionEventInfo.originId.ToString();
            record.transform.GetChild(1).GetComponent<Text>().text = actionEventInfo.targetId.ToString();
            record.transform.GetChild(2).GetComponent<Text>().text = actionEventInfo.action.ToString();
            record.transform.GetChild(3).GetComponent<Text>().text = actionEventInfo.value.ToString();
            _nextRecordPosition = recordLocalPosition;
        }

        public void ClearRecords()
        {
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }
            StartNextRecordPosition();
        }
    }
}
