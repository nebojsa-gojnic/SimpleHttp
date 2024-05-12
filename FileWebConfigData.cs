using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq ;
using Newtonsoft.Json ;
using WebSockets ;
using System.Security.Cryptography.X509Certificates ;
using System.Security.Authentication ;
using System.Reflection ;
namespace SimpleHttp
{
		 
	public class FileWebConfigData:WebServerConfigData
	{
		
		protected string _webroot ;
		public string webroot 
		{
			get => _webroot ;
		}
		public FileWebConfigData ( string webroot , string siteName , int port , string certificatePath , string certificatePassword , SslProtocols protocol )
		{
			JObject obj = new WebServerConfigData () ;
			JArray services = new JArray () ;
			JArray paths = new JArray () ;
			_webroot = webroot ;
			obj.Add ( "port" , _port = port ) ;
			obj.Add ( "sitename" , _sitename = siteName ) ;
			
			if ( !string.IsNullOrWhiteSpace ( _sitename = siteName ) ) Add ( "sitename" , _sitename ) ;
			if ( !string.IsNullOrWhiteSpace ( _sslCertificateSource = certificatePath  ) )
			{
				obj.Add ( "sslCertificate" , _sslCertificateSource ) ;
				obj.Add ( "sslCertificatePassword" , string.IsNullOrWhiteSpace ( certificatePassword ) ? "" : certificatePassword ) ;
				obj.Add ( "sslProtocol" , ( _sslProtocol = protocol ).ToString () ) ;
			}
			obj.Add ( "services" , services ) ;
			obj.Add ( "paths" , paths ) ;
			JObject service = new JObject () ;
			service.Add ( "service" , "fileHttpService" ) ;
			Type FileHttpServiceType = typeof ( FileHttpService ) ;
			service.Add ( "source" , FileHttpServiceType.AssemblyQualifiedName ) ;
			FileHttpService.FileHttpServiceData configData = new FileHttpService.FileHttpServiceData ( webroot ) ;
			service.Add ( "configData" , configData ) ;
			services.Add ( service ) ;

			JObject path = new JObject () ;
			path.Add ( "service" , "fileHttpService" ) ;
			path.Add ( "path" , "/*" ) ;
			paths.Add ( path ) ;
			loadFromJSON ( obj ) ;
		}
	}
}
