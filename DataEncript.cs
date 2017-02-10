/*
 * Creado por SharpDevelop.
 * Usuario: GNR092
 * Fecha: 06/02/2017
 * Hora: 08:04 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System.Text;

namespace SecureGameGuard
{
	public class DataEncript
	{
		public static byte[] DataEncrip(int num0)
		{

			byte[] encryted =Encoding.Unicode.GetBytes(num0.ToString());

			return encryted;
		}

		public static int DataDesencrip(byte[] num0)
		{
			string str = string.Empty;
			int num1 = 0;
			try
			{
				str = Encoding.Unicode.GetString(num0);
				int.TryParse(str, out num1);
				return num1;
			}
			catch
			{

				return -1;
			}

		}
	}
}
