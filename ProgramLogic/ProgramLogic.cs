using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class ProgramLogic
    {
        private ProgramLogic(ProgramLogicView programLogicView) 
        {
            incomeAndExpenseLogic = new IncomeAndExpenseLogic(programLogicView.IncomeAndExpenseDataGridView);
            commonAssetsLogic = new CommonAssetsLogic(programLogicView.CommonAssetsGridView);
            guideToOperationsLogic = new GuideToOperationsLogic();
        }

        private static ProgramLogic instance = null;

        public IncomeAndExpenseLogic incomeAndExpenseLogic {get; private set;}
        public CommonAssetsLogic commonAssetsLogic { get; private set; }
        public GuideToOperationsLogic guideToOperationsLogic { get; private set; }

        public static ProgramLogic GetInstance(ProgramLogicView programLogicView)
        {
            if(instance == null)
            {
                instance = new ProgramLogic(programLogicView);
            }
            return instance;
        }
    }
}
