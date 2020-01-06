using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WourkoutAPI.Settings
{
	public class JwtSettings
	{
		public string SecretKey { get; set; }
		public bool RequireHttpsMetadata { get; set; }
		public bool IncludeErrorDetails { get; set; }
		public bool ValidateAudience { get; set; }
		public bool ValidateIssuerSigningKey { get; set; }
		public bool ValidateIssuer { get; set; }
		public bool ValidateLifetime { get; set; }
		public string AuthorityURL { get; set; }
		public double ExpireTime { get; set; }
	}
}
