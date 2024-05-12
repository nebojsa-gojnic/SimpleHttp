using System ;
using System.Collections.Generic ;
using System.IO ; 
using System.Reflection ;
using System.Text ;
using System.Text.RegularExpressions ;
using System.Net.Sockets ;
using System.Diagnostics ;
using WebSockets ;

namespace SimpleHttp
{
	/// <summary>
	/// Class for making IHttpService instance(s).
	/// Depending on constructor it may spawn diferent classes:<br/>
	/// resource based server(ResourcesHttpService), file based server(FileHttpService)
	/// or test message response(TestHttpService).
	/// </summary>
    public class SimpleHttpServiceFactory : IHttpServiceFactory
    {
		public WebServer server { get ; }
		/// <summary>
		/// Config data for TestHttpService class
		/// </summary>
		public TestHttpService.TestHttpServiceData testServiceConfig ;
		/// <summary>
		/// Config data for ResourcesHttpService class
		/// </summary>
		public ResourcesHttpService.ResourcesHttpServiceData resourcesServiceConfig ;
		/// <summary>
		/// Config data for FileHttpService class
		/// </summary>
		public FileHttpService.FileHttpServiceData fileServiceConfig ;
		/// <summary>
		/// This delegate is needed for IHttpService creation method 
		/// </summary>
		/// <param name="connectionDetails">HttpConnectionDetails instance with relevant http connection data</param>
		public delegate IHttpService CreateInstanceDelegate ( HttpConnectionDetails connectionDetails ) ;
		/// <summary>
		/// This is "pointer" to IHttpService creation method 
		/// </summary>
		protected CreateInstanceDelegate ceateInstanceMethod ;
		/// <summary>
		/// This dictionary contains lowcase file names for keys and full resource names for values.
		/// <br/>It speeds up search hopefully.
		/// </summary>
		private readonly Dictionary <string, string> resourcePaths ;

        //private string GetWebRoot()
        //{
        //    if (!string.IsNullOrWhiteSpace(_webRoot) && Directory.Exists(_webRoot))
        //    {
        //        return _webRoot;
        //    }

        //    return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(@"file:\", string.Empty);
        //}
		/// <summary>
		/// This is set to true when service factory produces assembly based responses (ResourcesHttpService) 
		/// </summary>
		public bool isResourceBased 
		{
			get => ceateInstanceMethod == createInstanceFromAssembly ; 
		}
		/// <summary>
		/// This is set to true when service factory produces file based responses (FileHttpService) 
		/// </summary>
		public bool isFileBased 
		{
			get => ceateInstanceMethod == createInstanceFromPath ; 
		}
		/// <summary>
		/// Creates SimpleHttpServiceFactory instance that spawns TestHttpService instances with test message response(s).
		/// </summary>
		/// <param name="message">Message to insert in simple html page</param>
		public static SimpleHttpServiceFactory createTestFactory ( string message ) 
		{
			SimpleHttpServiceFactory ret = new SimpleHttpServiceFactory ( (string)null ) ;
			ret.ceateInstanceMethod = ret.createTestInstance ;
			return ret ;
		}
		/// <summary>
		/// Creates SimpleHttpServiceFactory instance that spawns ResourcesHttpService instances
		/// </summary>
		/// <param name="resourceAssembly"></param>
        public SimpleHttpServiceFactory ( Assembly resourceAssembly ) : this ( null , resourceAssembly , "" ) 
        {
			resourcePaths = new Dictionary<string, string> () ;
			int prefixLength = resourceAssembly.GetName().Name.Length + 11 ;	//  11 == ( ".resources." ).Length
			foreach ( string name in resourceAssembly.GetManifestResourceNames () )
				resourcePaths.Add ( name.ToLower().Substring ( 20 ) , name ) ;
			ceateInstanceMethod = createInstanceFromAssembly ;
        }
		/// <summary>
		/// Creates new SimpleHttpServiceFactory instance for file based server.
		/// <br/>When SimpleHttpServiceFactory is created this way it spawns FileHttpService instance(s) to respond to http requeste(s)
		/// </summary>
		/// <param name="webroot">Web root path</param>
		public SimpleHttpServiceFactory ( string webroot ) : this ( webroot , null , "" ) 
        {
			ceateInstanceMethod = createInstanceFromPath ;
        }
		/// <summary>
		/// Protected constructor
		/// </summary>
		/// <param name="webroot">Web root path. Can be null or empty </param>
		/// <param name="resourceAssembly">Assembly will files biund inside its resources</param>
		/// <param name="message">Text message for test service</param>
		protected SimpleHttpServiceFactory ( string webroot , Assembly resourceAssembly , string message )
		{
			testServiceConfig = new TestHttpService.TestHttpServiceData ( message ) ;
			fileServiceConfig = new FileHttpService.FileHttpServiceData ( webroot ) ;
			resourcesServiceConfig = new ResourcesHttpService.ResourcesHttpServiceData ( resourceAssembly ) ;
		}
		/// <summary>
		/// Creates and returns TestHttpService instance
		/// </summary>
		/// <param name="connectionDetails">HttpConnectionDetails instance with relevant http connection data</param>
		/// <returns>Returns new TestHttpService instance</returns>
		public IHttpService createTestInstance ( HttpConnectionDetails connectionDetails )
        {
			TestHttpService service = new TestHttpService () ;
			service.init ( server , connectionDetails , testServiceConfig ) ;
            return service ;
        }
		/// <summary>
		/// Creates and returns ResourcesHttpService instance
		/// </summary>
		/// <param name="connectionDetails">HttpConnectionDetails instance with relevant http connection data</param>
		/// <returns>Returns new ResourcesHttpService instance</returns>
        public IHttpService createInstanceFromAssembly ( HttpConnectionDetails connectionDetails )
        {
			ResourcesHttpService service = new ResourcesHttpService () ;
			service.init ( server , connectionDetails , resourcesServiceConfig ) ;
            return service ;
        }
		/// <summary>
		/// Creates and returns FileHttpService instance
		/// </summary>
		/// <param name="connectionDetails">HttpConnectionDetails instance with relevant http connection data</param>
		/// <returns>Returns new FileHttpService instance</returns>
        public IHttpService createInstanceFromPath ( HttpConnectionDetails connectionDetails )
        {
			FileHttpService service = new FileHttpService ( ) ;
			service.init ( server , connectionDetails , fileServiceConfig ) ;
            return service ;
        }
		/// <summary>
		/// Creates and returns TestHttpService instance
		/// </summary>
		/// <param name="connectionDetails">HttpConnectionDetails instance with relevant http connection data</param>
		/// <returns>Returns new TestHttpService instance</returns>
        public IHttpService createInstance ( HttpConnectionDetails connectionDetails )
        {
            return ceateInstanceMethod ( connectionDetails ) ;
        }
    }
}
