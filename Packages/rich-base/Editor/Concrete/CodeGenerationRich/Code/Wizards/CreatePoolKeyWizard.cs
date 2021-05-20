using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Rich.Base.Editor.Concrete.CodeGenerationRich.Test;
using UnityEditor;

namespace Rich.Base.Editor.Concrete.CodeGenerationRich.Code.Wizards
{
    public class CreatePoolKeyWizard : ScriptableWizard
    {
        [MenuItem("Tools/Rich/PoolKey")]
        [UsedImplicitly]
        private static void CreateWizard()
        {
            DisplayWizard("Add Property Panel", typeof(CreatePoolKeyWizard), "Add");
        }

        private static CodeGenerationSettings _settings;
        private CodeGenerationOperationConfig _operationConfig;
        
        public string Name;
        
        [UsedImplicitly]
        private void OnWizardCreate()
        {
            if (string.IsNullOrEmpty(Name))
                return;

            _settings = AssetDatabase.LoadAssetAtPath<CodeGenerationSettings>(CodeGenPaths.SETTINGS_PATH);
            _operationConfig = _settings.PoolKeyGenerationConfig;

            Dictionary<Type, object> startArgs = new Dictionary<Type, object>()
            {
                {
                    typeof(PoolKeyCodeOperation),
                    new PoolKeyCodeOperation.StartArgs()
                    {
                        Name = this.Name
                    }
                }
            };
            
            foreach (CodeGenerationOperation operation in _operationConfig.Operations)
                operation.Begin(startArgs);
            
            //Create necessary operate args.
            Dictionary<Type, object> operateArgs = new Dictionary<Type, object>(){ };
            foreach (CodeGenerationOperation operation in _operationConfig.Operations)
                operation.Operate(operateArgs);

            EditorPrefs.SetString("Name", Name);
            AssetDatabase.Refresh();
        }
    }
}