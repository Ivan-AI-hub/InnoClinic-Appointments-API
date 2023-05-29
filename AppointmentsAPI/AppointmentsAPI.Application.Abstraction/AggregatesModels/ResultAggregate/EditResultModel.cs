namespace AppointmentsAPI.Application.Abstraction.AggregatesModels.ResultAggregate
{
    public class EditResultModel
    {
        public string Complaints { get; set; }
        public string Conclusion { get; set; }
        public string Recomendations { get; set; }
        public EditResultModel(string complaints, string conclusion, string recomendations)
        {
            Complaints = complaints;
            Conclusion = conclusion;
            Recomendations = recomendations;
        }
    }
}
