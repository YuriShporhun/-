using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public class CommonAssetsLogic
    {
        List<CommonAssets> commonAssets = new List<CommonAssets>();

        DataGridView commonAssetsGridView;
        CommonAssetsSQLiteDataProvider commonAssetsDataProvider;

        public CommonAssets this[int index]
        {
            get
            {
                return commonAssets[index];
            }
        }

        public List<CommonAssets> GetCommonAssets(string INN)
        {
            return commonAssetsDataProvider.Load(INN);
        }

        public CommonAssetsLogic(DataGridView commonAssetsGridView)
        {
            this.commonAssetsGridView = commonAssetsGridView;
            commonAssetsDataProvider = new CommonAssetsSQLiteDataProvider();
        }

        /// <summary>
        /// Данный метод привязывает данные о основных средствах 
        /// </summary>
        private void Bind()
        {
            var commonAssetsBindingSource = new BindingSource();
            commonAssetsBindingSource.DataSource = commonAssets;
            commonAssetsGridView.DataSource = commonAssetsBindingSource;
        }

        public void Load(string INN)
        {
            if(INN == string.Empty)
            {
                return;
            }
            commonAssets = commonAssetsDataProvider.Load(INN);
            Bind();
        }

        public void Insert(CommonAssets commonAssets, string INN)
        {
            commonAssetsDataProvider.Insert(commonAssets, INN);
            Load(INN);
        }

        public void Delete(int indexInProgramsList, string INN)
        {
            commonAssetsDataProvider.Delete(commonAssets[indexInProgramsList].GetInternalIndex());
            Load(INN);
        }

        public void Update(CommonAssets commonAssets, string INN)
        {
            commonAssetsDataProvider.Update(commonAssets);
            Load(INN);
        }
    }
}
