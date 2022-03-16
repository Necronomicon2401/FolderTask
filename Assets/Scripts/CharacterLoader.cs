using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterLoader : MonoBehaviour
    {
        [SerializeField] private GenderButton baseButton;
        [SerializeField] private GameObject customizationPanel;

        [SerializeField] private StreamingAssetsController controller;

        private CharacterConfig config;

        private GameObject loadedCharacter;
        private bool isCustomizationAviable = false;

        private void Start()
        {
            customizationPanel.SetActive(false);
            config = Resources.Load<CharacterConfig>("CharacterConfig");

            var names = config.Characters;

            foreach (var objName in names)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                btn.Setup(objName, OnEffectButton);
            }

            baseButton.gameObject.SetActive(false);
        }

        private void OnEffectButton(string id)
        {
            if (loadedCharacter != null)
            {
                Destroy(loadedCharacter);
            }

            if (isCustomizationAviable == false)
            {
                isCustomizationAviable = true;
                customizationPanel.SetActive(true);
            }
            
            var asset = config.GetEffect(id);
            var q = Quaternion.identity;
            q.y = -180;

            var v = Vector3.zero;
            v.z = -7;
            loadedCharacter = Instantiate(asset, v, q);
            
            controller.obj = loadedCharacter;
        }
    }
}