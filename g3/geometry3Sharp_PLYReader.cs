using System.Collections.Generic;
using System.IO;

namespace g3;

internal class PLYReader : IMeshReader
{
	public struct element
	{
		public string name;

		public List<string> properties;

		public List<string> types;

		public List<bool> list;

		public int size;

		public bool Equals(element other)
		{
			return name == other.name;
		}
	}

	private static char[] TRIM_CHARS = new char[4] { '"', '/', '\\', ' ' };

	private Dictionary<string, int> warningCount = new Dictionary<string, int>();

	private bool hasMesh;

	public event ParsingMessagesHandler warningEvent;

	public IOReadResult Read(TextReader reader, ReadOptions options, IMeshBuilder builder)
	{
		List<element> list = new List<element>();
		if (!reader.ReadLine().Contains("ply"))
		{
			return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - Magic number failure");
		}
		string text = reader.ReadLine();
		if (text == null)
		{
			return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - header is corrupt");
		}
		string[] array;
		while (true)
		{
			if (text.StartsWith("element"))
			{
				array = text.Split(' ');
				if (array.Length != 3)
				{
					return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - header is corrupt");
				}
				element item = new element
				{
					properties = new List<string>(),
					types = new List<string>(),
					list = new List<bool>(),
					name = array[1],
					size = ParseInt(array[2])
				};
				while (true)
				{
					text = reader.ReadLine();
					if (text == null)
					{
						return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - header is corrupt");
					}
					if (!text.StartsWith("property"))
					{
						break;
					}
					array = text.Split(' ');
					switch (array.Length)
					{
					case 3:
						item.properties.Add(array[2].ToLower());
						item.types.Add(array[1].ToLower());
						item.list.Add(item: false);
						break;
					case 5:
						item.properties.Add(array[4].ToLower());
						item.types.Add(array[3].ToLower());
						item.list.Add(item: true);
						break;
					default:
						return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - invalid element line" + text);
					}
				}
				list.Add(item);
				continue;
			}
			if (text.StartsWith("end_header"))
			{
				break;
			}
			if (text.StartsWith("binary"))
			{
				continue;
			}
			if (text.StartsWith("comment crs "))
			{
				text.Remove(12);
				text = reader.ReadLine();
				if (text == null)
				{
					return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - header is corrupt");
				}
			}
			else
			{
				text = reader.ReadLine();
				if (text == null)
				{
					return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - header is corrupt");
				}
			}
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		for (int i = 0; i < list.Count; i++)
		{
			element element2 = list[i];
			if (element2.name == "vertex")
			{
				if (!element2.properties.Contains("x") || !element2.properties.Contains("y") || !element2.properties.Contains("z"))
				{
					return new IOReadResult(IOCode.GarbageDataError, "Verteces do not have XYZ");
				}
				if (element2.properties.Contains("red") && element2.properties.Contains("blue") && element2.properties.Contains("green"))
				{
					flag = true;
				}
				if (element2.properties.Contains("nx") && element2.properties.Contains("ny") && element2.properties.Contains("nz"))
				{
					flag2 = true;
				}
				if (element2.properties.Contains("u") && element2.properties.Contains("v"))
				{
					flag3 = true;
				}
			}
			if (element2.name == "faces" && !element2.properties.Contains("vertex_indices"))
			{
				return new IOReadResult(IOCode.GarbageDataError, "Faces do not have vertex indices");
			}
			if (element2.name == "edges" && (!element2.properties.Contains("vertex1") || !element2.properties.Contains("vertex2")))
			{
				return new IOReadResult(IOCode.GarbageDataError, "Edges do not have vertex indices");
			}
		}
		builder.AppendNewMesh(flag2, flag, flag3, bHaveFaceGroups: false);
		text = reader.ReadLine();
		if (text == null)
		{
			return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - header is corrupt");
		}
		array = text.Split(' ');
		for (int j = 0; j < list.Count; j++)
		{
			element element3 = list[j];
			for (int k = 0; k < element3.size; k++)
			{
				int num = element3.properties.Count;
				if (element3.list[0])
				{
					num += ParseInt(array[0]);
				}
				if (array.Length != num)
				{
					return new IOReadResult(IOCode.GarbageDataError, "Not a valid PLY file - contains invalid line : " + text);
				}
				if (element3.name == "vertex")
				{
					Vector3d vtx = default(Vector3d);
					Vector3f norm = default(Vector3f);
					Vector3f cols = default(Vector3f);
					Vector2f uvs = default(Vector2f);
					vtx.x = ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "x")]);
					vtx.y = ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "y")]);
					vtx.z = ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "z")]);
					if (flag2)
					{
						norm.x = (float)ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "nx")]);
						norm.y = (float)ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "ny")]);
						norm.z = (float)ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "nz")]);
					}
					if (flag)
					{
						cols.x = (float)ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "red")]);
						cols.y = (float)ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "blue")]);
						cols.z = (float)ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "green")]);
					}
					if (flag3)
					{
						uvs.x = (float)ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "u")]);
						uvs.y = (float)ParseValue(array[element3.properties.FindIndex((string text2) => text2 == "v")]);
					}
					append_vertex(builder, vtx, norm, cols, uvs, flag2, flag, flag3);
				}
				else if (element3.name == "face")
				{
					if (ParseInt(array[0]) != 3)
					{
						emit_warning("[PLYReader] cann only read triangles");
						return new IOReadResult(IOCode.FormatNotSupportedError, "Can only read tri faces");
					}
					append_triangle(builder, new Index3i
					{
						a = ParseInt(array[1]),
						b = ParseInt(array[2]),
						c = ParseInt(array[3])
					});
				}
				text = reader.ReadLine();
				if (text == null && j != list.Count - 1 && k != element3.size - 1)
				{
					return new IOReadResult(IOCode.GarbageDataError, " does not contain enough definitions of type " + element3.name);
				}
				array = text?.Split(' ');
			}
		}
		return new IOReadResult(IOCode.Ok, "");
	}

	private int append_vertex(IMeshBuilder builder, Vector3d vtx, Vector3f norm, Vector3f cols, Vector2f uvs, bool bHaveNormals, bool bHaveColors, bool bHaveUVs)
	{
		if (!bHaveNormals && !bHaveColors && !bHaveUVs)
		{
			return builder.AppendVertex(vtx.x, vtx.y, vtx.z);
		}
		NewVertexInfo info = default(NewVertexInfo);
		info.bHaveC = (info.bHaveN = (info.bHaveUV = false));
		info.v = vtx;
		if (bHaveNormals)
		{
			info.bHaveN = true;
			info.n = norm;
		}
		if (bHaveColors)
		{
			info.bHaveC = true;
			info.c = cols;
		}
		if (bHaveUVs)
		{
			info.bHaveUV = true;
			info.uv = uvs;
		}
		return builder.AppendVertex(info);
	}

	private int append_triangle(IMeshBuilder builder, Index3i tri)
	{
		if (tri.a < 0 || tri.b < 0 || tri.c < 0)
		{
			emit_warning($"[PLYReader] invalid triangle:  {tri.a} {tri.b} {tri.c}");
			return -1;
		}
		return builder.AppendTriangle(tri.a, tri.b, tri.c);
	}

	public IOReadResult Read(BinaryReader reader, ReadOptions options, IMeshBuilder builder)
	{
		return new IOReadResult(IOCode.FormatNotSupportedError, "text read not supported for 3DS format");
	}

	private void emit_warning(string sMessage)
	{
		string key = sMessage.Substring(0, 15);
		int num = (warningCount.ContainsKey(key) ? warningCount[key] : 0);
		num++;
		warningCount[key] = num;
		if (num <= 10)
		{
			if (num == 10)
			{
				sMessage += " (additional message surpressed)";
			}
			this.warningEvent?.Invoke(sMessage, null);
		}
	}

	private double ParseValue(string value)
	{
		value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
		if (double.TryParse(value, out var result))
		{
			return result;
		}
		return 0.0;
	}

	private int ParseInt(string value)
	{
		value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
		if (int.TryParse(value, out var result))
		{
			return result;
		}
		return 0;
	}
}
