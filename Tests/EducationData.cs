namespace qa_dotnet_cucumber.Tests
{
    public class EducationData
    {
        public string University { get; set; }
        public string Country { get; set; }
        public string Title{ get; set; }
        public string Degree { get; set; }
        public string Year { get; set; }

    }


    public class EducationEditData
    {
        public EducationData Original { get; set; }
        public EducationData Updated { get; set; }
    }

}