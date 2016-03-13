using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handsey.Ninject
{
    public class NinjectIocContainer : IIocContainer
    {
        private readonly KernelBase _kernel;

        public NinjectIocContainer(KernelBase kernel)
        {
            _kernel = kernel;
        }

        public void Register(Type from, Type to, string name)
        {
            _kernel.Bind(from).To(to).Named(name);
        }

        public TResolve[] ResolveAll<TResolve>()
        {
            return _kernel.GetAll<TResolve>().ToArray();
        }
    }
}