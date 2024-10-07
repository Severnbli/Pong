using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.Utility.Editor
{
	[InitializeOnLoad]
	public static class GameWindowScaler // Tested on 2022.3.36f1
	{
		private static readonly Vector2 DefaultScale = new(DEFAULT_SCALE, DEFAULT_SCALE);

		private static Type _viewType;
		private static Type ViewType => _viewType ??= typeof(EditorWindow).Assembly.GetType("UnityEditor.GameView");
		
		private static FieldInfo _zoomField;
		private static FieldInfo ZoomField => _zoomField ??= ViewType.GetField("m_ZoomArea", BINDING_FLAGS);

		private static FieldInfo _scaleField;
		private static FieldInfo ScaleField => _scaleField ??= ZoomField.FieldType.GetField("m_Scale", BINDING_FLAGS);

		private const float DEFAULT_SCALE = .1f;
		private const BindingFlags BINDING_FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

		static GameWindowScaler()
		{
			ScaleGameWindows();
			EditorApplication.playModeStateChanged += OnPlayStateChanged;
		}

		private static void ScaleGameWindows()
		{
			Object[] gameWindows = Resources.FindObjectsOfTypeAll(ViewType);

			if (gameWindows.Length == 0)
				return;

			foreach (object gameWindow in gameWindows)
			{
				object scaleValue = ZoomField.GetValue(gameWindow);
				ScaleField.SetValue(scaleValue, DefaultScale);
			}
		}
	
		private static void OnPlayStateChanged(PlayModeStateChange _)
		{
			ScaleGameWindows();
		}
	}
}