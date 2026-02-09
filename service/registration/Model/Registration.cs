namespace registration.Model
{
    public class Registration
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateOnly RegistrationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
