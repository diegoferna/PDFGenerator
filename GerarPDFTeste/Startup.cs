using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerarPDFTeste.Startup))]
namespace GerarPDFTeste
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
