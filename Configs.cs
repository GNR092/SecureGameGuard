/*
 * Creado por SharpDevelop.
 * Usuario: GNR092
 * Fecha: 06/02/2017
 * Hora: 08:04 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SecureGameGuard
{
    /// <summary>
    /// SecureGameGuard.
    /// 
    /// Copyright (C) GNR092, 2016-2017.
    /// </summary>
	[Serializable]
	public class Configs
	{
		public string List
		{
			get;
			set;
		}

		public void save()
		{
			Stream stream = null;
			try
			{
				stream = File.Open(Directory.GetCurrentDirectory() + "\\Config.bin", FileMode.Create);
				BinaryFormatter formater = new BinaryFormatter();
				formater.Serialize(stream, this);
			}
			catch (Exception)
			{
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}
			}
		}
		public void load()
		{
			Configs Cnf = null;
			Stream stream = null;
			try
			{
				stream = File.Open(Directory.GetCurrentDirectory() + "\\Config.bin", FileMode.Open);
				BinaryFormatter formater = new BinaryFormatter();
				Cnf = (Configs)formater.Deserialize(stream);
				if (Cnf != null)
				{
					List = Cnf.List;
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}
			}
		}
	}
}
