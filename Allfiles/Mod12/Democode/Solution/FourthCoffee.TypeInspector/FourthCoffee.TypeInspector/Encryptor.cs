
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace FourthCoffee.TypeInspector
{
	public class Encryptor : IDisposable
	{
		private byte[] _salt;
		private AesManaged _algorithm;

		public Encryptor(string salt)
		{
			if (string.IsNullOrEmpty(salt))
			{
				throw new NullReferenceException();
			}
			this._salt = Encoding.Unicode.GetBytes(salt);
			this._algorithm = new AesManaged();
		}
		
		public byte[] Encrypt(byte[] bytesToEncypt, string password)
		{
			Rfc2898DeriveBytes passwordHash = this.GeneratePasswordHash(password);
			byte[] rgbKey = this.GenerateKey(passwordHash);
			byte[] rgbIV = this.GenerateIV(passwordHash);
			ICryptoTransform transformer = this._algorithm.CreateEncryptor(rgbKey, rgbIV);
			return this.TransformBytes(transformer, bytesToEncypt);
		}
	
		public byte[] Decrypt(byte[] bytesToDecypt, string password)
		{
			Rfc2898DeriveBytes passwordHash = this.GeneratePasswordHash(password);
			byte[] rgbKey = this.GenerateKey(passwordHash);
			byte[] rgbIV = this.GenerateIV(passwordHash);
			ICryptoTransform transformer = this._algorithm.CreateDecryptor(rgbKey, rgbIV);
			return this.TransformBytes(transformer, bytesToDecypt);
		}
		private Rfc2898DeriveBytes GeneratePasswordHash(string password)
		{
			return new Rfc2898DeriveBytes(password, this._salt);
		}
		private byte[] GenerateKey(Rfc2898DeriveBytes passwordHash)
		{
			return passwordHash.GetBytes(this._algorithm.KeySize / 8);
		}
		private byte[] GenerateIV(Rfc2898DeriveBytes passwordHash)
		{
			return passwordHash.GetBytes(this._algorithm.BlockSize / 8);
		}
		private byte[] TransformBytes(ICryptoTransform transformer, byte[] bytesToTransform)
		{
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transformer, CryptoStreamMode.Write);
			cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			cryptoStream.Close();
			memoryStream.Close();
			return result;
		}
		protected virtual void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				if (this._algorithm != null)
				{
					this._algorithm.Dispose();
				}
			}
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
