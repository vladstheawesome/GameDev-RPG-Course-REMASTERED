﻿using RPG.Core;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Saving
{
    [ExecuteAlways]
    public class SaveableEntity : VuforiaMonoBehaviour
    {
        [SerializeField] string uniqueIdentifier = "";
        static Dictionary<string, SaveableEntity> globalLookUp = new Dictionary<string, SaveableEntity>();

        public string GetUniqueIdentifier()
        {
            return uniqueIdentifier;
        }

        public object CaptureState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            foreach(ISaveable saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }
            return state;            
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
            foreach (ISaveable saveable in GetComponents<ISaveable>())
            {
                string typeString = saveable.GetType().ToString();
                if(stateDict.ContainsKey(typeString))
                {
                    saveable.RestoreState(stateDict[typeString]);
                }
            }            
        }

        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;
            if (String.IsNullOrEmpty(gameObject.scene.path)) return;

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");

            if (String.IsNullOrEmpty(property.stringValue)  || !IsUnique(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }

            globalLookUp[property.stringValue] = this;
        }

        private bool IsUnique(string candidate)
        {
            if (!globalLookUp.ContainsKey(candidate)) return true;

            if (globalLookUp[candidate] == this) return true;

            if(globalLookUp[candidate] == null)
            {
                globalLookUp.Remove(candidate);
                return true;
            }

            if(globalLookUp[candidate].GetUniqueIdentifier() != candidate)
            {
                globalLookUp.Remove(candidate);
                return true;
            }

            return false;
        }
    }
}
