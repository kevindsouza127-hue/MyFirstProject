
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Labcare.Master.Classes
{
    public class Test
    {
        [Required]
        public string  TestName { get; set; }
       [Required]
        public string TestPrintAs { get; set; }
        public string TestMethod { get; set; }
        public int TestRate { get; set; }
        public string TestCategory { get; set; }
        public int TestOrder { get; set; }
        public int TestSuppressNamePrint { get; set; }
        public string  TestKeepTogether { get; set; }
        public int TestPageSize { get; set; }
        public string TestFooter { get; set; }
        public string  TestCutCategory { get; set; }
        public  int Cost  { get; set; }
        public int TestOutSide { get; set; }
        public string hmscode { get; set; }
        public string SENDSMS { get; set; }
        public string  ViewReport { get; set; }
        public  string SampleType { get; set; }
        public int testdays{ get; set; }
        public int TestOSLabCode { get; set; }
        public int Testcount { get; set; }
        public string cptcode { get; set; }
        public int vcencode { get; set; }
        public string  samplevol{ get; set; }
        public string accrediation { get; set; }
        public int autoauth { get; set; }
        public int TAT { get; set; }
        public string  testalias { get; set; }
        public string calccptcode { get; set; }
        public string microspecialcpt { get; set;}
        public string histospecialcpt { get; set; }
        public string WEBTESTCODE { get; set; }
        public string Micro_ESBLCPT { get; set; }
        public  string Micro_colonyCPT { get; set; }
        public string testhmscode { get; set; }
        public string autocomplete { get; set; }
        public int vattestcatcode { get; set;}
        public string testschedule { get; set; }
        public int TestReorder { get; set; }
        public string SampleCollectionMethod { get; set; }
        public string  doneby { get; set; }
        public string adactivity { get; set; }
        public  string compname { get; set; }

    }

}
