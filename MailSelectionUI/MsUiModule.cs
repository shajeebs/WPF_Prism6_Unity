using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSelectionUI
{
    public class MsUiModule : IModule
    {
        private RegionManager _regionManager;

        public MsUiModule(RegionManager regionManager)
        {
            this._regionManager = regionManager;
        }
        public void Initialize()
        {
            this._regionManager.RegisterViewWithRegion("FolderSelectionRegion", typeof(MailSelectionView));
        }
    }
}
