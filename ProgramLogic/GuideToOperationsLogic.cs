using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за логику поведения справочника операций
    /// </summary>
    public class GuideToOperationsLogic
    {
        /// <summary>
        /// Список, хранящий все справки по операциям. Каждая справка по операции представлена в виде текстовых данных
        /// </summary>
        List<GuideToOperation> guideToOperations = new List<GuideToOperation>();
        GuideToOperationSQLiteDataProvider guideToOperationsDataProvider;

        public GuideToOperationsLogic()
        {
            guideToOperationsDataProvider = new GuideToOperationSQLiteDataProvider();
        }

        public GuideToOperation this[int index]
        {
            get 
            { 
                return guideToOperations[index]; 
            }
        }

        /// <summary>
        /// Данный метод возвращает количество справок по операциям
        /// </summary>
        /// <returns>Количество справок по операциям</returns>
        public int GetOperationsCount()
        {
            return guideToOperations.Count();
        }


        public void Load()
        {
            guideToOperations = guideToOperationsDataProvider.Load();
        }

        public void Insert(GuideToOperation guideToOperation)
        {
            guideToOperationsDataProvider.Insert(guideToOperation);
            Load();
        }

        public void Update(GuideToOperation guideToOperation, string textToUpdate)
        {
            guideToOperationsDataProvider.Update(guideToOperation, textToUpdate);
            Load();
        }

        public void Delete(int indexInProgram)
        {
            guideToOperationsDataProvider.Delete(guideToOperations[indexInProgram].GetInternalIndex().ToString());
            Load();
        }
    }
}