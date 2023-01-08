namespace IBKS.Models.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjName { get; set; }
        public string Type { get; set; }
        public string status { get; set; }
        public DateTime DateOfCreation { get; set; }

        public string UserName { get; set; }



    
    }
}
