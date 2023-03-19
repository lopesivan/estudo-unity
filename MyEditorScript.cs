using UnityEditor;

public class MyEditorScript
{
    static void Build()
    {
        // Define o caminho de saída para o arquivo APK do projeto
        string[] scenes = { "Assets/MyScene.unity" };
        BuildPipeline.BuildPlayer(scenes, "/Users/usuario/Documents/Builds/MyProject.apk", BuildTarget.Android, BuildOptions.None);
    }
}

// Unity -quit -batchmode -projectPath /Users/usuario/Documents/UnityProjects/MyProject -executeMethod MyEditorScript.Build

