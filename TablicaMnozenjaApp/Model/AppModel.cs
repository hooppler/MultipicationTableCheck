using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablicaMnozenjaApp.Model
{
    public class AppModel
    {
        public DataModel dataModel = new DataModel();
        public NumberGeneratorModel ngm = new NumberGeneratorModel();

        public TestDataModel CreateTest(int excersisesNo)
        {
            TestDataModel test = new TestDataModel();
            test.NumberOfExcersises = excersisesNo;
            test.TestNo = dataModel.Tests.Count + 1;

            dataModel.Tests.Add(test);
            return test;
        }

        public ExcersiseDataModel NewExcersise(TestDataModel test)
        {
            ExcersiseDataModel excersise = new ExcersiseDataModel();
            ngm.GenerateNumbers();
            excersise.ExcersiseNo = test.TestExcersises.Count + 1;
            excersise.x = ngm.FirstNumber;
            excersise.y = ngm.SecondNumber;
            excersise.CorrectResult = ngm.FirstNumber * ngm.SecondNumber;
            excersise.Result = -1;

            test.TestExcersises.Add(excersise);
            return excersise;
        }

        public bool IsExcersisesExceededGiven(TestDataModel test)
        {
            if (test.TestExcersises.Count == test.NumberOfExcersises)
            {
                return false;
            }
            return true;
        }

        public List<TestDataModel> GetTests()
        {
            return dataModel.Tests;
        }

        public float CalculateSuccessRate(TestDataModel test)
        {
            float sum_correct = 0;
            foreach (ExcersiseDataModel excersise in test.TestExcersises)
            {
                if (excersise.CorrectResult == excersise.Result)
                {
                    sum_correct += 1;
                }
            }

            return sum_correct / test.TestExcersises.Count;
        }

        public int GetCorrectNo(TestDataModel test)
        {
            int sum_correct = 0;
            foreach (ExcersiseDataModel excersise in test.TestExcersises)
            {
                if (excersise.CorrectResult == excersise.Result)
                {
                    sum_correct += 1;
                }
            }
            return sum_correct;
        }

        public int CalculateMark(TestDataModel test)
        {
            float successRate = CalculateSuccessRate(test);

            if (0 <= successRate && successRate < 0.5) { return 1; }
            else if (0.5 <= successRate && successRate < 0.7) { return 2; }
            else if (0.7 <= successRate && successRate < 0.8) { return 3; }
            else if (0.8 <= successRate && successRate < 0.9) { return 4; }
            else if  (0.9 <= successRate && successRate <= 1) { return 5; }
            else { return 0; }
        }
    }
}
