
namespace qa_dotnet_cucumber.Tests
{
    public class CertificationData
    {
        public string Certification { get; set; }
        public string From { get; set; }
        public string Year { get; set; }
     }

       
    public class CertificationEditData
    {
        public CertificationData Original { get; set; }
        public CertificationData Updated { get; set; }
    }
    
}
