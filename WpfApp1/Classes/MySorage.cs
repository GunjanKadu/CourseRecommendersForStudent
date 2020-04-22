using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp1
{
    internal class MyStorage
    {
        internal static void WriteXml<T>(T data, string file)
        {
			
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				FileStream stream;
				stream = new FileStream(file, FileMode.Create);

				serializer.Serialize(stream, data);
				stream.Close();
			}
			catch (Exception x)
			{
				MessageBox.Show(x.ToString(), "Error");
				
			}
        }

		internal static T ReadXML<T>(string file)
		{
			try
			{
				using(StreamReader sr = new StreamReader(file))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					return (T)serializer.Deserialize(sr);
				}
			}
			catch (Exception x)
			{
				MessageBox.Show(x.ToString(), "Error");
				return default(T);
			}
		}
	}
}