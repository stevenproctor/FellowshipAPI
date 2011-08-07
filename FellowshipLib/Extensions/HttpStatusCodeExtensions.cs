using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace FellowshipLib.Extensions
{
	public static class HttpStatusCodeExtensions
	{
		public static bool IsFailureStatus(this HttpStatusCode statusCode)
		{
			return statusCode == 0 ||
				statusCode == HttpStatusCode.Unauthorized ||
				statusCode == HttpStatusCode.Forbidden ||
				statusCode == HttpStatusCode.NotFound ||
				statusCode == HttpStatusCode.MethodNotAllowed ||
				statusCode == HttpStatusCode.NotAcceptable ||
				statusCode == HttpStatusCode.Conflict ||
				statusCode == HttpStatusCode.Gone ||
				statusCode == HttpStatusCode.UnsupportedMediaType ||
				statusCode == HttpStatusCode.InternalServerError ||
				statusCode == HttpStatusCode.BadRequest ||
				statusCode == HttpStatusCode.BadGateway;
		}
	}
}
