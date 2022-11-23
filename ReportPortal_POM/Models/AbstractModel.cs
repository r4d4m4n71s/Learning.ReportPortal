using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportPortal_POM.Interfaces;
using Test4Net.Logging.Interfaces;
using Test4Net.UI.POM.Page.Interfaces;

namespace ReportPortal_POM.Models
{
    public abstract class AbstractModel : IPomModel
    {
        public IPageFactory PageFactory { get; }
        public IConfiguration Configuration { get; }
        public ILogProvider LogProvider { get; }

        public AbstractModel(IPageFactory pageFactory, IConfiguration configuration, ILogProvider logProvider)
        {
            PageFactory = pageFactory;
            Configuration = configuration;
            LogProvider = logProvider;
        }
    }
}
