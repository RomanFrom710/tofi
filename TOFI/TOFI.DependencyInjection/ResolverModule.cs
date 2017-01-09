using DAL.Contexts;
using Ninject;
using Ninject.Extensions.Conventions;

namespace TOFI.DependencyInjection
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel);
        }

        public static IKernel GetKernel()
        {
            var kernel = new StandardKernel();
            Configure(kernel);
            return kernel;
        }


        private static void Configure(IKernel kernel)
        {
            //binding for BLL serices
            //add other the same way
            kernel.Bind(
                m => m.From("BLL")
                    .Select(t => t.Namespace.Contains("BLL.Services"))
                    .BindDefaultInterface());
            kernel.Bind(
                m => m.From("DAL")
                    .Select(t => t.Namespace.Contains("DAL.Repositories"))
                    .BindDefaultInterface());
            kernel.Bind<TofiContext>().ToSelf();
        }
    }
}