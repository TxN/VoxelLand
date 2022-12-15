using System;
using UnityEngine;
using Telepathy;
using ZeroFormatter;
using System.IO;

using Newtonsoft.Json;
using Voxels;
namespace VoxelServer {
	sealed class Program {


		static void Main(string[] args) {
			Console.WriteLine("Standalone VoxelLand server starting");
			RegisterParserTypes();
			LoadBlockDescriptions();
			var gm = GameManager.Instance;

			gm.Start();
			while ( true ) {
				if ( Console.ReadKey().Key == ConsoleKey.Escape ) {
					gm.Stop();
					System.Threading.Thread.Sleep(50);
					break;
				}
			}
		}

		static void LoadBlockDescriptions() {
			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();
			Console.WriteLine("Loading blockInfo.json");
			var blockJson = File.ReadAllText(Directory.GetCurrentDirectory() + "/blockInfo.json");
			var obj = JsonConvert.DeserializeObject<ResourceLibrary>(blockJson);			
			StaticResources.BlocksInfo = new BlockInfoProvider(obj.BlockDescriptions);
			sw.Stop();
			Console.WriteLine($"Loaded {obj?.BlockDescriptions.Count} block descriptions. Took {sw.ElapsedMilliseconds} ms");
		}

		static void RegisterParserTypes() {
			var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector3Formatter<ZeroFormatter.Formatters.DefaultResolver>();
			ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3>.Register(structFormatter);
			ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3>(structFormatter));
			var structFormatter2 = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector2Formatter<ZeroFormatter.Formatters.DefaultResolver>();
			ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2>.Register(structFormatter2);
			ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2>(structFormatter2));
		}
	}
}
