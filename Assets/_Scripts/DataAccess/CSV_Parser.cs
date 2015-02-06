using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

/* ==============================================================================
 * 功能描述：CSV（逗号分割文件）解析器
 * 创 建 者：cjunhong
 * 创建日期：2014/12/02 16:22:09
 * 邮    箱：[url=mailto:john.cha@qq.com]john.cha@qq.com[/url]
 * ==============================================================================*/
public class CSV_Parser{
	public delegate T Parser<T>(List<string> lineFields);
	
	/// <summary>
	/// 转换
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="colNames"></param>
	/// <param name="fieldValues"></param>
	/// <param name="type"></param>
	/// <returns></returns>
	public static T ReflectionParser<T>(string[] colNames, string[] fieldValues, Type type){
		//使用指定类型的默认构造函数来创建该类型的实例
		T t = (T)System.Activator.CreateInstance(type);
		for(int i=0; i<colNames.Length; i++){
			//#if UNITY_EDITOR
			try{
				//#endif
				if (colNames[i] == null)
				{
					continue;
				}
				PropertyInfo property = t.GetType().GetProperty(colNames[i]);
				if (string.IsNullOrEmpty(fieldValues[i]))
				{
					Type propertyType = property.PropertyType;
					if (propertyType == typeof(string))
					{
						property.SetValue(t, "", null);
					}
					else if (propertyType == typeof(int) || propertyType == typeof(short) ||
					         propertyType == typeof(byte) || propertyType == typeof(float) ||
					         propertyType == typeof(double))
					{
						property.SetValue(t, 0, null);
					}
					else
					{
						UnityEngine.Debug.Log("Can not found default value for " + propertyType);
					}
				}
				else
				{
					property.SetValue(t, Convert.ChangeType(fieldValues[i], property.PropertyType), null);
				}
				//#if UNITY_EDITOR
			}catch(Exception e){
				Debuger.Log("Error at parse for `" + typeof(T) + "` column index=" + i + ", column name=" + colNames[i] + ", value=" + fieldValues[i] + " value in #0 column=" + fieldValues[0] + ", error=" + e);
			}
			//#endif
		}
		return t;
	}
	
	/// <summary>
	/// Csv内容的分隔符
	/// </summary>
	public const char DEFAULD_FIELD_SEPARATOR = ';';
	//public const char DEFAULD_FIELD_SEPARATOR = ',';
	/// <summary>
	/// Csv内容的边界两端
	/// </summary>
	public const char DEFAULD_FIELD_BOUND = '"';
	
	public static List<T> DoParse<T>(string path, Parser<T> parser){
		return DoParseByReader(File.OpenText(path), parser);
	}
	
	public static List<T> DoParseByFilePath<T>(char fieldSeparator, char fieldBound, string path, Parser<T> parser){
		return DoParseByReader(fieldSeparator, fieldBound, File.OpenText(path), parser);
	}
	
	public static List<T> DoParseByReader<T>(StreamReader reader, Parser<T> parser){
		return DoParseByReader(DEFAULD_FIELD_SEPARATOR, DEFAULD_FIELD_BOUND, reader, parser);
	}
	
	public static List<T> DoParseByReader<T>(Type type, string[] colNames, StreamReader reader){
		return DoParse<T>(type, colNames, DEFAULD_FIELD_SEPARATOR, DEFAULD_FIELD_BOUND, reader);
	}
	
	public static List<T> DoParseByFilePath<T>(Type type, string[] colNames, string path){
		return DoParseByReader<T>(type, colNames, File.OpenText(path));
	}
	
	#region 对文件的内容 进行Csv格式的转换 +static List<T> DoParseByFileContent<T>(Type type, string[] colNames, string fileContent)
	/// <summary>
	/// 对文件的内容 进行Csv格式的转换
	/// </summary>
	/// <typeparam name="T">转换后所得到的类型</typeparam>
	/// <param name="type">要转换的类型</param>
	/// <param name="colNames">要处理的名称</param>
	/// <param name="fileContent">文件的内容</param>
	/// <returns>得到 进行Csv转换后的List</returns>
	public static List<T> DoParseByFileContent<T>(Type type, string[] colNames, string fileContent)
	{
		return DoParseByFileContent<T>(DEFAULD_FIELD_SEPARATOR, DEFAULD_FIELD_BOUND, fileContent, delegate(List<string> lineFields)
		                               {
			return ReflectionParser<T>(colNames, lineFields.ToArray(), type);
		});
	} 
	#endregion
	
	public static List<T> DoParse<T>(Type type, string[] colNames, char fieldSeparator, char fieldBound, StreamReader reader){
		return DoParseByReader(fieldSeparator, fieldBound, reader, delegate(List<string> lineFields){
			return ReflectionParser<T>(colNames, lineFields.ToArray(), type);
		});
	}
	
	#region 对文件的内容的每一行 进行Csv格式的转换 +static List<T> DoParseByFileContent<T>(char fieldSeparator, char fieldBound, string fileContent, Parser<T> parser)
	/// <summary>
	/// 对文件的内容的每一行 进行Csv格式的转换
	/// </summary>
	/// <typeparam name="T">转换后所得到的类型</typeparam>
	/// <param name="fieldSeparator">转换的分隔符</param>
	/// <param name="fieldBound">转换边界符</param>
	/// <param name="fileContent">文件内容</param>
	/// <param name="parser">转换对象</param>
	/// <returns>返回一个格式转换后得到的一个集合</returns>
	public static List<T> DoParseByFileContent<T>(char fieldSeparator, char fieldBound, string fileContent, Parser<T> parser)
	{
		//回车换行分隔
		string[] lines = fileContent.Split(new char[] { '\n' }, StringSplitOptions.None);
		List<T> list = new List<T>();
		//如果存在行 则遍历行 并且添加到行集合中
		if (lines != null)
		{
			foreach (string line in lines)
			{
				if (line != null && !"".Equals(line.Trim()))
				{
					list.Add(processLine(fieldSeparator, fieldBound, line, parser));
				}
			}
		}
		return list;
	} 
	#endregion
	
	public static List<T> DoParseByReader<T>(char fieldSeparator, char fieldBound, StreamReader reader, Parser<T> parser){
		string line = null;
		List<T> list = new List<T>();
		
		while((line=reader.ReadLine())!=null){
			list.Add(processLine(fieldSeparator, fieldBound, line, parser));
		}
		return list;
	}
	
	private static T processLine<T>(char fieldSeparator, char fieldBound, string line, Parser<T> parser){
		int index = 0;
		
		List<string> lineFields = new List<string>();
		int lastQuote = -1;
		char[] cs = line.ToCharArray();
		bool find = false;
		
		for(index=0; index<cs.Length; index++){
			char c = cs[index];
			
			if(c == fieldBound){
				if(lastQuote == -1){
					lastQuote = index;
				} else{
					if(index + 1 < cs.Length && cs[index + 1] == c){
						index++;
					} else{
						find = true;
					}
				}
			} else if(c == fieldSeparator){
				if(lastQuote != -1 && find){
					lineFields.Add(line.Substring(lastQuote + 1, index - lastQuote - 2).Replace("\"\"", "\""));
					find = false;
					lastQuote = -1;
					
				}
			}
		}
		//UnityEngine.Debug.Log("..." + line);
		lineFields.Add(line.Substring(lastQuote + 1, index - lastQuote - 3).Replace("\"\"", "\""));
		return parser(lineFields);
	}
	
}