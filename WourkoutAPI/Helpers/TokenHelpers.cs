using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Helpers
{
	public static class TokenHelpers
	{
		public static string GetValueFromHeader(IHeaderDictionary headers, string header)
		{
			
			bool v = headers.TryGetValue(header, out var token);
			if (!v)
			{
				return null;
			}
			return token.ToString();
		}
	}
}
