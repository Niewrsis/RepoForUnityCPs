using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorSystem
{
    [CustomEditor(typeof(AudioDataSO))]
    public class AudioDataCustomEditor : Editor
    {
        private SerializedProperty _idProperty;
        private SerializedProperty _descriptionProperty;
        private SerializedProperty _audioTypeProperty;

        private SerializedProperty _audioDataNeturalProperty;
        private SerializedProperty _audioDataFriendlyProperty;
        private SerializedProperty _audioDataDangerousProperty;

        private AudioDataSO audioData;

        private bool _isDescriptionActive;
        private bool _isListActive;
        private void Awake()
        {
            audioData = (AudioDataSO)target;

            _idProperty = serializedObject.FindProperty("id");
            _audioTypeProperty = serializedObject.FindProperty("audioType");
            _descriptionProperty = serializedObject.FindProperty("description");

            _audioDataDangerousProperty = serializedObject.FindProperty("audioDangerousData");
            _audioDataFriendlyProperty = serializedObject.FindProperty("audioFriendlyData");
            _audioDataNeturalProperty = serializedObject.FindProperty("audioNeutralData");
        }
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(_idProperty);
            EditorGUILayout.PropertyField(_audioTypeProperty);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("List"))
            {
                _isDescriptionActive = false;
                _isListActive = true;
            }
            if (GUILayout.Button("Description"))
            {
                _isListActive = false;
                _isDescriptionActive = true;
            }
            if(GUILayout.Button("Hide"))
            {
                _isListActive = false;
                _isDescriptionActive = false;
            }
            EditorGUILayout.EndHorizontal();
            
            DrawProperties();

            serializedObject.ApplyModifiedProperties();
        }
        private void DrawProperties()
        {
            if(_isListActive)
            {
                if (audioData.AudioType == Data.AudioType.Dangerous)
                {
                    EditorGUILayout.PropertyField(_audioDataDangerousProperty);
                }
                else if (audioData.AudioType == Data.AudioType.Neutral)
                {
                    EditorGUILayout.PropertyField(_audioDataNeturalProperty);
                }
                else if (audioData.AudioType == Data.AudioType.Friendly)
                {
                    EditorGUILayout.PropertyField (_audioDataFriendlyProperty);
                }
            }

            if (_isDescriptionActive)
            {
                EditorGUILayout.PropertyField(_descriptionProperty);
            }
        }
    }
}