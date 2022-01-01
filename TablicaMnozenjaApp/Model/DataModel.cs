using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablicaMnozenjaApp.Model
{
    public class DataModel
    {
        public List<TestDataModel> Tests = new List<TestDataModel>();
    }

    public class TestDataModel
    {
        public TestDataModel()
        {
            TestExcersises = new List<ExcersiseDataModel>();
        }

        public int TestNo { get; set; }
        public int NumberOfExcersises { get; set; }
        public int TestMark { get; set; }
        public List<ExcersiseDataModel> TestExcersises { get; set; }
    }

    public class ExcersiseDataModel
    {
        public int ExcersiseNo { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int CorrectResult { get; set; }
        public int Result { get; set; }
    }
}
