﻿using System;

using HiddenWallet.BouncyCastle.Crypto;
using HiddenWallet.BouncyCastle.Math;
using HiddenWallet.BouncyCastle.Security;

namespace HiddenWallet.BouncyCastle.Crypto.Parameters
{
	internal class RsaKeyGenerationParameters
		: KeyGenerationParameters
	{
		private readonly BigInteger publicExponent;
		private readonly int certainty;

		public RsaKeyGenerationParameters(
			BigInteger publicExponent,
			SecureRandom random,
			int strength,
			int certainty)
			: base(random, strength)
		{
			this.publicExponent = publicExponent;
			this.certainty = certainty;
		}

		public BigInteger PublicExponent
		{
			get
			{
				return publicExponent;
			}
		}

		public int Certainty
		{
			get
			{
				return certainty;
			}
		}

		public override bool Equals(
			object obj)
		{
			RsaKeyGenerationParameters other = obj as RsaKeyGenerationParameters;

			if(other == null)
			{
				return false;
			}

			return certainty == other.certainty
				&& publicExponent.Equals(other.publicExponent);
		}

		public override int GetHashCode()
		{
			return certainty.GetHashCode() ^ publicExponent.GetHashCode();
		}
	}
}