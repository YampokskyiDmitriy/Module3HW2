namespace Module3HW2.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName => $"{SecondName} {FirstName}";
    }
}